using SmallLoansApi.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmallLoansApi.Services.Interfaces
{
    public interface IUserService
    {
        int CreateUser(CreateUserDto user);

        bool CheckUserExistsByName(string name);

        bool CheckUserExistsById(int id);

        UserDto GetUserWithLoans(int id);

        Task<List<UserDto>> GetUsers();

        decimal ChangeUserBalance(int userId, decimal amount);
    }
}