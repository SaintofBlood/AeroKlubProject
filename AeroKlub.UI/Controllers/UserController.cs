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

        public UserController(IPlaneRepository repo, IReservationRepository repo1, IServicesRepository repo2)
        {
            repository = repo;
            reservationRepository = repo1;
            servicesRepository = repo2;
        }

        public ActionResult Index(string Name, string NickName, string PlaneName, bool All)
        {


            List<string> output = new List<string>();
            foreach (var samolot in repository.Samoloty)
            {
                output.Add(samolot.Nazwa);
            }
            SelectList Lista = new SelectList(output);

            if (String.IsNullOrWhiteSpace(PlaneName) == true && All == true)
            {

                PlaneListViewModel viewModel1 = new PlaneListViewModel
                {
                    Samoloty = repository.Samoloty,
                    Reservations = null,
                    Name = Name,
                    NickName = NickName,
                    Serwis = servicesRepository.Services,
                    ListaSamolotów = Lista,
                    PlaneName = null
                };

                return View(viewModel1);
            }
            else if (String.IsNullOrWhiteSpace(PlaneName) == false)
            {


                foreach (var samolot in repository.Samoloty)
                {
                    if (samolot.Nazwa == PlaneName)
                    {
                        PlaneListViewModel Model = new PlaneListViewModel
                        {
                            PlaneName = samolot.Nazwa,
                            Reservations = null,
                            Name = Name,
                            NickName = NickName,
                            Serwis = servicesRepository.Services,
                            ListaSamolotów = Lista
                        };

                        return View(Model);
                    }
                }
            }


                PlaneListViewModel viewModel = new PlaneListViewModel
                {
                    Samoloty = null,
                    Reservations = null,
                    Name = Name,
                    NickName = NickName,
                    Serwis = null,
                    ListaSamolotów = Lista,
                    PlaneName = null
                };

                return View(viewModel);
   
        }

   
     


        public PartialViewResult GetReservation(string name, string data, string username)
        {

            output = reservationRepository.GetReservation(name, data);
            output1 = reservationRepository.GetSpecificReservationForName(name, data, username);


            ReservationsListViewModel viewModel = new ReservationsListViewModel
            {
                reservations = output, hisreservations = output1
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

        public ActionResult DeleteReservation(int ID, string Name1)
        {

            reservationRepository.DeleteReservation(ID);


            return RedirectToAction("GetHisReservations", new { Name = Name1 });
        }

        [HttpPost]
        public ActionResult SerchPlane(string PlaneName , string Name , string NickName)
        {

            return RedirectToAction("Index" , new { PlaneName = PlaneName , All = false , Name = Name , NickName = NickName});
        }


    }
}