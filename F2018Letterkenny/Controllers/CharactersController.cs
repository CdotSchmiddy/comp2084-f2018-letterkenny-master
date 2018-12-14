using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using F2018Letterkenny.Models;

namespace F2018Letterkenny.Controllers
{
    [Authorize]
    public class CharactersController : Controller
    {
        //private DatabaseModel db = new DatabaseModel();
        private IMockCharacter db;

        public CharactersController()
        {
            this.db = new EFCharacter();
        }

        public CharactersController(IMockCharacter db)
        {
            this.db = db;
        }

        // GET: Characters
        public ActionResult Index()
        {
            var Characters = db.Characters.Include(s => s.Name);
            //return View(db.Characters.ToList());
            return View("Index", Characters.ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            Character character = db.Characters.SingleOrDefault(a => a.CharacterId == id);
            if (character == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            Character character = db.Characters.SingleOrDefault(a => a.CharacterId == id);
            if (character == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharacterId,Name,Description,Photo,Quote")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(character);
        }
    }
}
