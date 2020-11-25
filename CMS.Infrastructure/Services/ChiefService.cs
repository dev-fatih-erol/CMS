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

        public void Create(Chief chief)
        {
            _dbContext.Chiefs.Add(chief);
            _dbContext.SaveChanges();
        }
    }
}