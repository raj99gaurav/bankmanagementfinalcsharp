using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Service
{
    public interface IUserService
    {
        void AddUser(User entity);
        User AuthenticateMember(string username, string password);

        User GetUser(string id);
        void UpdateUser(string id,User user);
       // void Loan(UserLoan userLoan);
    }
}
