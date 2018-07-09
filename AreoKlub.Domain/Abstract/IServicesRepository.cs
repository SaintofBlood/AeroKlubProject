using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Abstract
{
    public interface IServicesRepository
    {
        IEnumerable<Service> Services { get; }

        void AddService(Service service);

        void DeleteService(string Plane, string Data, string Name);
    }
}
