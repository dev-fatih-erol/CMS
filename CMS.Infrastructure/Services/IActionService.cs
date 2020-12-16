using System.Collections.Generic;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public interface IActionService
    {
        void Delete(Action action);

        Action GetLastByHouseId(int houseId, Type type);

        List<Action> GetByHouseId(int houseId);

        List<Action> GetAll(int houseId);

        void Create(Action action);
    }
}