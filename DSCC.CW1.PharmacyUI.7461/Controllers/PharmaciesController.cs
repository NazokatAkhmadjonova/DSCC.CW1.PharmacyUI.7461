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
    public class PharmaciesController : Controller
    {
        string MainURL = "https://localhost:5001/";
        // GET: Pharmacies
        public async Task<ActionResult> Index()
        {            
            List<Pharmacy> PharInfo = new List<Pharmacy>();
            using (var client = new HttpClient())
            {
                //Passing service base url 
                client.BaseAddress = new Uri(MainURL);
                client.DefaultRequestHeaders.Clear();
                //Define request data format 
                client.DefaultRequestHeaders.Accept.Add(new
               MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Response = await client.GetAsync("api/Pharmacy");
                //Checking the response is successful or not which is sent using HttpClient
                if (Response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api 
                    var PhResponse = Response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Pharmacy list
                    PharInfo = JsonConvert.DeserializeObject<List<Pharmacy>>(PhResponse);
                }
                //returning the Pharmacy list to view 
                return View(PharInfo);
            }
        }

     /*   // GET: Pharmacies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy pharmacy = db.Pharmacies.Find(id);
            if (pharmacy == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy);
        }

        // GET: Pharmacies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pharmacies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City,District,Street")] Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                db.Pharmacies.Add(pharmacy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pharmacy);
        }

        // GET: Pharmacies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy pharmacy = db.Pharmacies.Find(id);
            if (pharmacy == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy);
        }

        // POST: Pharmacies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City,District,Street")] Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pharmacy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pharmacy);
        }

        // GET: Pharmacies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy pharmacy = db.Pharmacies.Find(id);
            if (pharmacy == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy);
        }

        // POST: Pharmacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pharmacy pharmacy = db.Pharmacies.Find(id);
            db.Pharmacies.Remove(pharmacy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
