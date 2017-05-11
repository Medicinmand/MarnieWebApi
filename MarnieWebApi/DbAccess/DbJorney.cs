using System;
using MarnieWebApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;

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

        public List <Jorney> GetJorneysByRouteAndTime(int routeId, DateTime myStart, DateTime myStop)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var jorneys = db.Jorneys.Where(x => x.RouteId == routeId).Include(x => x.Person).Include(x => x.Route).ToList();
                    return jorneys.Where(j => IsBetween(myStart, myStop, j.StartTime, j.EndTime)).ToList();
                    
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

       

        private static bool IsBetween(DateTime myStart, DateTime myStop, DateTime start, DateTime end)
        {
            return (end >= myStart && start <= myStop && end != myStart)|| start == myStart || end == myStop;
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