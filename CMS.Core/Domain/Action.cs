﻿using System;

namespace CMS.Core.Domain
{
    public class Action
    {
        public int Id { get; set; }

        public long Endeks { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Type Type { get; set; }

        public DateTime CreatedDate { get; set; }


        public int HouseId { get; set; }

        public House House { get; set; }
    }
}