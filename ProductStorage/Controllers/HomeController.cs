namespace ProductStorage.Controllers
{
    using System.Linq;
    using Data;
    using System.Web.Mvc;
    using ViewModels.Home;

    public class HomeController : Controller
    {
        private ProductStorageContext db = new ProductStorageContext();

        public ActionResult Index()
        {
            var lastesetInformation = new LatestAddedViewModel
            {
                Storages = db.Storages.OrderByDescending(s => s.Id).Take(5).ToList(),
                Categories = db.Categories.OrderByDescending(s => s.Id).Take(5).ToList(),
                Clients = db.Clients.OrderByDescending(s => s.Id).Take(5).ToList(),
                Products = db.Products.OrderByDescending(s => s.Id).Take(5).ToList(),
                Offers = db.Offers.OrderByDescending(s => s.Id).Take(5).ToList(),
                Invoices = db.Invoices.OrderByDescending(s => s.Id).Take(5).ToList(),

            };

            return View(lastesetInformation);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}