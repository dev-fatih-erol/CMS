using System.ComponentModel.DataAnnotations;

namespace CMS.Chief.Web.Models
{
    public class ReadViewModel
    {
        [Required(ErrorMessage = "Lütfen endeks girin")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Lütfen geçerli endeks girin")]
        public long Endeks { get; set; }

        public string Description { get; set; }
    }
}