using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Repository
{
    public class EventDbRepository
    {
        private readonly SynchronicWorldDbContext _db = new SynchronicWorldDbContext();

        public List<Event> GetAll()
        {
            return _db.Events.ToList();
        }

        public Event Get(int id)
        {
            return _db.Events.Find(id);
        }

        public Event Insert(Event events)
        {
            _db.Events.Add(events);
            _db.SaveChanges();

            return events;
        }

        public Event Edit(Event events)
        {
            _db.Entry(events).State = EntityState.Modified;
            _db.SaveChanges();

            return events;
        }

        public void Remove(Event events)
        {
            _db.Entry(events).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public List<Event> UpdatePending()
        {
            var events = _db.Events.Where(e => e.StatusEvent.Name == "Pending").ToList();
            var status = _db.StatusEvents.Where(s => s.Name == "Open").FirstOrDefault();

            events.ForEach(e => e.StatusEventId = status.StatusEventId);
            events.ForEach(e => _db.Entry(e).State = EntityState.Modified);
            _db.SaveChanges();

            return events;
        }

        public void RemoveClosed()
        {
            var events = _db.Events.Where(e => e.StatusEvent.Name == "Close").ToList();
            events.ForEach(e => _db.Entry(e).State = EntityState.Deleted);
            _db.SaveChanges();
        }

        public List<Event> GetByName(string name)
        {
            return _db.Events.Where(e => e.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Event> GetByStatus(string name)
        {
            return _db.Events.Where(e => e.StatusEvent.Name == name).ToList();
        }

        public List<Event> GetByType(string name)
        {
            return _db.Events.Where(e => e.TypeEvent.Name == name).ToList();
        }

        public List<Event> GetByDate(DateTime date)
        {
            return _db.Events.Where(e => DbFunctions.TruncateTime(e.Date) == date).ToList();
        }

        public List<Event> GetBetweenDate(DateTime start, DateTime end)
        {
            return _db.Events.Where(e => DbFunctions.TruncateTime(e.Date) >= start && DbFunctions.TruncateTime(e.Date) <= end).ToList();
        }
    }
}
