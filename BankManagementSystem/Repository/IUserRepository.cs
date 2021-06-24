using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Repository
{
    public interface IUserRepository
    {
        void Add(User entity);
        User CheckCredentials(string username, string password);

        User Get(string id);

        void Update(string id,User user);

        //void ApplyLoan(UserLoan userLoan);
    }
}
