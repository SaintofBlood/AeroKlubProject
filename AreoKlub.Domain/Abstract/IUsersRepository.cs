using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AreoKlub.Domain.Abstract
{
    public interface IUsersRepository
    {

        IEnumerable<User> Users { get; }

        User GetSpecificName(string UserName);

        User GetByUsernameAndPassword(User user);

        void AddUserToRepository(string Name, string Username, string passwd, string VCode  , string Email);

        void ChangeRoleOfUserToMechanic(string Name);

        void DeleteUser(string Name);

        SelectList UserList();

        bool CheckIfUserExist(string Name);
    }
}
