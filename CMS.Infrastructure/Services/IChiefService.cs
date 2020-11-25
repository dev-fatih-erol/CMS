using System.Collections.Generic;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public interface IChiefService
    {
        List<Chief> GetAll();

        void Create(Chief chief);
    }
}