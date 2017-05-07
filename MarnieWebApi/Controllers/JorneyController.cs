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

        // POST: api/Jorney
        public void Post([FromBody]Jorney jorney)
        {
            db.Insert(jorney);
        }

        // PUT: api/Jorney/5
        public void Put(int id, [FromBody]Jorney jorney)
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