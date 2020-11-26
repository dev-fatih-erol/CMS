using System;
using System.Collections.Generic;

namespace CMS.Core.Domain
{
    public class Chief
    {
        public int Id { get; set; }

        public string IdentificationNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Town { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public DateTime CreatedDate { get; set; }


        public List<House> House { get; set; }
    }
}