﻿using MarnieWebApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MarnieWebApi.DbAccess
{
    public class DbDate : DBInterface<Date>
    {
        public void Delete(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var date = new Date { Id = id };
                    db.Dates.Attach(date);
                    db.Dates.Remove(date);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }                
            }
        }

        public ICollection<Date> GetAllWithRelations()
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Dates.Include(p => p.PersonDates).ToList();
                }
                catch (System.Exception e)
                {
                    throw e;
                }                
            }
        }

        public Date GetWithRelations(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Dates.Where(p => p.Id == id).Include(p => p.PersonDates).FirstOrDefault();
                }
                catch (System.Exception e)
                {
                    throw e;
                }                
            }
        }

        public void Insert(Date item)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    db.Dates.Add(item);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }                
            }
        }

        public void Update(Date item)
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