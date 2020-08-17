using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BookRental.Models;
using System.Data;

using System.Diagnostics;
using System.Linq;
using System.Net;
using BookRental.RepositoryPattern;
using BookRental.database_Access_layer;

namespace BookRental.Controllers
{
    public class GenreController : Controller
    {
        private GenreRepository genreRepository = new GenreRepository();
        // GET
        public ActionResult Index()
        {
            List<Genre> genres = genreRepository.Display();
            return View(genres);
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genreRepository.Add(genre);

            }

            return View();
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
            }

            Genre genre = genreRepository.FindById((int) id);
            
            if (genre == null)
            {
                return HttpNotFound();
            }
            
            return View(genre);
        }

        public ActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genreRepository.Update(genre);
                return RedirectToAction("Index");
            }

            return View();
        }
        
        public ActionResult Delete(int? id)
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            genreRepository.Remove(id);            
            return RedirectToAction("Index");
        }
    }
}