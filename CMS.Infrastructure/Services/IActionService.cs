using System.Collections.Generic;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public interface IActionService
    {
        List<Action> GetAll();

        void Create(Action action);
    }
}