using System;
using MarnieWebApi.DbAccess;
using MarnieWebApi.Models;
using System.Collections.Generic;
using System.Web.Http;
namespace MarnieWebApi.Controllers
{
    public class JorneyController : ApiController
    {
        DbJorney db = new DbJorney();

        // GET: api/Jorney
        public IEnumerable<Jorney> Get()
        {
            return db.GetAllWithRelations();
        }

        // GET: api/Jorney/5
        public Jorney Get(int id)
        {
            return db.GetWithRelations(id);
        }
//        // GET: api/Jorney/
//        public List<Jorney> GetJorneysByRouteAndTime(Jorney myJorney)
//        {
//            return db.GetJorneysByRouteAndTime(myJorney);
//        }

        // POST: api/Jorney
        public List<Jorney> Post(Jorney myJorney)
        {
            db.Insert(myJorney);
            return db.GetJorneysByRouteAndTime(myJorney);
        }

        // PUT: api/Jorney/5
        public void Put([FromBody]Jorney jorney)
        {
            db.Update(jorney);
        }

        // DELETE: api/Jorney/5
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}