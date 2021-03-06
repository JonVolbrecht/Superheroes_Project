using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Data;
using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superheroes.Controllers
{
    public class SuperHeroController : Controller
    {
        public ApplicationDbContext _context;

        

        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperHeroController
        public ActionResult Index()
        {

            return View(_context.Superheroes.ToList());
        }

        // GET: SuperHeroController/Details/5
        public ActionResult Details(int id)
        {
            //if null
            Superhero superhero = _context.Superheroes.Find(id);
            //if statement for null
            return View();
        }

        // GET: SuperHeroController/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View();
        }

        // POST: SuperHeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperHeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Superhero superhero = _context.Superheroes.Find(id);
                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
