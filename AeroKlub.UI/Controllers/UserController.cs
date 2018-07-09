using AeroKlub.UI.Models;
using AreoKlub.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Controllers
{

    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private IPlaneRepository repository;
        private IReservationRepository reservationRepository;
        private IServicesRepository servicesRepository;
        private List<string> output;
        private List<string> output1;

        public UserController(IPlaneRepository repo , IReservationRepository repo1 , IServicesRepository repo2)
        {
            repository = repo;
            reservationRepository = repo1;
            servicesRepository = repo2;
        }

        public ActionResult Index(string Name, string NickName)
        {

            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Samoloty = repository.Samoloty, Reservations = null , Name = Name , NickName = NickName,
                Serwis = servicesRepository.Services
            };


            return View(viewModel);
        }


        public PartialViewResult GetReservation(string name, string data ,string username)
        {

            output = reservationRepository.GetReservation(name, data);
            output1 = reservationRepository.GetSpecificReservationForName(name, data, username);
            

            ReservationsListViewModel viewModel = new ReservationsListViewModel
            {
                reservations = output , hisreservations = output1
            };

            ViewBag.Name = username;

            return PartialView(viewModel);
        }

        public ViewResult GetHisReservations(string Name, string NickName)
        {
            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Samoloty = null,
                Reservations = reservationRepository.reservations,
                Name = Name,
                NickName = NickName,
                Serwis = servicesRepository.Services
            };


            return View(viewModel);
        }

        public ActionResult DeleteReservation(int ID , string Name1)
        {
           
            reservationRepository.DeleteReservation(ID);


            return RedirectToAction("GetHisReservations" , new { Name = Name1 });
        }



    }
}