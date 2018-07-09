using AeroKlub.UI.Infrastructure.Abstract;
using AeroKlub.UI.Models;
using AreoKlub.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Controllers
{

    public class LoginController : Controller
    {
        IUsersRepository repository;
        IAuthProvider authProvider;

        public LoginController(IAuthProvider auth, IUsersRepository repo)
        {
            authProvider = auth;
            repository = repo;
        }

        public ViewResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (String.IsNullOrWhiteSpace(model.Login) != true && String.IsNullOrWhiteSpace(model.Password) != true)
            {
                if (authProvider.Authenticate(model.Login, model.Password))
                {
                    foreach (var user in repository.Users)
                    {
                        if (model.Login == user.Username)
                        {
                            if (user.Role == "Admin") {
                                return RedirectToAction("Index", "Admin", new { Name = repository.GetSpecificName(model.Login).Name, NickName = model.Login });
                            }

                            else if (user.Role == "Mechanic") {
                                return RedirectToAction("Index", "Mechanic", new { Name = repository.GetSpecificName(model.Login).Name, NickName = model.Login });
                            }

                            else /*(user.Role == "User")*/{
                                return RedirectToAction("Index", "User", new { Name = repository.GetSpecificName(model.Login).Name, NickName = model.Login });
                            }
                        }
                    }
                }
                ViewBag.Message = "Błędny login lub hasło!";
            }
            return View();
        }

        public ViewResult AddAccount()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddAccountToRepository(string Name , string NickName , string paswd , string email)
        {
            throw new Exception(Name + NickName + paswd + email);
        }

    }
}