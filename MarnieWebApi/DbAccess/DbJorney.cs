using MarnieWebApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MarnieWebApi.DbAccess
{
    public class DbJorney : DBInterface<Jorney>
    {
        public void Delete(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var jorney = new Jorney { Id = id };
                    db.Jorneys.Attach(jorney);
                    db.Jorneys.Remove(jorney);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public Jorney Get(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Jorneys.Find(id);
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Jorney> GetAll()
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Jorneys.ToList();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Jorney> GetAllWithRelations()
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Jorneys.Include(x => x.Person).Include(x => x.Route).ToList();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Jorney> GetDates(Jorney matchJorney)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Jorneys.Where(jor => jor.RouteId == matchJorney.RouteId).Include(x => x.Person).Include(x => x.Route).ToList();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Jorney> FindDates(Jorney jorney)
        {
            List<Jorney> jorneyList = new List<Jorney>();
            using (var db = new MyDbContext())
            {
                try
                {
                    var tempList = db.Jorneys.Include(x => x.Person).Include(x => x.Route).ToList();
                    //TODO
                    return jorneyList;
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public Jorney GetWithRelations(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Jorneys.Where(x => x.Id == id).Include(x => x.Person).Include(x => x.Route).FirstOrDefault();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public void Insert(Jorney item)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    db.Jorneys.Add(item);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }

            }
        }

        public void Update(Jorney item)
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