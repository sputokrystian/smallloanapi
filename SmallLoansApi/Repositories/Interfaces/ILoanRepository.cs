using SmallLoansApi.Models;

namespace SmallLoansApi.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        int CreateLoan(Loan loan);

        Loan FindLoanById(int id);

        bool PayoffLoan(Loan payoffLoan);
    }
}