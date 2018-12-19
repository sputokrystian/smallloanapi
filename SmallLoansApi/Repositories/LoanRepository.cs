using Microsoft.Extensions.Logging;
using SmallLoansApi.Models;
using SmallLoansApi.Repositories.Interfaces;
using System;
using System.Linq;

namespace SmallLoansApi.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly SmallLoansContext _smallLoansContext;
        private readonly ILogger _logger;

        public LoanRepository(SmallLoansContext smallLoansContext, ILogger<LoanRepository> logger)
        {
            _smallLoansContext = smallLoansContext;
            _logger = logger;
        }

        public int CreateLoan(Loan loan)
        {
            try
            {
                _smallLoansContext.Loans.Add(loan);
                _smallLoansContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return loan.Id;
        }

        public Loan FindLoanById(int id)
        {
            return _smallLoansContext.Loans.SingleOrDefault(x => x.Id == id);
        }

        public bool PayoffLoan(Loan payoffLoan)
        {
            try
            {
                _smallLoansContext.Loans.Update(payoffLoan);
                return _smallLoansContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }
    }
}