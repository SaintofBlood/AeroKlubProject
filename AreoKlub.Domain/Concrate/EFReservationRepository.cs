using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Concrate
{
    public class EFReservationRepository : IReservationRepository
    {
        private EFDbContext context = new EFDbContext();
        private List<string> output = new List<string>();
        private List<string> output1 = new List<string>();
        private List<string> output2 = new List<string>();
        private IEnumerable<string> output3;

        public IEnumerable<Reservation> reservations
        {
            get
            {
                return context.Reservation;
            }
        }

        public List<string> GetReservation(string name, string data)
        {

            foreach (var reservation in reservations)
            {
                if (name == reservation.PlaneName && data == reservation.Date)
                {
                    output.Add("Od godziny: " + reservation.From + " , do godziny: " + reservation.To);
                }
            }
            return output;
        }

        public IEnumerable<string> GetReservationWithoutPrefix(string name, string data)
        {
        
            foreach (var reservation in reservations)
            {
                if (name == reservation.PlaneName && data == reservation.Date)
                {
                    output2.Add(reservation.From + "," + reservation.To);
                }
            }

 
            return output2.AsEnumerable();
        }

        public void AddReservation(Reservation reservation)
        {
            reservation.ReservationID = 0;
            context.Reservation.Add(reservation);
            context.SaveChanges();
        }


        public void DeleteReservation(int ReservationID)
        {
            Reservation dbEntry = context.Reservation.Find(ReservationID);
            context.Reservation.Remove(dbEntry);
            context.SaveChanges();

        }

        public List<string> GetSpecificReservationForName(string name, string date, string username)
        {
            foreach(var reservation in reservations)
            {
                if(name == reservation.PlaneName && date == reservation.Date  && username == reservation.By)
                {
                    output1.Add("Od godziny: " + reservation.From + " , do godziny: " + reservation.To);
                }
            }

            if(output1.Any() == false)
            {
                return null;
            }
            return output1;
        }

    }
}
