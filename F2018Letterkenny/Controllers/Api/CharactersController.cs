using F2018Letterkenny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace F2018Letterkenny.Controllers.Api
{
    [Route("api/[controller]")]
    public class CharactersController : ApiController
    {
        private DatabaseModel db;

        //constructor - connect to db as soon as this controller is instantiated
        public CharactersController(DatabaseModel db)
        {
            this.db = db;
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return db.Characters.OrderBy(a => a.Name).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Character character = db.Characters.SingleOrDefault(a => a.CharacterId == id);

            if (character == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(character);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                db.Entry(character).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", character);
            }
        }
    }
}