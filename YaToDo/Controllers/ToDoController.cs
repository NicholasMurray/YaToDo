using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YaToDo.Models;

namespace YaToDo.Controllers
{
    public class ToDoController : Controller
    {
        public IService _session;

        public ToDoController(IService session)
        {
            this._session = session;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to YaToDo - A Massive Sample!";

            var toDoList = _session.All<ToDos>("", "Title", 0, "*", "");

            return View(toDoList);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {

            return RedirectToAction("Index");
        }


        public ActionResult Search(string searchTerm)
        {
            var toDoList = _session.All<ToDos>("WHERE Title like @0", "Title", 0, "*", args: searchTerm);

            return View(toDoList);
        }

    }
}
