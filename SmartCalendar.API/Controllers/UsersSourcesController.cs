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
    public class UsersSourcesController : ApiController
    {
        private zvikaEntities db = new zvikaEntities();

        // GET: api/UsersSources
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        // GET: api/UsersSources/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/UsersSources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.user_id)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UsersSources
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            var _user = db.Users.Where(u => u.user_id == users.user_id).First();
            //check if source registered to user
            foreach (var source in users.Users_Sources)
            {
                
               
                if (source.user_id == users.user_id && source.dateRegistered == null)
                {   
                    _user.Users_Sources.Add(new Users_Sources() {
                        user_id = users.user_id,
                        source_id = source.source_id,
                        dateRegistered = DateTime.UtcNow
                    });
                }
                else if (source.user_id == -1)
                {
                    var _s = _user.Users_Sources.Where(s => s.source_id == source.source_id).First();
                    _user.Users_Sources.Remove(_s);

                }
            }
            db.SaveChanges();

            return Ok(_user);
        }

        // DELETE: api/UsersSources/5
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