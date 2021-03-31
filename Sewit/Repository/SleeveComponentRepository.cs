using Sewit.Contracts;
using Sewit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Repository
{
    public class SleeveComponentRepository : ISleeveComponentRepository
    {
        private readonly ApplicationDbContext _db;

        public SleeveComponentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(SleeveComponent entity)
        {
            _db.SleeveComponents.Add(entity);
            return Save();
        }

        public bool Delete(SleeveComponent entity)
        {
            _db.SleeveComponents.Remove(entity);
            return Save();
        }

        public List<SleeveComponent> FindAll()
        {
            return _db.SleeveComponents.ToList();
        }

        public SleeveComponent FindById(int id)
        {
            return _db.SleeveComponents.Find(id);
        }

        public SleeveComponent FindByName(string name)
        {
            return _db.SleeveComponents.Where(s => s.Name == name).FirstOrDefault();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }


        public bool Update(SleeveComponent entity)
        {
            _db.SleeveComponents.Update(entity);
            return Save();
        }
    }
}
