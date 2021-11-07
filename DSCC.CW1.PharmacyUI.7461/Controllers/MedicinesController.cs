using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DSCC.CW1.PharmacyUI._7461.Data;
using DSCC.CW1.PharmacyUI._7461.Models;
using Newtonsoft.Json;

namespace DSCC.CW1.PharmacyUI._7461.Controllers
{
    public class MedicinesController : Controller
    {
        string MainURL = "https://localhost:5001/";

        //// GET: Medicines
        public async Task<ActionResult> Index()
        {
            List<Medicine> MedInfo = new List<Medicine>();
            using (var client = new HttpClient())
            {
                //Passing service base url 
                client.BaseAddress = new Uri(MainURL);
                client.DefaultRequestHeaders.Clear();
                ////Define request data format 
                client.DefaultRequestHeaders.Accept.Add(new
               MediaTypeWithQualityHeaderValue("application/json"));
                ////Sending request to find web api REST service resource GetAllMedicines using HttpClient
                HttpResponseMessage Response = await client.GetAsync("api/Medicine");
                ////Checking the response is successful or not which is sent using HttpClient
                if (Response.IsSuccessStatusCode)
                {
                    ////Storing the response details recieved from web api 
                    var MedResponse = Response.Content.ReadAsStringAsync().Result;
                    ////Deserializing the response recieved from web api and storing into the Medicine list
                    MedInfo = JsonConvert.DeserializeObject<List<Medicine>>(MedResponse);
                }
                ////returning the Medicine list to view 
                return View(MedInfo);
            }
        }

        //// GET: Medicine/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Medicine st = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MainURL);
                HttpResponseMessage Response = await client.GetAsync("api/Medicine/" + id);
                ////Checking the response is successful or not which is sent using HttpClient
                if (Response.IsSuccessStatusCode)
                {
                    ////Storing the response details recieved from web api 
                    var MedResponse = Response.Content.ReadAsStringAsync().Result;
                    ////Deserializing the response recieved from web api and storing into the Medicine list
                    st = JsonConvert.DeserializeObject<Medicine>(MedResponse);
                }
                else
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }

            return View(st);
        }
        // POST: Medicine/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Medicine med)
        {
            try
            {
                // TODO: Add update logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MainURL);
                    HttpResponseMessage Response = await client.GetAsync("api/Medicine/" + id);
                    Medicine st = null;
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Response.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api 
                        var MedResponse = Response.Content.ReadAsStringAsync().Result;
                        //Deseralizing the response recieved from web api and storing into the Medicine list
                        st = JsonConvert.DeserializeObject<Medicine>(MedResponse);
                    }
                    //med.MedicineCategory = st.MedicinePharmacy;
                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<Medicine>("api/Medicine/" + med.Id, med);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                //return View(st);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        // GET: Medicines/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MainURL);
                HttpResponseMessage Response = await client.GetAsync("api/Medicine/" + id);
                Medicine st = null;
                //Checking the response is successful or not which is sent using HttpClient
                if (Response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api 
                    var MedResponse = Response.Content.ReadAsStringAsync().Result;
                    //Deseralizing the response recieved from web api and storing into the Medicine list
                    st = JsonConvert.DeserializeObject<Medicine>(MedResponse);

                }
                return View(st);
            }
        }


        // GET: Medicines/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Pharmacies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ProductionDate,ExpirationDate,Quantity")] Medicine medicine)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MainURL);
                HttpResponseMessage Response = await client.PostAsJsonAsync("/api/Medicine/", medicine);
                //Checking the response is successful or not which is sent using HttpClient
                if (Response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    return View();
                }
            }
        }


            // GET: Medicines/Delete/5
            public async Task<ActionResult> Delete(int id)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MainURL);
                    HttpResponseMessage Response = await client.GetAsync("api/Medicine/" + id);
                    Medicine st = null;
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Response.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api 
                        var MedResponse = Response.Content.ReadAsStringAsync().Result;
                        //Deseralizing the response recieved from web api and storing into the Medicine list
                        st = JsonConvert.DeserializeObject<Medicine>(MedResponse);

                    }
                    return View(st);
                }
            }

            // POST: Medicines/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> DeleteConfirmed(int id)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MainURL);
                    HttpResponseMessage Response = await client.DeleteAsync("api/Medicine/" + id);
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        return View();
                    }

                }

            }
            /*    protected override void Dispose(bool disposing)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                    base.Dispose(disposing);
                }*/



            /*  public async Task<Medicine> GetMedicineById(int id){
                  var response = await _client.


    }}*/
        }
    }
