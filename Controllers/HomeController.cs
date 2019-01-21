using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TheBelt.Data;
using TheBelt.Models;
using TheBelt.ViewModels;
using System.Linq;

namespace TheBelt.Controllers
{
    public class HomeController : Controller {
        private readonly DataContext _context;
        public HomeController (DataContext context) {
            _context = context;
        }

        [HttpGet ("dashboard")]
        public IActionResult Dashboard () {
            if (HttpContext.Session.GetString ("loggedin") == "true") {
                int? userId = HttpContext.Session.GetInt32 ("ID");
                String userName = HttpContext.Session.GetString ("Name");
                System.Console.WriteLine("??????????????????????????????????????");
                System.Console.WriteLine(userId);
                System.Console.WriteLine(userName);
                ViewBag.userName = userName;
                ViewBag.userId = userId;

                User currentUser = _context.Users.SingleOrDefault (user => user.UserId == userId);

                List<Activity> allActivities = _context.Activities
                    .Include (Activity => Activity.Participants)
                    .ThenInclude (participant => participant.Attending)
                    .ToList (); 
                
                List<Participant> attendingParticipants = _context.Participants.Where (join => join.Attending.Equals (currentUser))
                    .ToList ();

                ViewBag.UserId = userId;
                ViewBag.allActivities = allActivities;
                ViewBag.currentUser = currentUser;
                ViewBag.attendingParticipants = attendingParticipants;

                return View ();
            }
            return RedirectToAction ("Index", "Auth");
        }

        [HttpGet("CreateActivity")]
        public IActionResult CreateActivity ()
        {
            return View("CreateActivity");
        }

        [HttpPost("Create")]
        public IActionResult Create (ActivityViewModel activity) {
            if (!ModelState.IsValid) {
                return View ("CreateActivity");
            } else {
                if (activity.Date.Date < DateTime.Today) {
                    ModelState.AddModelError ("Date", "Date cannot be before today's date");
                    return View ("CreateActivity");
                }
                int? userId = HttpContext.Session.GetInt32 ("ID");
                Activity newactivity = new Activity
                {
                    Event = activity.Event,
                    Date = activity.Date,
                    Description = activity.Description,
                    Location = activity.Location,
                    UserId = (int) userId

                };
                _context.Add (newactivity);
                _context.SaveChanges ();
                return RedirectToAction ("Dashboard");
            }
        }

        [HttpGet ("ActivityInfo/{activityID}")]
        public IActionResult ActivityInfo (int activityID) {
            if (HttpContext.Session.GetString ("loggedin") == "true") {
                Activity currentActivity = _context.Activities
                    .Include (activity => activity.Participants)
                    .ThenInclude (participant => participant.Attending)
                    .SingleOrDefault (activity => activity.ActivityId == activityID);
                ViewBag.currentActivity = currentActivity;
                return View ();
            }
            return RedirectToAction ("Index,", "Auth");
        }

        [HttpGet ("join/{ActivityID}")]
        public IActionResult joinActivity (int ActivityId) {
            if (HttpContext.Session.GetString ("loggedin") == "true") {
                User currentUser = _context.Users.SingleOrDefault (user => user.UserId == HttpContext.Session.GetInt32("ID"));

                Activity currentActivity = _context.Activities
                    .Include (activity => activity.Participants)
                    .ThenInclude (participant => participant.Attending)
                    .SingleOrDefault (activity => activity.ActivityId == ActivityId);

                Participant NewParticipant = new Participant 
                {
                    UserId = currentUser.UserId,
                    Attending = currentUser,
                    AcitivityId = currentActivity.ActivityId,
                    Activity = currentActivity
                };
                currentActivity.Participants.Add (NewParticipant);
                _context.SaveChanges ();

                return RedirectToAction ("Dashboard");
            }
            return RedirectToAction ("Index", "Auth");
        }

        [HttpGet ("leave/{activityID}")]
        public IActionResult leaveActivity (int activityID) {
            if (HttpContext.Session.GetString ("loggedin") == "true") {
                User currentUser = _context.Users.SingleOrDefault (user => user.UserId == HttpContext.Session.GetInt32 ("ID"));

                Participant currentParticipant = _context.Participants.SingleOrDefault (join => join.UserId == HttpContext.Session.GetInt32 ("ID") && join.AcitivityId == activityID);

                Activity currentActivity = _context.Activities
                    .Include (activity => activity.Participants)
                    .ThenInclude (participant => participant.Attending)
                    .SingleOrDefault (activity => activity.ActivityId == activityID);

                currentActivity.Participants.Remove (currentParticipant);
                _context.SaveChanges ();

                return RedirectToAction ("Dashboard");
            }
            return RedirectToAction ("Index", "Auth");

        } 

        [HttpGet ("Delete/{activityID}")]
        public IActionResult DeleteActivity (int ActivityId) {
            if (HttpContext.Session.GetString ("loggedin") == "true") {
                Activity currentActivity = _context.Activities.SingleOrDefault (activity => activity.ActivityId == ActivityId);
                _context.Activities.Remove (currentActivity);
                _context.SaveChanges ();
                return RedirectToAction ("Dashboard");
            }
            return RedirectToAction ("Dashboard");
        }
        
    }
}
