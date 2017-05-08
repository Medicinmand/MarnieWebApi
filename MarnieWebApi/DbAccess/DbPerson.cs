using MarnieWebApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MarnieWebApi.DbAccess
{
    public class DbPerson : DBInterface<Person>
    {
        public void Delete(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var person = new Person { Id = id };
                    db.Persons.Attach(person);
                    db.Persons.Remove(person);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }                
            }
        }

        public Person Get(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Persons.Find(id);
                }
                catch (System.Exception e)
                {
                    throw e;
                }                
            }
        }

        public ICollection<Person> GetAll()
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Persons.ToList();
                }
                catch (System.Exception e)
                {
                    throw e;
                }                
            }
        }

        public ICollection<Person> GetAllWithRelations()
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Persons.Include(p => p.Dates).Include(p => p.Jorneys).ToList();
                }
                catch (System.Exception e)
                {

                    throw e;
                }                
            }
        }

        public Person GetWithRelations(int id)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    return db.Persons.Where(p => p.Id == id).Include(p => p.Dates).Include(p => p.Jorneys).FirstOrDefault();
                }
                catch (System.Exception e)
                {
                    throw e;
                }                
            }
        }

        public void Insert(Person item)
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    db.Persons.Add(item);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    throw e;
                }                
            }
        }

        public void Update(Person item)
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