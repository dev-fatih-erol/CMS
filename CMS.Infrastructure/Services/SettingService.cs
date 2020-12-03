using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public class SettingService : ISettingService
    {
        private readonly ApplicationDbContext _dbContext;

        public SettingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Setting setting)
        {
            _dbContext.Settings.Add(setting);
            _dbContext.SaveChanges();
        }
    }
}