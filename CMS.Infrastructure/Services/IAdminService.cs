using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public interface IAdminService
    {
        Admin GetByUsernameAndPassword(string username, string password);
    }
}