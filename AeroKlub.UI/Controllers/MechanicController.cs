using AeroKlub.UI.Models;
using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Controllers
{
    [Authorize(Roles = "Mechanic")]
    public class MechanicController : Controller
    {

        private IPlaneRepository repository;
        private IServicesRepository repository1;

        public MechanicController(IPlaneRepository repo , IServicesRepository repo1)
        {
            repository = repo;
                repository1 = repo1;
        }

        public ActionResult Index(string Name, string NickName)
        {

            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Samoloty = repository.Samoloty,
                Reservations = null,Serwis = repository1.Services,
                Name = Name , NickName = NickName
            };

            return View(viewModel);
        }

        public ActionResult AddServiceToPlane(string Name , string NickName)
        {
            List<string> output = new List<string>();

            foreach(var samolot in repository.Samoloty)
            {
                output.Add(samolot.Nazwa);
            }

            SelectList Lista = new SelectList(output);

            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Samoloty = repository.Samoloty , ListaSamolotów = Lista, Name = Name , NickName = NickName
            };
           return View(viewModel);
        }

        [HttpPost]
        public ActionResult RezerwacjaNaNaprawe(string PlaneName , string Date , string Name, string NickName)
        {
                Service dbEntry = new Service();
                dbEntry.Samolot = PlaneName;
                dbEntry.Data = Date;
                dbEntry.By = Name;
                dbEntry.Id = 0;
                List<string> output = new List<string>();
                foreach (var samolot in repository.Samoloty)
                {
                    output.Add(samolot.Nazwa);
                }
                SelectList Lista = new SelectList(output);

                PlaneListViewModel planeListViewModel = new PlaneListViewModel
                {
                    Name = Name,
                    NickName = NickName,
                    Samoloty = repository.Samoloty,
                    ListaSamolotów = Lista,
                    Serwis = repository1.Services
                };

               if (DateTime.ParseExact(Date, "dd.MM.yyyy", CultureInfo.InvariantCulture) < DateTime.Today)
               {
                    TempData["mechanicmessage"] = "Nie można dodać rezerwacji serwisu , starszej od dnia dzisiejszego!";

                    return View("AddServiceToPlane", planeListViewModel);
               }
               else
               {
                    repository1.AddService(dbEntry);
                    TempData["mechanicmessage"] = "Dodano rezerwacje terminu na servis samolotu " + PlaneName + " , w dniu " + Date;
                    return View("AddServiceToPlane", planeListViewModel);
               }
        }  

        public ViewResult PlaneList(string Name , string Nickname)
        {

            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Name = Name , NickName = Nickname , Samoloty = repository.Samoloty
            };

            return View(viewModel);
        }
    }
}