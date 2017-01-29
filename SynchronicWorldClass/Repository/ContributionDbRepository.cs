using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Repository
{
    public class ContributionDbRepository
    {
        private readonly SynchronicWorldDbContext _db = new SynchronicWorldDbContext();

        public List<Contribution> GetAll()
        {
            return _db.Contributions.ToList();
        }

        public Contribution Get(int id)
        {
            return _db.Contributions.Find(id);
        }

        public Contribution Insert(Contribution contribution)
        {
            _db.Contributions.Add(contribution);
            _db.SaveChanges();

            return contribution;
        }

        public Contribution Edit(Contribution contribution)
        {
            _db.Entry(contribution).State = EntityState.Modified;
            _db.SaveChanges();

            return contribution;
        }

        public void Remove(Contribution contribution)
        {
            _db.Entry(contribution).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public void RemoveByPerson(int id)
        {
            var contributions = _db.Contributions.Where(c => c.PersonId == id).ToList();
            contributions.ForEach(c => _db.Entry(c).State = EntityState.Deleted);
            _db.SaveChanges();
        }

        public List<Contribution> GetByEvent(int id)
        {
            return _db.Contributions.Where(c => c.EventId == id).ToList();
        }

        public List<Contribution> GetByPerson(int id)
        {
            return _db.Contributions.Where(c => c.PersonId == id).ToList();
        }
    }
}
