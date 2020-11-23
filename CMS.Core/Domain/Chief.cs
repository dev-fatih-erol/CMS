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

        public DateTime CreatedDate { get; set; }


        public int RegionId { get; set; }

        public Region Region { get; set; }


        public List<House> House { get; set; }
    }
}