using Sewit.Contracts;
using Sewit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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
            return IncludeAll();
        }

        public Dress FindById(int id)
        {
            return IncludeAll().Where(d => d.DressId == id).FirstOrDefault();
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
            return _db.Dresses
                .Include(d => d.Top)
                .Include(d => d.Skirt)
                .Include(d => d.Sleeve)
                .ToList();
        }
    }
}
