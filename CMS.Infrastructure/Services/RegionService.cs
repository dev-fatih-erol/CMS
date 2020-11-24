using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public class RegionService : IRegionService
    {
        private readonly ApplicationDbContext _dbContext;

        public RegionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Region region)
        {
            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();
        }
    }
}