using SmallLoansApi.Dtos;
using SmallLoansApi.Models;

namespace SmallLoansApi.Services.Interfaces
{
    public interface ILoanService
    {
        int CreateLoan(CreateLoanDto loan);

        Status.Loan PayoffLoan(PayoffLoanDto payoffLoan);
    }
}