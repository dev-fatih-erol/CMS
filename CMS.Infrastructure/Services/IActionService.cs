using System.Collections.Generic;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public interface IActionService
    {
        Action GetLastByHouseId(int houseId, Type type);

        List<Action> GetByHouseId(int houseId);

        void Create(Action action);
    }
}