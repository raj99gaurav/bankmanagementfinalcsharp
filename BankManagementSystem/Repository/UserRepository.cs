using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly UserContext _userContext; 
        public UserRepository(UserContext context)
        {
            _userContext = context;
        }
        public void Add(User entity)
        {
            _userContext.Users.Add(entity);
            _userContext.SaveChanges();
        }

        public User CheckCredentials(string username, string password)
        {
            try
            {
                User member = GetMember(username, password);
                return member;
            }
            catch (Exception e)
            {
                return new User();
            }
        }

        public User Get(string id)
        {
            
                return _userContext.Users.FirstOrDefault(e => e.UserId == id);
        }

        public void Update(string id, User user)
        {
            _userContext.Entry(user).State = EntityState.Modified;
            _userContext.SaveChanges();
        }

        private User GetMember(string username, string password)
        {
            return _userContext.Users.First(u => u.UserName == username && u.Password == password);
        }

        /*public void ApplyLoan(UserLoan userLoan)
        {
            _userContext.UserLoan.Add(userLoan);
            _userContext.SaveChanges();
        }*/
    }
}
