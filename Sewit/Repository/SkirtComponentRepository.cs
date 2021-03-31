using Sewit.Contracts;
using Sewit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Repository
{
    public class SkirtComponentRepository : ISkirtComponentRepository
    {
        private readonly ApplicationDbContext _db;

        public SkirtComponentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(SkirtComponent entity)
        {
            _db.SkirtComponents.Add(entity);
            return Save();
        }

        public bool Delete(SkirtComponent entity)
        {
            _db.SkirtComponents.Remove(entity);
            return Save();
        }

        public List<SkirtComponent> FindAll()
        {
            return _db.SkirtComponents.ToList();
        }

        public SkirtComponent FindById(int id)
        {
            return _db.SkirtComponents.Find(id);
        }

        public SkirtComponent FindByName(string name)
        {
            return _db.SkirtComponents.Where(s => s.Name == name).FirstOrDefault();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }


        public bool Update(SkirtComponent entity)
        {
            _db.SkirtComponents.Update(entity);
            return Save();
        }
    }
}
