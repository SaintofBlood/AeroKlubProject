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
        public ActionResult AddReservation(Reservation reservation , string Nickname , string TOUS , string FROMUS)
        {

             string[] Times = TOUS.Split('.');
             int to;
             Int32.TryParse(Times[0], out to);

            string[] Times1 = FROMUS.Split('.');
            int from;
            Int32.TryParse(Times1[0], out from);

            bool CanBeReached = true;

 

            foreach (var Rezerwacja in reservationRepository.reservations)
            {
                if (Rezerwacja.PlaneName == reservation.PlaneName && Rezerwacja.Date == reservation.Date)
                {
                    if (to < Rezerwacja.From && from > Rezerwacja.To)
                    {
                        CanBeReached = false;
                    }
                    else if (to > Rezerwacja.From && from > Rezerwacja.To)
                    {
                        if (to - Rezerwacja.To < 0)
                        {
                            CanBeReached = false;
                        }
                    }
                    else if (to >= Rezerwacja.From && from <= Rezerwacja.To)
                    {
                        CanBeReached = false;
                    }
                    else if (to < Rezerwacja.From && from < Rezerwacja.To)
                    {
                        if (Rezerwacja.From - from < 0)
                        {
                            CanBeReached = false;
                        }
                    }

                    
                }
            }

            

            if (CanBeReached == true)
            {
                reservation.ReservationID = 0;
                reservation.From = to;
                reservation.To = from;
                reservationRepository.AddReservation(reservation);
                TempData["message"] = "Poprawnie dodano rezerwacje!";
            }
            else
            {
                TempData["message"] = "Nie udało się dodać rezerwacji , z powodu braku dostępności danych godzin!";        
            }
            foreach (var user in usersRepository.Users)
            {
                if (Nickname == user.Username)
                {
                    if (user.Role == "Admin")
                        return RedirectToAction("Index", "Admin", new { usersRepository.GetSpecificName(Nickname).Name, NickName = Nickname });
                    if (user.Role == "Mechanic")
                        return RedirectToAction("Index", "Mechanic");
                    if (user.Role == "User")
                        return RedirectToAction("Index", "User", new { usersRepository.GetSpecificName(Nickname).Name, NickName = Nickname });
                }
            }

           
            
            return RedirectToAction("Login","Login");

        }

        public ActionResult DeleteReservation(int ReservationID , string Name , string Nickname)
        {

            reservationRepository.DeleteReservation(ReservationID);
            TempData["reservationmessage"] = "Poprawnie usunięto rezerwacje!";
            return RedirectToAction("Reservations", "Admin" , new { Name = Name , Nickname = Nickname});
        }
    }
}
 