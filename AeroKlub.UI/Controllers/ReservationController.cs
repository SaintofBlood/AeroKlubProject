using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class ReservationController : Controller
    {
        private IReservationRepository reservationRepository;
        private IUsersRepository usersRepository;

        public ReservationController(IReservationRepository reposytory , IUsersRepository repository1)
        {
            reservationRepository = reposytory;
            usersRepository = repository1;
        }

        public PartialViewResult Rezerwacja(string PlaneName, string Date, string Name, int Number , string By , string NickName)
        {
            ViewBag.Plane = PlaneName;
            ViewBag.Date = Date;
            ViewBag.Name = Name;
            ViewBag.Number = Number;
            ViewBag.By = By;
            ViewBag.Nickname = NickName;
            return PartialView();
        }

        public ViewResult Create()
        {
            return View("AddReservation", new Reservation());
        }


       [HttpPost]
        public ActionResult AddReservation(Reservation reservation /*, string SliderTime*/ , string Nickname , string TOUS , string FROMUS)
        {

             string[] Times = TOUS.Split('.');
             int to;
             Int32.TryParse(Times[0], out to);

            string[] Times1 = FROMUS.Split('.');
            int from;
            Int32.TryParse(Times1[0], out from);

           
            reservation.ReservationID = 0;
            reservation.From = to;
            reservation.To = from;
            reservationRepository.AddReservation(reservation);

            foreach (var user in usersRepository.Users)
            {
                if (user.Username == Nickname)
                {
                    if (user.Role == "Admin")
                        return RedirectToAction("Index", "Admin", new { Name = usersRepository.GetSpecificName(Nickname).Name, NickName = Nickname });
                    if (user.Role == "Mechanic")
                        return RedirectToAction("Index", "Mechanic");
                    if (user.Role == "User")
                        return RedirectToAction("Index", "User", new { Name = usersRepository.GetSpecificName(Nickname).Name, NickName = Nickname });
                }
            }

            return View();

        }
    }
}
 