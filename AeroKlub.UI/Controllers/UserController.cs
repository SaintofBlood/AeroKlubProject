using AeroKlub.UI.Models;
using AreoKlub.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Controllers
{
  //  [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private IPlaneRepository repository;
        private IReservationRepository reservationRepository;
        private List<string> output;

        public UserController(IPlaneRepository repo , IReservationRepository repo1)
        {
            repository = repo;
            reservationRepository = repo1;
        }

        public ActionResult Index(string Name, string NickName)
        {

            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Samoloty = repository.Samoloty, Reservations = null , Name = Name , NickName = NickName
            };

            return View(viewModel);
        }


        public PartialViewResult GetReservation(string name, string data)
        {

            output = reservationRepository.GetReservation(name, data);

            ReservationsListViewModel viewModel = new ReservationsListViewModel
            {
                reservations = output
            };


            return PartialView(viewModel);
        }

    }
}