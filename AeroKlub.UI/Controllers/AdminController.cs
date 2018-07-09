using AeroKlub.UI.Models;
using AreoKlub.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IPlaneRepository repository;
        private IReservationRepository reservationRepository;
        private List<string> output;

        public AdminController(IPlaneRepository planeRepository , IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
            this.repository = planeRepository;
        }
        public ActionResult Index(string Name , string NickName)
        {
            
            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Samoloty = repository.Samoloty, Reservations = reservationRepository.reservations , Name = Name , NickName = NickName
            };

            
            return PartialView(viewModel);
        }

        


        public PartialViewResult GetReservation(string name , string data)
        {
             
            output = reservationRepository.GetReservation(name , data);
            
            ReservationsListViewModel viewModel = new ReservationsListViewModel
            {
                reservations = output
            };
            
            
            return PartialView(viewModel);
        }

    }
}