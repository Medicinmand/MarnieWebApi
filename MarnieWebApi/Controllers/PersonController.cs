using System;
using MarnieWebApi.DbAccess;
using MarnieWebApi.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace MarnieWebApi.Controllers
{
    public class PersonController : ApiController
    {
        private DbPerson db = new DbPerson();

        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return db.GetAllWithRelations();
        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            return db.GetWithRelations(id);
        }

        // GET: api/Person/5
        public Person GetByAuthId(string authId)
        {
            return db.GetByAuthId(authId);
        }

        //testing how to serach DB.
        public IEnumerable<Person> Get(string name, string name2)
        {
            return db.GetByName(name, name2);
        }

        //GEt: api/Person returs a list of persons by routId and travel time
        public List<Person> GetPersonsByRouteIdAndTime(int routeId, DateTime start, DateTime stop)
        {
            var jc = new JorneyController();
            var jorneyList = jc.GetJorneysByRouteAndTime(routeId, start, stop);

            return db.GetPersonsByRouteIdAndTime(jorneyList);
        }

        // POST: api/Person
        public void Post(Person person)
        {
            db.Insert(person);
        }

        // PUT: api/Person/5
        public void Put(Person person)
        {
            db.Update(person);
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
