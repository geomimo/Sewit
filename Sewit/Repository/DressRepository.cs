using Sewit.Contracts;
using Sewit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Repository
{
    public class DressRepository : IDressRepository
    {
        private readonly ApplicationDbContext _db;

        public DressRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Dress entity)
        {
            _db.Dresses.Add(entity);
            return Save();           
        }

        public bool Delete(Dress entity)
        {
            _db.Dresses.Add(entity);
            return Save();
        }

        public List<Dress> FindAll()
        {
            return _db.Dresses.ToList();
        }

        public Dress FindById(int id)
        {
            return _db.Dresses.Find(id);
        }

        public Dress FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }


        public bool Update(Dress entity)
        {
            _db.Dresses.Update(entity);
            return Save();
        }

        private List<Dress> IncludeAll()
        {
            throw new NotImplementedException();
        }
    }
}
