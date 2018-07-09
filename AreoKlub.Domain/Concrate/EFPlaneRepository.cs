using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Concrate
{
    public class EFPlaneRepository : IPlaneRepository
    {

        private EFDbContext context = new EFDbContext();

        public IEnumerable<Samolot> Samoloty
        {
            get
            {
                return context.Samoloty;            
            }
        }

        public void AddPlane(Samolot samolt)
        {
            if(samolt.PlaneID == 0)
            {
                context.Samoloty.Add(samolt);
            }
          
            context.SaveChanges();
        }

        public Samolot DeletePlane(int PlaneID)
        {
             Samolot dbEntry = context.Samoloty.Find(PlaneID);
             if(dbEntry != null)
             {
                 context.Samoloty.Remove(dbEntry);
                 context.SaveChanges();
             }
            return dbEntry;
          
        }

       
     

    }
}
