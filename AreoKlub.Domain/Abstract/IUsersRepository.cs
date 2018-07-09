using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Abstract
{
    public interface IUsersRepository
    {

        IEnumerable<User> Users { get; }

        User GetSpecificName(string UserName);

    }
}
