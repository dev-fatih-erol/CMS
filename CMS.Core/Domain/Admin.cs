﻿using System;

namespace CMS.Core.Domain
{
    public class Admin
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}