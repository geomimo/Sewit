using Sewit.Contracts;
using Sewit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Repository
{
    public class TopComponentRepository : ITopComponentRepository
    {
        private readonly ApplicationDbContext _db;

        public TopComponentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(TopComponent entity)
        {
            _db.TopComponents.Add(entity);
            return Save();
        }

        public bool Delete(TopComponent entity)
        {
            _db.TopComponents.Add(entity);
            return Save();
        }

        public List<TopComponent> FindAll()
        {
            return _db.TopComponents.ToList();
        }

        public TopComponent FindById(int id)
        {
            return _db.TopComponents.Find(id);
        }

        public TopComponent FindByName(string name)
        {
            return _db.TopComponents.Where(t => t.Name == name).FirstOrDefault();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }


        public bool Update(TopComponent entity)
        {
            _db.TopComponents.Update(entity);
            return Save();
        }
    }
}
