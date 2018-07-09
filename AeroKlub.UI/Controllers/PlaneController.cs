using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Controllers
{
    public class PlaneController : Controller
    {
        private IPlaneRepository repository;
        private IReservationRepository repostiory1;

        public PlaneController(IPlaneRepository repo , IReservationRepository repo1)
        {
            repository = repo;
            repostiory1 = repo1;
        }

        public ViewResult AddPlane()
        {
             Samolot plane = new Samolot()
             {
                  //Nazwa = "CIPAHUJPENIS", PlaneID = 0
             };
             repository.AddPlane(plane);
             


         /*  Reservation reservation12 = new Reservation()
            {
                ReservationID = 0 , PlaneName = "XDS" , Date = "1.2.3" , By = "1" , To = 2 , From = 1
            };

            repostiory1.AddReservation(reservation12);
            */
            return View();
           
        } 

        public ViewResult DeletePlane()
        {
            
            Samolot deletePlane = repository.DeletePlane(repository.Samoloty.Count() - 1);
            return View();
        }

       

    }
}