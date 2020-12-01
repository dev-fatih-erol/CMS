﻿using System.Collections.Generic;
using CMS.Core.Domain;

namespace CMS.Infrastructure.Services
{
    public interface IHouseService
    {
        House GetByCounterNumber(string counterNumber);

        House GetById(int id, int chiefId);

        List<House> GetAll(int chiefId);

        void Create(House house);
    }
}