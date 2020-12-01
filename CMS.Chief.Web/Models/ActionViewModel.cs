using System;

namespace CMS.Chief.Web.Models
{
    public class ActionViewModel
    {
        public int Id { get; set; }

        public long Endeks { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}