using SmallLoansApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmallLoansApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        int CreateUser(User user);

        bool CheckUserExistByName(string name);

        bool CheckUserExistById(int id);

        User GetUserWithLoans(int id);

        Task<List<User>> GetUsers();

        decimal ChangeUserBalance(int userId, decimal amount);
    }
}