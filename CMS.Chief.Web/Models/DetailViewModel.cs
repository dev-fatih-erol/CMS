﻿using System.Collections.Generic;

namespace CMS.Chief.Web.Models
{
    public class DetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string CounterNumber { get; set; }

        public List<ActionViewModel> Actions { get; set; }
    }
}