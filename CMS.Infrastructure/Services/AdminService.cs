using System.Linq;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Admin GetByUsernameAndPassword(string username, string password)
        {
            return _dbContext.Admins.Where(a => a.UserName == username && password == a.Password).SingleOrDefault();
        }
    }
}