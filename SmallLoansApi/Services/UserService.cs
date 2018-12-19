using SmallLoansApi.Dtos;
using SmallLoansApi.Helpers;
using SmallLoansApi.Models;
using SmallLoansApi.Models.Dtos;
using SmallLoansApi.Repositories.Interfaces;
using SmallLoansApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallLoansApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int CreateUser(CreateUserDto user)
        {
            return _userRepository.CreateUser(new User
            {
                Balance = 0.0m,
                Name = user.Name,
                Status = Status.User.Active,
                Password = PasswordHasher.HashPassword(user.Password)
            });
        }

        public bool CheckUserExistsByName(string name)
        {
            return _userRepository.CheckUserExistByName(name);
        }

        public bool CheckUserExistsById(int id)
        {
            return _userRepository.CheckUserExistById(id);
        }

        public UserDto GetUserWithLoans(int id)
        {
            var user = _userRepository.GetUserWithLoans(id);
            if (user == null)
                return null;

            return UserEntityToDtoMapper(user);
        }

        public async Task<List<UserDto>> GetUsers()
        {
            List<User> users = await _userRepository.GetUsers();
            List<UserDto> usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                usersDto.Add(UserEntityToDtoMapper(user));
            }

            return usersDto;
        }

        public decimal ChangeUserBalance(int userId, decimal amount)
        {
            return _userRepository.ChangeUserBalance(userId, amount);
        }

        private UserDto UserEntityToDtoMapper(User user)
        {
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Status = user.Status,
                Balance = user.Balance,
                Borrowed = new List<LoanDto>(),
                Lended = new List<LoanDto>()
            };

            if (user.BorrowedLoans != null)
            {
                foreach (var loan in user.BorrowedLoans)
                {
                    userDto.Borrowed.Add(new LoanDto
                    {
                        Amount = loan.Amount,
                        Description = loan.Description,
                        Id = loan.Id,
                        LoanDate = loan.LoanDate,
                        Status = loan.Status
                    });
                }
            }

            if (user.LendedLoans != null)
            {
                foreach (var loan in user.LendedLoans)
                {
                    userDto.Lended.Add(new LoanDto
                    {
                        Amount = loan.Amount,
                        Description = loan.Description,
                        Id = loan.Id,
                        LoanDate = loan.LoanDate,
                        Status = loan.Status
                    });
                }
            }

            return userDto;
        }
    }
}