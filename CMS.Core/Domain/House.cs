using System;

namespace CMS.Core.Domain
{
    public class House
    {
        public int Id { get; set; }

        public string IdentificationNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string CounterNumber { get; set; }

        public DateTime CreatedDate { get; set; }


        public int ChiefId { get; set; }

        public Chief Chief { get; set; }
    }
}