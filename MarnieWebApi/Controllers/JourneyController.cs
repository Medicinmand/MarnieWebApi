using System;
using MarnieWebApi.DbAccess;
using MarnieWebApi.Models;
using System.Collections.Generic;
using System.Web.Http;
namespace MarnieWebApi.Controllers
{
    public class JourneyController : ApiController
    {
        DbJourney db = new DbJourney();

        // GET: api/Journey
        public IEnumerable<Journey> Get()
        {
            return db.GetAllWithRelations();
        }

        // GET: api/Journey/5
        public Journey Get(int id)
        {
            return db.GetWithRelations(id);
        }
        // GET: api/Journey/
        public List<Journey> GetJourneysByRouteAndTime(int routeId,int personId, DateTime myStart, DateTime myStop)
        {
            return db.GetJourneysByRouteAndTime(routeId, personId, myStart, myStop);
        }

        // POST: api/Journey
        public void Post([FromBody]Journey journey)
        {            
            db.Insert(journey);
        }

        // PUT: api/Journey/5
        public void Put([FromBody]Journey journey)
        {
            db.Update(journey);
        }

        // DELETE: api/Journey/5
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}