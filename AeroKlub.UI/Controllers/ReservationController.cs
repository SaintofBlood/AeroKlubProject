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

        public string[] wait;
       // public int[] oneSet;
        List<int> oneSet = new List<int>();
        List<int> twoSet = new List<int>();
        //public int[] twoSet;

        public PartialViewResult Rezerwacja(string PlaneName, string Date, string Name, int Number , string By , string NickName , bool All)
        {
            ViewBag.Plane = PlaneName;
            ViewBag.Date = Date;
            ViewBag.Name = Name;
            ViewBag.Number = Number;
            ViewBag.By = By;
            ViewBag.Nickname = NickName;
            ViewBag.All = All.ToString();
            
              
            string output = "background: linear-gradient(90deg";


            foreach(var reservation in reservationRepository.reservations) 
            {
                if (reservation.PlaneName == PlaneName && reservation.Date == Date)
                {
                    oneSet.Add(reservation.From);
                    twoSet.Add(reservation.To);

               
                }
            }

            for(int z = 0; z < ( oneSet.Count() ) - 1; z++)
            {


                if (oneSet[z] > oneSet[z+1])
                {
                    int sec = 0;
                    int sek = 0;
                    sec = oneSet[z ];
                    sek = oneSet[z + 1];

                    oneSet[z] = sek;
                    oneSet[z + 1] = sec;

                    sec = twoSet[z];
                    sek = twoSet[z + 1];

                    twoSet[z] = sek;
                    twoSet[z + 1] = sec;

                    z = 0;
                }

                 

            }

        

            for (int z = 0; z < oneSet.Count(); z++)
            {
                output += " , rgba(0,0,0,0) " + (oneSet[z] * (4.16)).ToString().Replace(',', '.') + "%, rgba(255,51,51,0.9) " + (oneSet[z] * (4.16)).ToString().Replace(',', '.') + "%,rgba(255,51,51,0.9) " + (twoSet[z] * (4.16)).ToString().Replace(',', '.') + "%,rgba(0,0,0,0) " + (twoSet[z] * (4.16)).ToString().Replace(',', '.') + "%";
            }


            output += " );";

            ViewBag.StringCreator = output;

            return PartialView();
        }

        public ViewResult Create()
        {
            return View("AddReservation", new Reservation());
        }


       [HttpPost]
        public ActionResult AddReservation(Reservation reservation , string Nickname , string TOUS , string FROMUS , string All)
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
                    else
                    {
                        CanBeReached = false;
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
                        if (Convert.ToBoolean(All) == true)
                            return RedirectToAction("Index", "Admin", new { usersRepository.GetSpecificName(Nickname).Name, NickName = Nickname , All = true, Date = reservation.Date });
                        else
                            return RedirectToAction("Index", "Admin", new { usersRepository.GetSpecificName(Nickname).Name, NickName = Nickname, All = false, PlaneName = reservation.PlaneName , Date = reservation.Date});
                    if (user.Role == "Mechanic")
                        return RedirectToAction("Index", "Mechanic");
                    if (user.Role == "User")
                        if(Convert.ToBoolean(All) == true)
                        return RedirectToAction("Index", "User", new { usersRepository.GetSpecificName(Nickname).Name, NickName = Nickname  , All = true, Date = reservation.Date });
                    else
                            return RedirectToAction("Index", "User", new { usersRepository.GetSpecificName(Nickname).Name, NickName = Nickname, All = false, PlaneName = reservation.PlaneName, Date = reservation.Date });
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
 