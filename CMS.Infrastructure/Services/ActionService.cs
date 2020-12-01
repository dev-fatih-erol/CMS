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

        public List<Action> GetAll()
        {
            return _dbContext.Actions.ToList();
        }

        public void Create(Action action)
        {
            _dbContext.Actions.Add(action);
            _dbContext.SaveChanges();
        }
    }
}