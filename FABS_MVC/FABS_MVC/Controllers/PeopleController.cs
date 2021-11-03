using FABS_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FABS_MVC.Controllers
{
    public class PeopleController : Controller
    {
        private IRestClient _client = new RestClient("https://localhost:44337/api");

        // GET: PeopleController
        public ActionResult Index()
        {
            var request = new RestRequest("people/", RestSharp.DataFormat.Json);
            var response = _client.Execute(request);
            List<Person> peopleList = JsonSerializer.Deserialize<List<Person>>(response.Content);

            ViewData["people"] = peopleList;
            return View();
        }

        // GET: PeopleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeopleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeopleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeopleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
