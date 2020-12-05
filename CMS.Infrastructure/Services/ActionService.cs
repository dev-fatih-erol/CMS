using System.Collections.Generic;
using System.Linq;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public class ActionService : IActionService
    {
        private readonly ApplicationDbContext _dbContext;

        public ActionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Action GetLastByHouseId(int houseId, Type type)
        {
            return _dbContext.Actions.Where(a => a.HouseId == houseId && a.Type == type)
                                     .OrderByDescending(a => a.CreatedDate)
                                     .First();
        }

        public List<Action> GetByHouseId(int houseId)
        {
            return _dbContext.Actions.Where(a => a.HouseId == houseId).OrderByDescending(a => a.CreatedDate).ToList();
        }

        public List<Action> GetAll(int houseId)
        {
            return _dbContext.Actions.Where(a => a.HouseId == houseId).ToList();
        }

        public void Create(Action action)
        {
            _dbContext.Actions.Add(action);
            _dbContext.SaveChanges();
        }
    }
}