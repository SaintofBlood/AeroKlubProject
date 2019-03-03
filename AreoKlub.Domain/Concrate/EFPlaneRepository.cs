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

        public IEnumerable<Plane> Samoloty
        {
            get
            {
                return context.Planes;            
            }
        }

        public void AddPlane(Plane samolt)
        {
            if(samolt.PlaneID == 0)
            {
                context.Planes.Add(samolt);
            }
          
            context.SaveChanges();
        }
        private int KeyId;
        public void DeletePlane(string Name)
        {

            
            foreach(var samolot in context.Planes)
            {
                if(samolot.Nazwa == Name)
                {
                    KeyId = samolot.PlaneID;
                }
            }

             Plane dbEntry = context.Planes.Find(KeyId);
             if(dbEntry != null)
             {
                 context.Planes.Remove(dbEntry);
                
             }
            context.SaveChanges();
 
          
        }

       
     

    }
}
