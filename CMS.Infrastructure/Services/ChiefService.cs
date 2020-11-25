using System.Collections.Generic;
using System.Linq;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public class ChiefService : IChiefService
    {
        private readonly ApplicationDbContext _dbContext;

        public ChiefService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Chief> GetAll()
        {
            return _dbContext.Chiefs.ToList();
        }

        public void Create(Chief chief)
        {
            _dbContext.Chiefs.Add(chief);
            _dbContext.SaveChanges();
        }
    }
}