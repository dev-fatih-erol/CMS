using System;

namespace CMS.Core.Domain
{
    public class Region
    {
        public int Id { get; set; }

        public string Town { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public DateTime CreatedDate { get; set; }


        public Chief Chief { get; set; }
    }
}