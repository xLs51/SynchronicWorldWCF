using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Repository
{
    public class PersonDbRepository
    {
        private readonly SynchronicWorldDbContext _db = new SynchronicWorldDbContext();

        public List<Person> GetAll()
        {
            return _db.Persons.ToList();
        }

        public Person Get(int id)
        {
            return _db.Persons.Find(id);
        }

        public Person Insert(Person person)
        {
            _db.Persons.Add(person);
            _db.SaveChanges();

            return person;
        }

        public Person Edit(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;
            _db.SaveChanges();

            return person;
        }

        public void Remove(Person person)
        {
            _db.Entry(person).State = EntityState.Deleted;
            _db.SaveChanges();
        }
    }
}
