using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogReg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace LogReg.Controllers
{
    public class HomeController : Controller
    {
        private LoggersContext _context;
    
        public HomeController(LoggersContext context)
        {
            _context = context;
        }
    
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("create")]
        public IActionResult AddLogger(Validations validator)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<Validations> Hasher = new PasswordHasher<Validations>();
                validator.password = Hasher.HashPassword(validator, validator.password);
                Loggers myLogger = new Loggers();
                myLogger.fname = validator.fname;
                myLogger.lname = validator.lname;
                myLogger.email = validator.email;
                myLogger.password = validator.password;
                myLogger.created_at = DateTime.Now;
                myLogger.updated_at = DateTime.Now;
                _context.Add(myLogger);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpGet("Success")]
        public IActionResult Success()
        {
            List<Loggers> allLoggers = _context.loggers.OrderByDescending(p => p.idloggers).ToList();
            ViewBag.allLoggers = allLoggers;
            return View("Success");
        }
        [HttpPost("Login")]
        public IActionResult Login(Logins myLogin)
        {
        if(ModelState.IsValid)
            {
                List<Loggers> AllLogin = _context.loggers.Where(p => p.email == myLogin.email).ToList();
                // Attempt to retrieve a user from your database based on the Email submitted
                // var user = _context.loggers.Where(p => p.email == myLogin.email);
                foreach(var user in AllLogin)
                {
                    if(user != null && myLogin.password != null)
                    {
                        var Hasher = new PasswordHasher<Loggers>();
                        // Pass the user object, the hashed password, and the PasswordToCheck
                        if(0 != Hasher.VerifyHashedPassword(user, user.password, myLogin.password))
                        {
                            return RedirectToAction("Success");
                        }
                    }
                }
                return View("Index");
            }
            return View("Index");
        }
    }
}
