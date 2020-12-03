using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public interface ISettingService
    {
        Setting GetByChiefId(int chiefId);

        void Create(Setting setting);

        void SaveChanges();
    }
}