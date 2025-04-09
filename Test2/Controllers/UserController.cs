using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class UserController : Controller
    {
        private static List<User> _users = new List<User>();
        private static int _nextId = 1;

        public ActionResult Index()
        {
            return View(_users);
        }

        public ActionResult Create()
        {
            return PartialView("_Create", new User());
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = _nextId++;
                _users.Add(user);
                return RedirectToAction("Index");
            }
            return PartialView("_Create", user);
        }

        public ActionResult Edit(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return PartialView("_Edit", user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null && ModelState.IsValid)
            {
                existing.Name = user.Name;
                existing.DateOfBirth = user.DateOfBirth;
                existing.Address = user.Address;
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", user);
        }

        public ActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return PartialView("_Delete", user);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", user);
        }
    }
}