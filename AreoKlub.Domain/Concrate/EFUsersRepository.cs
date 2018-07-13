using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using AreoKlub.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AreoKlub.Domain.Concrate
{
    public class EFUsersRepository : IUsersRepository
    {

        private EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }

        }

        public User GetSpecificName(string UserName)
        {
            User dbEntry = new User();

            foreach (var User in context.Users)
            {
                if (User.Username == UserName)
                {
                    dbEntry.Name = User.Name;
                    return dbEntry;
                }             
            }
            return null;
        }

        public User GetByUsernameAndPassword(User user)
        {

            var getUser = context.Users.Where(u => u.Username == user.Username).FirstOrDefault();

            if (getUser != null)
            {
                var hashCode = getUser.VCode;
                var encodingPasswordString = Helper.EncodePassword(user.Password, hashCode);

                var query = (from s in context.Users where (s.Username == user.Username) && s.Password.Equals(encodingPasswordString) select s).FirstOrDefault();

                if (query != null)
                {
                    return query;
                }

            }

            return null;
        }

        public void AddUserToRepository(string Name, string Username, string passwd, string VCode, string Email)
        {
            User dbEntry = new User
            {
                Name = Name, Username = Username, Password = passwd, Email = Email, Role = "User", Id = 0, VCode = VCode, CreationDate = DateTime.Today.ToShortDateString()
            };

            context.Users.Add(dbEntry);
            context.SaveChanges();
        }

        public void ChangeRoleOfUserToMechanic(string Name)
        {
            foreach(var User in context.Users)
            {
                if(Name == User.Name)
                {
                    User.Role = "Mechanic";
                    break;
                }
            }

            context.SaveChanges();
        }

        public void DeleteUser(string Name)
        {
            User dbEntry = new User();

            foreach(var user in context.Users)
            {
                if(user.Name == Name)
                {
                    dbEntry = user;
                }
            }

            if (dbEntry.Name != null)
            {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public SelectList UserList()
        {

            List<string> output = new List<string>();

            foreach (var user in context.Users)
            {
                if(user.Role != "Admin" )
                output.Add(user.Name);
            }

            SelectList dbEntry = new SelectList(output);
            return dbEntry;
        }

        public bool CheckIfUserExist(string Name)
        {

            foreach(var user in context.Users)
            {
                if(Name == user.Username)
                {
                    return true;
                }
            }

            return false;
        }


    }
}
