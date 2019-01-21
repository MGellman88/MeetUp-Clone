using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBelt.Data;
using TheBelt.Models;
using TheBelt.ViewModels;

namespace TheBelt.Controllers {
    public class AuthController : Controller {
        private readonly DataContext _context;

        public AuthController (DataContext context) {
            _context = context;
        }

        [HttpGet ("")]

        public IActionResult Index () {
            return View ();
        }

        [HttpPost ("register")]

        public IActionResult Create (RegistrationViewModel reg) {
            if (!ModelState.IsValid) {
                return View ("Index");
            }
            User userInDB = _context.Users.FirstOrDefault (u => u.EmailAddress == reg.EmailAddress);
            if (userInDB != null) {
                ModelState.AddModelError ("Email", "User already exists");
                return View ("Index");
            }

            PasswordHasher<RegistrationViewModel> hasher = new PasswordHasher<RegistrationViewModel> ();
            string hashedPW = hasher.HashPassword (reg, reg.Password);
            User newUser = new User {
                FirstName = reg.FirstName,
                LastName = reg.LastName,
                EmailAddress = reg.EmailAddress,
                Password = hashedPW,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Users.Add (newUser);
            _context.SaveChanges ();

            return RedirectToAction ("Index");
        }

        [HttpPost ("login")]

        public IActionResult Login (LoginViewModel login) {
            if (!ModelState.IsValid) {
                return View ("Index");
            } else {
                var userInDB = _context.Users.FirstOrDefault (u => u.EmailAddress == login.LoginEmail);
                if (userInDB is null) {
                    ModelState.AddModelError ("LoginEmail", "Invalid Login");
                    return View ("Index");
                } else {
                    var hasher = new PasswordHasher<LoginViewModel> ();
                    var result = hasher.VerifyHashedPassword (login, userInDB.Password, login.LoginPassword);
                    if (result == 0) {
                        ModelState.AddModelError ("LoginPassWord", "Invalid Password");
                        return View ("Index");
                    }
                }
            }
            User loggedIn = _context.Users.FirstOrDefault (u => u.EmailAddress == login.LoginEmail);
           

            var username = loggedIn.FirstName;
            int userid = loggedIn.UserId;
            System.Console.WriteLine (username);
            System.Console.WriteLine (userid);
            HttpContext.Session.SetInt32 ("ID", userid);
            HttpContext.Session.SetString ("Name", username);
            HttpContext.Session.SetString ("loggedin", "true");

            return RedirectToAction ("Dashboard", "Home");
        }

        [HttpGet("logout")]
        public IActionResult logout ()
        {
            HttpContext.Session.Clear();
            return View ("Index");
        }
        
    }
}