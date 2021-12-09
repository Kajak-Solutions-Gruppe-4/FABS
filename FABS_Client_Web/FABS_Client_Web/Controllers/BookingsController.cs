using FABS_Client_Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FABS_Client_Web.Controllers
{
    public class BookingsController : Controller
    {
        //Base url for calling API
        string Baseurl = "https://localhost:44309/api/";
        
        // GET: BookingsController
        //[HttpGet]
        public async Task<ActionResult> Index()
        {
            List<BookingDto> BookingList = new List<BookingDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("bookings?organisationid=1");

                if (res.IsSuccessStatusCode)
                {
                    var BookingResponse = res.Content.ReadAsStringAsync().Result;

                    BookingList = JsonConvert.DeserializeObject<List<BookingDto>>(BookingResponse);
                }
            }

            return View(BookingList);
        }

        // GET: BookingsController/Details/5
        //[HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            List<BookingDto> BookingList = new List<BookingDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"bookings?organisationid=1&personid={id}");

                if (res.IsSuccessStatusCode)
                {
                    var BookingResponse = res.Content.ReadAsStringAsync().Result;

                    BookingList = JsonConvert.DeserializeObject<List<BookingDto>>(BookingResponse);
                }
            }
            return View(BookingList);
        }

        // GET: BookingsController/Create
        //[HttpPost]
        public async Task<ActionResult> Create()
        {
            var itemList = new List<ItemDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //TODO Call new itemList that has been filtered for overlaps/booing times
                HttpResponseMessage res = await client.GetAsync("items?organisationid=1");

                if (res.IsSuccessStatusCode)
                {
                    var itemResponse = res.Content.ReadAsStringAsync().Result;

                    itemList = JsonConvert.DeserializeObject<List<ItemDto>>(itemResponse);
                }
                ViewData["Items"] = itemList;
            }
          
            return View(new BookingDto());
        }

        // POST: BookingsController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookingDto booking)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stringContent = new StringContent(JsonConvert.SerializeObject(booking)); 
                HttpResponseMessage res = await client.PostAsync("bookings?organisationid=1", stringContent);
            }
            return RedirectToAction("Index");
            //try
            //{
                
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: BookingsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingsController/Edit/5
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

        // GET: BookingsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingsController/Delete/5
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
