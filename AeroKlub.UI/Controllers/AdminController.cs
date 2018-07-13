using AeroKlub.UI.Models;
using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using AreoKlub.Domain.Helpers;
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
        private IServicesRepository servicesRepository;
        private IUsersRepository userRepository;

        

        public AdminController(IPlaneRepository planeRepository, IReservationRepository reservationRepository, IServicesRepository repository, IUsersRepository repository1)
        {
            this.reservationRepository = reservationRepository;
            this.repository = planeRepository;
            this.servicesRepository = repository;
            this.userRepository = repository1;
        }

        public ActionResult Index(string Name, string NickName, string PlaneName, bool? All)
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



        private List<string> output3;
        private List<string> output4;

        public PartialViewResult GetReservation(string name, string data, string username)
        {

            output3 = reservationRepository.GetReservation(name, data);
            output4 = reservationRepository.GetSpecificReservationForName(name, data, username);


            ReservationsListViewModel viewModel = new ReservationsListViewModel
            {
                reservations = output3,
                hisreservations = output4
            };

            ViewBag.Name = username;

            return PartialView(viewModel);
        }

        public ViewResult Reservations(string Name, string Nickname)
        {
            PlaneListViewModel reservations = new PlaneListViewModel
            {
                Reservations = reservationRepository.reservations,
                Name = Name,
                NickName = Nickname
            };
            return View(reservations);
        }
        public ViewResult Samoloty(string Name, string Nickname)
        {

            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Samoloty = repository.Samoloty,
                Name = Name,
                NickName = Nickname
            };

            return View(viewModel);
        }

        public ViewResult PlaneServices(string Name, string Nickname)
        {
            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Samoloty = repository.Samoloty,
                Serwis = servicesRepository.Services,
                Name = Name,
                NickName = Nickname
            };

            return View(viewModel);
        }

        public ActionResult AddPlane(string Name, string Nickname)
        {
            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Name = Name,
                NickName = Nickname
            };

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult AddPlaneToReposiotry(string NazwaSamolotu, string Przebieg, string Name, string Nickname)
        {
            Samolot samolot = new Samolot();
            samolot.Nazwa = NazwaSamolotu.Replace(" " , "_");
            int outs;
            Int32.TryParse(Przebieg, out outs);
            samolot.WylataneGodziny = outs;

            repository.AddPlane(samolot);

            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Name = Name,
                NickName = Nickname
            };

            TempData["addplanemessage"] = "Poprawnie dodano samolot o nazwie " + samolot.Nazwa.Replace("_" , " ") + " o przebiegu wynoszącym " + samolot.WylataneGodziny + " godzin.";

            return View("AddPlane", viewModel);

        }


        [HttpPost]
        public ActionResult DeletePlaneFromRepository(string PlaneName, string Name, string Nickname)
        {

            repository.DeletePlane(PlaneName);

            List<string> output = new List<string>();
            foreach (var samolot in repository.Samoloty)
            {
                output.Add(samolot.Nazwa);
            }
            SelectList Lista = new SelectList(output);

            PlaneListViewModel viewModel = new PlaneListViewModel()
            {
                Name = Name,
                NickName = Nickname,
                ListaSamolotów = Lista
            };

            TempData["deleteplanemessage"] = "Usunięto samolot o nazwie: " + PlaneName.Replace("_" , " ") + " !";

            return View("DeletePlane", viewModel);
        }

        public ActionResult DeletePlane(string Name, string Nickname)
        {
            List<string> output = new List<string>();
            foreach (var samolot in repository.Samoloty)
            {
                output.Add(samolot.Nazwa);
            }
            SelectList Lista = new SelectList(output);

            PlaneListViewModel viewModel = new PlaneListViewModel()
            {
                Samoloty = repository.Samoloty,
                Name = Name,
                NickName = Nickname, ListaSamolotów = Lista
            };

            return View(viewModel);
        }
        public ViewResult AddManuallyService(string Name, string Nickname)
        {

            List<string> output = new List<string>();
            foreach (var user in userRepository.Users)
            {
                if (user.Role == "Mechanic")
                {
                    output.Add(user.Name);
                }
            }

            SelectList List = new SelectList(output);

            List<string> output1 = new List<string>();

            foreach (var plane in repository.Samoloty)
            {
                output1.Add(plane.Nazwa);
            }

            SelectList PlaneList = new SelectList(output1);

            PlaneListViewModel viewModel = new PlaneListViewModel()
            {
                Name = Name,
                NickName = Nickname,
                ListaSamolotów = PlaneList,
                MechanicList = List
            };

            return View(viewModel);
        }

        [HttpPost]
        public ViewResult AddServiceToRepostory(string Plane, string Mechanic, string Date, string Name, string Nickname)
        {
            Service service = new Service();
            service.Data = Date;
            service.By = Mechanic;
            service.Samolot = Plane;
            service.Id = 0;

            servicesRepository.AddService(service);

            List<string> output = new List<string>();
            foreach (var user in userRepository.Users)
            {
                if (user.Role == "Mechanic")
                {
                    output.Add(user.Name);
                }

            }

            SelectList List = new SelectList(output);

            List<string> output1 = new List<string>();

            foreach (var plane in repository.Samoloty)
            {
                output1.Add(plane.Nazwa);
            }

            SelectList PlaneList = new SelectList(output1);

            PlaneListViewModel viewModel = new PlaneListViewModel()
            {
                Name = Name,
                NickName = Nickname,
                ListaSamolotów = PlaneList,
                MechanicList = List
            };

            TempData["addmanuallyservice"] = "Dodano servis , dnia " + Date + " , mechanikowi " + Mechanic.Replace("_", " ") + " , dla samolotu " + Plane.Replace("_", " ") + ".";
            return View("AddManuallyService", viewModel);
        }

        public ViewResult DeleteService(string Name, string Nickname)
        {


            List<string> output = new List<string>();

            foreach (var service in servicesRepository.Services)
            {
                output.Add(service.Samolot + " " + service.Data + " " + service.By);
            }

            SelectList serviceList = new SelectList(output);



            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Name = Name, NickName = Nickname, ServiceList = serviceList
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteServiceFromRepository(string Link, string Name, string Nickname)
        {

            string[] Parts = Link.Split(' ');

            servicesRepository.DeleteService(Parts[0], Parts[1], Parts[2]);

            List<string> output = new List<string>();

            foreach (var service in servicesRepository.Services)
            {
                output.Add(service.Samolot + " " + service.Data + " " + service.By);
            }

            SelectList serviceList = new SelectList(output);



            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Name = Name,
                NickName = Nickname,
                ServiceList = serviceList
            };

            TempData["deletemanuallyservice"] = "Został poprawnie usunięty serwis , dnia " + Parts[1];

            return View("DeleteService", viewModel);
        }

        public ActionResult AddManualyReservation(string Name, string Nickname)
        {


            PlaneListViewModel viewModel = new PlaneListViewModel
            {
                Name = Name,
                NickName = Nickname
            };
            return RedirectToAction("Rezerwacja", "Reservation", viewModel);
        }


        [HttpPost]
        public ActionResult SerchPlane(string PlaneName, string Name, string NickName)
        {

            return RedirectToAction("Index", new { PlaneName = PlaneName, All = false, Name = Name, NickName = NickName });
        }


        public ViewResult ChangeUserRole(string Name , string NickName)
        {
            List<string> output = new List<string>();

            foreach (var user in userRepository.Users)
            {
                if(user.Role != "Admin" && user.Role != "Mechanic")
                output.Add(user.Name);
            }

            SelectList list = new SelectList(output);

            UsersList usersList = new UsersList
            {
                UserList = list , Name = Name , NickName = NickName
            };

            return View(usersList);
        }

        [HttpPost]
        public ActionResult ChangeUserRole(string Name, string AdminName, string AdminNickname)
        {

            userRepository.ChangeRoleOfUserToMechanic(Name);

            return RedirectToAction("ChangeUserRole" , new { Name = AdminName , NickName = AdminNickname });
        }


        public ActionResult AddManuallyUser(string Name , string NickName)
        {
            PlaneListViewModel viewModel = new PlaneListViewModel {

                Name = Name , NickName = NickName

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddManuallyUser(string NameOfUser, string FirstName, string Lastname, string paswd, string secondpaswd, string email , string AdminName , string AdminNickname)
        {

            if (paswd != secondpaswd)
            {
                TempData["AdminMessage"] = "Podano różne od siebie hasła!";
                return RedirectToAction("AddAccount");
            }
            else
            {
                var keyNew = Helper.GeneratePassword(10);
                var password = Helper.EncodePassword(paswd, keyNew);

                userRepository.AddUserToRepository(FirstName + "_" + Lastname, NameOfUser, password, keyNew, email);

                TempData["AdminMessage"] = "Udało się stworzyć konto !";



                return RedirectToAction("AddManuallyUser" , new { Name = AdminName , NickName = AdminNickname});
            }
        }


        public ViewResult DeleteUser(string Name , string Nickname)
        {

            UsersList viewModel = new UsersList
            {
                UserList = userRepository.UserList() , Name = Name , NickName = Nickname
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteUser(string Name, string AdminName, string AdminNickname)
        {

            userRepository.DeleteUser(Name);

            return RedirectToAction("DeleteUser" , new { Name = AdminName, NickName = AdminNickname });
        }

    }
}