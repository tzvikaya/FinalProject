using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SmartCalendar.DB;

namespace SmartCalendar.API.Controllers
{
    public class UsersController : ApiController
    {
        private zvikaEntities db = new zvikaEntities();

        // GET: api/Users
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(string user_password, string user_username)
        {
            var _u = db.Users.Where(u => u.user_username == user_username && u.user_password == user_password);
            if (_u.Count() > 0)
            {
                return Ok(_u.First());
            }
            return NotFound();
        }

        // PUT: api/Users/5
        //update only source id of user
        [ResponseType(typeof(void))]
        [Route]
        public IHttpActionResult PutUsers(int id, int sourceId)
        {
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(users.user_username))
                return BadRequest("USername is required");

            if (db.Users.Where(u => u.user_email == users.user_email).Count() > 0)
                return BadRequest("Email already registered");



            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.user_id }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.user_id == id) > 0;
        }
    }
}