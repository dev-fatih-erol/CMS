using System.ComponentModel.DataAnnotations;

namespace CMS.Chief.Web.Models
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage = "Lütfen fiyat girin")]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}