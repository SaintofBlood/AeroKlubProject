using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Concrate
{
    public class EFReservationRepository  : IReservationRepository
    {
        private EFDbContext context = new EFDbContext();
        private List<string> output = new List<string>();

        public IEnumerable<Reservation> reservations
        {
            get
            {
                return context.Reservation;
            }
        }

        public List<string> GetReservation(string name , string data)
        {   

           foreach(var reservation in reservations)
            {
                if(name == reservation.PlaneName && data == reservation.Date)
                {
                    output.Add(reservation.From + "-" + reservation.To);
                }
            }
            return output;
        }

        public void AddReservation(Reservation reservation)
        {
            reservation.ReservationID = 0;
            context.Reservation.Add(reservation);
            context.SaveChanges();
        }

    }
}
