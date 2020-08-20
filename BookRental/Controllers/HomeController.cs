using BookRental.Models;
using BookRental.RepositoryPattern;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace BookRental.Controllers
{
    public class HomeController : Controller
    {

        private GenreRepository genreRepository = new GenreRepository();
        public ActionResult Index()
        {
            return View();
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

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Genre genre = genreRepository.FindById((int)id);

            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);

        }

        //[HttpGet]
      
        public List<Genre> GetGenres()
        {
            return genreRepository.Display();
        }
    }
}