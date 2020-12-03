using System.Linq;
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

        public Setting GetByChiefId(int chiefId)
        {
            return _dbContext.Settings.Where(s => s.ChiefId == chiefId).SingleOrDefault();
        }

        public void Create(Setting setting)
        {
            _dbContext.Settings.Add(setting);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}