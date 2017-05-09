using System;
using MarnieWebApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MarnieWebApi.DbAccess
{
    public class DbRoute
    {
        public void Delete(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var route = new Route { Id = id };
                    db.Routes.Attach(route);
                    db.Routes.Remove(route);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public Route Get(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Routes.Find(id);
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Route> GetAll()
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Routes.ToList();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public ICollection<Route> GetAllWithRelations()
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Routes.Include(x => x.Stops.Select(y => y.Station)).ToList();
                }
                catch (System.Exception e)
                {

                    throw e;
                }
            }
        }

        public ICollection<Route> FindRoute(string from, string to, DateTime startTime)
        {
            List<Route> routes = new List<Route>();
            using (var db = new MyDbContext())
            {
                try
                {
                    var tempList = db.Routes.Include(x => x.Stops).ToList();
                    foreach (var item in tempList)
                    {
                        var station1 = item.Stops.Select(stop => stop.Station.Name.Equals(from));
                    }

                    return routes;
                }
                catch (System.Exception e)
                {

                    throw e;
                }
            }
        }

        public Route GetWithRelations(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Routes.Where(x => x.Id == id).Include(x => x.Stops).FirstOrDefault();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        public void Insert(Route item)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    db.Routes.Add(item);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }

            }
        }

        public void Update(Route item)
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