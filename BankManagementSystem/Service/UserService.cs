using BankManagementSystem.Models;
using BankManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _Repository;
        public UserService(IUserRepository Repository)
        {
            _Repository = Repository;
        }
        public void AddUser(User entity)
        {
            _Repository.Add(entity);
        }

        public User AuthenticateMember(string username, string password)
        {
            User user= _Repository.CheckCredentials(username,password);
            return user;
        }

        public User GetUser(string id)
        {
            return _Repository.Get(id);
        }

        public void UpdateUser(string id, User user)
        {
            _Repository.Update(id,user);
        }
        /*public void Loan(UserLoan userLoan)
        {
            _Repository.ApplyLoan(userLoan);
        }*/
    }
}
