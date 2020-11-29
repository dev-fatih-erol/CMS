using System;

namespace CMS.Core.Domain
{
    public class Action
    {
        public int Id { get; set; }

        public int Endeks { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Type Type { get; set; }

        public DateTime CreatedDate { get; set; }


        public int ChiefId { get; set; }

        public Chief Chief { get; set; }
    }
}