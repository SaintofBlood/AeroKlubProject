using AeroKlub.UI.Infrastructure;
using AeroKlub.UI.Infrastructure.Abstract;
using AeroKlub.UI.Models;
using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Entities;
using AreoKlub.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        public ViewResult NoPermission()
        {
            return View();
        }

        public ViewResult Login(bool? Clear)
        {

            if(Clear == true) //Usuwanie ciasteczka po wylogowaniu
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)  
                {
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName); 
                    cookie.Domain = FormsAuthentication.CookieDomain;
                    cookie.Path = FormsAuthentication.FormsCookiePath;
                    cookie.Expires = System.DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            if (String.IsNullOrWhiteSpace(model.Login) != true && String.IsNullOrWhiteSpace(model.Password) != true)
             {

                User user = new User();
                SessionContext context = new SessionContext();



                user.Username = model.Login;
                user.Password = model.Password;

                var authenticatedUser = repository.GetByUsernameAndPassword(user);

                if (authenticatedUser != null)
                {
                    context.SetAuthenticationToken(authenticatedUser.Username.ToString(), false, authenticatedUser);

                   
                        if (model.Login == user.Username)
                        {
                            if (authenticatedUser.Role == "Admin")
                            {
                                return RedirectToAction("Index", "Admin", new { Name = repository.GetSpecificName(model.Login).Name, NickName = model.Login, All = false });
                            }

                            else if (authenticatedUser.Role == "Mechanic")
                            {
                                return RedirectToAction("Index", "Mechanic", new { Name = repository.GetSpecificName(model.Login).Name, NickName = model.Login });
                            }

                            else if (authenticatedUser.Role == "User")
                            {
                                return RedirectToAction("Index", "User", new { Name = authenticatedUser.Name, NickName = model.Login, All = false });

                            }
                    
                    }
              
                }
              
            }
                
                ViewBag.Message = "Błędny login lub hasło!";
           // }
  

            return View();

        }

        public ViewResult AddAccount()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddAccountToRepository(string Name , string FirstName, string Lastname, string paswd , string secondpaswd, string email)
        {

            if (paswd != secondpaswd)
            {
                TempData["LoginErrorMessage"] = "Podano różne od siebie hasła!";
                return RedirectToAction("AddAccount");
            }
            else if(String.IsNullOrWhiteSpace(Name) == true && String.IsNullOrWhiteSpace(FirstName) == true && String.IsNullOrWhiteSpace(Lastname) == true && String.IsNullOrWhiteSpace(paswd) == true && String.IsNullOrWhiteSpace(secondpaswd) == true && String.IsNullOrWhiteSpace(email) == true)
            {
                TempData["LoginErrorMessage"] = "Któreś z pól nie zostało wypełnione!";
                return RedirectToAction("AddAccount");
            }
            else
            {

                if(repository.CheckIfUserExist(Name) == true)
                {
                    TempData["LoginErrorMessage"] = "Istnieje już o takiej samej nazwie użytkownik!";
                    return RedirectToAction("AddAccount");
                }

                var keyNew = Helper.GeneratePassword(10);
                var password = Helper.EncodePassword(paswd, keyNew);

                repository.AddUserToRepository(FirstName + "_" + Lastname, Name, password, keyNew , email);
                TempData["LoginErrorMessage"] = "Udało się stworzyć konto ! Od teraz możesz się logować!";
                return RedirectToAction("Login");
            }
        }

    }
}