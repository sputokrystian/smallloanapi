using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmallLoansApi.Models;
using SmallLoansApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallLoansApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SmallLoansContext _smallLoansContext;
        private readonly ILogger _logger;

        public UserRepository(SmallLoansContext smallLoansContext, ILogger<UserRepository> logger)
        {
            _smallLoansContext = smallLoansContext;
            _logger = logger;
        }

        public int CreateUser(User user)
        {
            try
            {
                _smallLoansContext.Users.Add(user);
                _smallLoansContext.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return user.Id;
        }

        public bool CheckUserExistByName(string name)
        {
            return _smallLoansContext.Users.Any(x => x.Name == name);
        }

        public bool CheckUserExistById(int id)
        {
            return _smallLoansContext.Users.Any(x => x.Id == id);
        }

        public User GetUserWithLoans(int id)
        {
            return _smallLoansContext.Users.Include(loan => loan.BorrowedLoans).Include(loan => loan.LendedLoans).SingleOrDefault(x => x.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _smallLoansContext.Users.Include(loan => loan.BorrowedLoans).Include(loan => loan.LendedLoans).ToListAsync();
        }

        public decimal ChangeUserBalance(int userId, decimal amount)
        {
            var balance = _smallLoansContext.Users.Single(x => x.Id == userId).Balance += amount;

            try
            {
                _smallLoansContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return balance;
        }
    }
}