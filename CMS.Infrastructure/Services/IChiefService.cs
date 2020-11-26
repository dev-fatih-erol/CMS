using System.Collections.Generic;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public interface IChiefService
    {
        Chief GetByUsernameAndPassword(string username, string password);

        List<Chief> GetAll();

        void Create(Chief chief);
    }
}