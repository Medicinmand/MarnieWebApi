using MarnieWebApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MarnieWebApi.DbAccess
{
    public class DbStation : DBInterface<Station>
    {
        public void Delete(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var station = new Station { Id = id };
                    db.Stations.Attach(station);
                    db.Stations.Remove(station);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public Station Get(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Stations.Find(id);
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Station> GetAll()
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Stations.ToList();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Station> GetAllWithRelations()
        {
            return GetAll();           
        }

        public Station GetWithRelations(int id)
        {
            return Get(id);
        }

        public void Insert(Station item)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    db.Stations.Add(item);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }

            }
        }

        public void Update(Station item)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
