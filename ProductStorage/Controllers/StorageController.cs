namespace ProductStorage.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using AutoMapper;
    using Data;
    using Models;
    using ViewModels.Storage;

    public class StorageController : Controller
    {
        private ProductStorageContext db = new ProductStorageContext();

        // GET: Storage
        public ActionResult Index()
        {
            return View(db.Storages.ToList());
        }

        // GET: Storage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            Storage storage = db.Storages.Find(id);

            if (storage == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Instance.Map<DetailStorageViewModel>(storage);

            return View(model);
        }

        // GET: Storage/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            return View();
        }

        // POST: Storage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddEditStorageViewModel model)
        {

            if (ModelState.IsValid)
            {
                var count = db.Storages.Count(s => s.Name == model.Name);

                if (count == 0)
                {
                    var storage = Mapper.Instance.Map<Storage>(model);

                    db.Storages.Add(storage);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Storage with the same name already exists! Please choose another name!");
                    return View(model);
                }

            }

            return View(model);
        }

        // GET: Storage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            Storage storage = db.Storages.Find(id);

            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // POST: Storage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Storage model)
        {
            if (ModelState.IsValid)
            {
                var count = db.Storages.Count(s => s.Name == model.Name && s.Id != model.Id);

                if (count == 0)
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Storage with the same name already exists! Please choose another name!");
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: Storage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            Storage storage = db.Storages.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }

            return View(storage);
        }

        // POST: Storage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Storage storage = db.Storages.Find(id);
            db.Storages.Remove(storage);
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
