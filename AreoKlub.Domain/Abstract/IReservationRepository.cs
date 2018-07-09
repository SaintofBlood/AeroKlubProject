using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Abstract
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> reservations { get; }

        List<string> GetReservation(string name, string data) ;

        void AddReservation(Reservation reservation);

        void DeleteReservation(int ReservationID);

        List<string> GetSpecificReservationForName(string name, string date, string username);
    }
}
