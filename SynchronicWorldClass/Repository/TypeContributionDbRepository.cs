using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Repository
{
    public class TypeContributionDbRepository
    {
        private readonly SynchronicWorldDbContext _db = new SynchronicWorldDbContext();

        public List<TypeContribution> GetAll()
        {
            return _db.TypeContributions.ToList();
        }

        public TypeContribution Get(int id)
        {
            return _db.TypeContributions.Find(id);
        }

        public TypeContribution Insert(TypeContribution typeContribution)
        {
            _db.TypeContributions.Add(typeContribution);
            _db.SaveChanges();

            return typeContribution;
        }

        public TypeContribution Edit(TypeContribution typeContribution)
        {
            _db.Entry(typeContribution).State = EntityState.Modified;
            _db.SaveChanges();

            return typeContribution;
        }

        public void Remove(TypeContribution typeContribution)
        {
            _db.Entry(typeContribution).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public TypeContribution GetByName(string name)
        {
            return _db.TypeContributions.Where(tc => tc.Name == name).FirstOrDefault();
        }
    }
}
