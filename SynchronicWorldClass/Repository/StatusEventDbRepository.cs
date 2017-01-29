using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Repository
{
    public class StatusEventDbRepository
    {
        private readonly SynchronicWorldDbContext _db = new SynchronicWorldDbContext();

        public List<StatusEvent> GetAll()
        {
            return _db.StatusEvents.ToList();
        }

        public StatusEvent Get(int id)
        {
            return _db.StatusEvents.Find(id);
        }

        public StatusEvent Insert(StatusEvent statusEvent)
        {
            _db.StatusEvents.Add(statusEvent);
            _db.SaveChanges();

            return statusEvent;
        }

        public StatusEvent Edit(StatusEvent statusEvent)
        {
            _db.Entry(statusEvent).State = EntityState.Modified;
            _db.SaveChanges();

            return statusEvent;
        }

        public void Remove(StatusEvent statusEvent)
        {
            _db.Entry(statusEvent).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public StatusEvent GetByName(string name)
        {
            return _db.StatusEvents.Where(se => se.Name == name).FirstOrDefault();
        }
    }
}
