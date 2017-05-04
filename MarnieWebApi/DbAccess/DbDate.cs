using MarnieWebApi.Models;
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
                var date = new Date { Id = id };
                db.Dates.Attach(date);
                db.Dates.Remove(date);
                db.SaveChanges();
            }
        }

        public ICollection<Date> GetAllWithRelations()
        {
            using (var db = new MyDbContext())
            {
                return db.Dates.Include(p => p.PersonDates).ToList();
            }
        }

        public Date GetWithRelations(int id)
        {
            using (var db = new MyDbContext())
            {
                return db.Dates.Where(p => p.Id == id).Include(p => p.PersonDates).FirstOrDefault();
            }
        }

        public void Insert(Date item)
        {
            using (var db = new MyDbContext())
            {
                db.Dates.Add(item);
                db.SaveChanges();
            }
        }

        public void Update(Date item)
        {
            using (var db = new MyDbContext())
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}