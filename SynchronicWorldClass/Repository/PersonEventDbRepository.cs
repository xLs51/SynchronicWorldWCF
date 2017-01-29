using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Repository
{
    public class PersonEventDbRepository
    {
        private readonly SynchronicWorldDbContext _db = new SynchronicWorldDbContext();

        public List<PersonEvent> GetAll()
        {
            return _db.PersonEvents.ToList();
        }

        public PersonEvent Get(int id)
        {
            return _db.PersonEvents.Find(id);
        }

        public PersonEvent Insert(PersonEvent personEvent)
        {
            _db.PersonEvents.Add(personEvent);
            _db.SaveChanges();

            return personEvent;
        }

        public PersonEvent Edit(PersonEvent personEvent)
        {
            _db.Entry(personEvent).State = EntityState.Modified;
            _db.SaveChanges();

            return personEvent;
        }

        public void Remove(PersonEvent personEvent)
        {
            _db.Entry(personEvent).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public List<PersonEvent> GetByEvent(int id)
        {
            return _db.PersonEvents.Where(pe => pe.EventId == id).ToList();
        }
    }
}
