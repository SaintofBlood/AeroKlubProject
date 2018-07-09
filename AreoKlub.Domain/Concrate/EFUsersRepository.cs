using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
