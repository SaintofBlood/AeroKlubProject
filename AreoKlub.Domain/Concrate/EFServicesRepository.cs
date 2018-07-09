using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Concrate
{
    public class EFServicesRepository : IServicesRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Service> Services
        {
            get
            {
                return context.Services;
            }
        }

        public void AddService(Service service)
        {
            if(service.Id == 0)
            {
                context.Services.Add(service);
            }

            context.SaveChanges();
        }

        public int ID;

        public void DeleteService(string Plane , string Data , string Name)
        {

            foreach(var Service in context.Services)
            {
                if(Service.Samolot == Plane && Service.Data == Data && Service.By == Name)
                {
                    ID = Service.Id;
                }
            }

            
            Service dbEntry = context.Services.Find(ID);

            if(dbEntry != null)
            {
                context.Services.Remove(dbEntry);
                context.SaveChanges();
            }



        }

    }
}
