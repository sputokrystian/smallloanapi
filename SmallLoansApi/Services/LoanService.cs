using SmallLoansApi.Dtos;
using SmallLoansApi.Models;
using SmallLoansApi.Repositories.Interfaces;
using SmallLoansApi.Services.Interfaces;

namespace SmallLoansApi.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserService _userService;

        public LoanService(ILoanRepository loanRepository, IUserService userService)
        {
            _loanRepository = loanRepository;
            _userService = userService;
        }

        public int CreateLoan(CreateLoanDto loan)
        {
            var loanId = _loanRepository.CreateLoan(new Loan
            {
                Amount = loan.Amount,
                BorrowerId = loan.BorrowerId,
                LenderId = loan.LenderId,
                LoanDate = loan.LoanDate,
                Description = loan.Description,
                Status = Status.Loan.ToPay
            });

            if (loanId != 0)
            {
                _userService.ChangeUserBalance(loan.BorrowerId, loan.Amount * -1);
                _userService.ChangeUserBalance(loan.LenderId, loan.Amount);
            }

            return loanId;
        }

        public Status.Loan PayoffLoan(PayoffLoanDto payoffLoan)
        {
            var loan = _loanRepository.FindLoanById(payoffLoan.LoanId);
            if (loan == null)
                return Status.Loan.Nonexistent;
            else if (loan.Status == Status.Loan.Repaid)
                return Status.Loan.AlreadyRepaid;

            loan.Amount -= payoffLoan.Amount;
            loan.Status = loan.Amount == 0 ? Status.Loan.Repaid : loan.Amount > 0 ? Status.Loan.PartlyPaid : Status.Loan.OverPaid;

            if (loan.Status == Status.Loan.OverPaid)
                return Status.Loan.OverPaid;

            if (_loanRepository.PayoffLoan(loan))
            {
                _userService.ChangeUserBalance(loan.BorrowerId, payoffLoan.Amount);
                _userService.ChangeUserBalance(loan.LenderId, payoffLoan.Amount * -1);
            }

            return loan.Status;
        }
    }
}