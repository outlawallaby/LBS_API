using LBS_API.DBContexts;
using LBS_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LBS_API.Repository
{
    public class LoadRepository : ILoadRepository
    {
        private readonly LoadContext _dbContext;

        public LoadRepository(LoadContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void DeleteLoad(int loadId)
        {
            var load = _dbContext.Loads.Find(loadId);
            _dbContext.Loads.Remove(load);
            Save();
        }

        public Load GetLoadById(int loadId)
        {
            var prod = _dbContext.Loads.Find(loadId);
            _dbContext.Entry(prod).Reference(s => s.UnitType).Load();
            return prod;
        }

        public IEnumerable<Load> GetLoads()
        {
            return _dbContext.Loads.Include(s => s.UnitType).ToList();
        }

        public void InsertLoad(Load load)
        {
            _dbContext.Add(load);
            Save();
        }

        public void UpdateLoad(Load load)
        {
            _dbContext.Entry(load).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

    }
}
