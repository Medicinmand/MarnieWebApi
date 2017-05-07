using MarnieWebApi.DbAccess;
using MarnieWebApi.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace MarnieWebApi.Controllers
{
    public class RouteController : ApiController
    {
        DbRoute db = new DbRoute();

        // GET: api/Route
        public IEnumerable<Route> Get()
        {
            return db.GetAllWithRelations();
        }

        // GET: api/Route/5
        public Route Get(int id)
        {
            return db.GetWithRelations(id);
        }

        // POST: api/Route
        public void Post([FromBody]Route route)
        {
            db.Insert(route);
        }

        // PUT: api/Route/5
        public void Put(int id, [FromBody]Route route)
        {
            db.Update(route);
        }

        // DELETE: api/Route/5
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
