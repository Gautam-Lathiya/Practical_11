using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>();
        private static int nextId = 1;

        public ActionResult Index()
        {
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Id = nextId++;
            users.Add(user);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.DateOfBirth = updatedUser.DateOfBirth;
                user.Address = updatedUser.Address;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }
    }
}