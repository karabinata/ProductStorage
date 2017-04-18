namespace ProductStorage.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Data;
    using Models;
    using ViewModels.Category;

    public class CategoryController : Controller
    {
        private ProductStorageContext db = new ProductStorageContext();

        // GET: Category
        public ActionResult Index(int? storageID = null)
        {
            if (storageID != null)
            {
                var categories =
                    Mapper.Instance.Map<List<CategoryListViewModel>>(
                        db.Categories.Where(c => c.StorageId == storageID).Include(c => c.ParentCategory)
                            .Include(c => c.Storage)
                            .ToList());
                return View(categories);
            }
            else
            {
                var categories =
                    Mapper.Instance.Map<List<CategoryListViewModel>>(
                        db.Categories.Include(c => c.Storage)
                            .ToList());
                return View(categories);
            }
        }

        // GET: Category/Details/5
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

            var category = Mapper.Instance.Map<DetailsCategoryViewModel>(db.Categories.Find(id));


            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }


            ViewBag.ParentCategoryId = new SelectList(CategoriesAsListItems(), "Value", "Text");
            ViewBag.StorageId = new SelectList(db.Storages, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,ParentCategoryId,StorageId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.ParentCategoryId = new SelectList(CategoriesAsListItems(), "Value", "Text");
            ViewBag.StorageId = new SelectList(db.Storages, "Id", "Name", category.StorageId);

            return View(category);
        }

        // GET: Category/Edit/5
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

            Category category = db.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            ViewBag.ParentCategoryId = new SelectList(CategoriesAsListItems(category.Id), "Value", "Text", category.ParentCategoryId);
            ViewBag.StorageId = new SelectList(db.Storages, "Id", "Name", category.StorageId);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ParentCategoryId,StorageId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.ParentCategoryId = new SelectList(CategoriesAsListItems(), "Value", "Text", category.ParentCategoryId);
            ViewBag.StorageId = new SelectList(db.Storages, "Id", "Name", category.StorageId);

            return View(category);
        }

        // GET: Category/Delete/5
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

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> CategoriesAsListItems(int? currentCategoryId = null)
        {
            SelectListItem item;
            List<SelectListItem> categories = new List<SelectListItem>();
            item = new SelectListItem();
            item.Text = "No parent category";
            categories.Add(item);

            foreach (var c in db.Categories.Where(c => c.Id != currentCategoryId))
            {
                item = new SelectListItem();
                item.Text = c.Name;
                item.Value = c.Id.ToString();
                categories.Add(item);
            }

            return categories;
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
