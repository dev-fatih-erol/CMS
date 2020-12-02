namespace CMS.Core.Domain
{
    public class Setting
    {
        public decimal Price { get; set; }


        public int ChiefId { get; set; }

        public Chief Chief { get; set; }
    }
}