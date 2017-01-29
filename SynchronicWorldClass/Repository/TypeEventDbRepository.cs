using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Repository
{
    public class TypeEventDbRepository
    {
        private readonly SynchronicWorldDbContext _db = new SynchronicWorldDbContext();

        public List<TypeEvent> GetAll()
        {
            return _db.TypeEvents.ToList();
        }

        public TypeEvent Get(int id)
        {
            return _db.TypeEvents.Find(id);
        }

        public TypeEvent Insert(TypeEvent typeEvent)
        {
            _db.TypeEvents.Add(typeEvent);
            _db.SaveChanges();

            return typeEvent;
        }

        public TypeEvent Edit(TypeEvent typeEvent)
        {
            _db.Entry(typeEvent).State = EntityState.Modified;
            _db.SaveChanges();

            return typeEvent;
        }

        public void Remove(TypeEvent typeEvent)
        {
            _db.Entry(typeEvent).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public TypeEvent GetByName(string name)
        {
            return _db.TypeEvents.Where(te => te.Name == name).FirstOrDefault();
        }
    }
}
