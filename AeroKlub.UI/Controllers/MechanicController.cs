using AeroKlub.UI.Models;
using AreoKlub.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Controllers
{
    [Authorize(Roles = "Mechanic")]
    public class MechanicController : Controller
    {

        private IPlaneRepository repository;

        public MechanicController(IPlaneRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {

            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Samoloty = repository.Samoloty,
                Reservations = null
            };

            return View(viewModel);
        }
    }
}