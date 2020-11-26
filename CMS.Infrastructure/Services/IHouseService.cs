using System.Collections.Generic;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public interface IHouseService
    {
        House GetByCounterNumber(string counterNumber);

        List<House> GetAll(int chiefId);

        void Create(House house);
    }
}