namespace ProductStorage.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Data;
    using Models;

    public class OfferController : Controller
    {
        private ProductStorageContext db = new ProductStorageContext();

        // GET: Offer
        public ActionResult Index()
        {
            var offers = db.Offers.Include(o => o.Author).Include(o => o.Client);
                       
            return View(offers.ToList());
        }

        // GET: Offer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");

            var products = new Dictionary<string, int>();

            foreach (var p in db.Products.Select(p => p.Name))
            {
                products.Add(p, 0);
            }


            ViewBag.Products = products;

            return View();
        }

        // POST: Offer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Discount,ClientId,AuthorId")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                db.Offers.Add(offer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Email", offer.AuthorId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", offer.ClientId);
            return View(offer);
        }

        // GET: Offer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Email", offer.AuthorId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", offer.ClientId);
            return View(offer);
        }

        // POST: Offer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Discount,ClientId,AuthorId")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Email", offer.AuthorId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", offer.ClientId);
            return View(offer);
        }

        // GET: Offer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: Offer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offer offer = db.Offers.Find(id);
            db.Offers.Remove(offer);
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
        }
    }
}
