using System.Collections.Generic;
using System.Linq;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public class HouseService : IHouseService
    {
        private readonly ApplicationDbContext _dbContext;

        public HouseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public House GetByCounterNumber(string counterNumber)
        {
            return _dbContext.Houses.Where(h => h.CounterNumber == counterNumber).SingleOrDefault();
        }

        public House GetById(int id, int chiefId)
        {
            return _dbContext.Houses.Where(h => h.Id == id && h.ChiefId == chiefId).SingleOrDefault();
        }

        public List<House> GetAll(int chiefId)
        {
            return _dbContext.Houses.Where(h => h.ChiefId == chiefId).ToList();
        }

        public void Create(House house)
        {
            _dbContext.Houses.Add(house);
            _dbContext.SaveChanges();
        }
    }
}