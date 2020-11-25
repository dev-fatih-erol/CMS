using System.ComponentModel.DataAnnotations;

namespace CMS.Admin.Web.Models
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Lütfen köy veya mahalle adını girin")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Lütfen ilçe adını girin")]
        public string District { get; set; }

        [Required(ErrorMessage = "Lütfen şehir adını girin")]
        public string City { get; set; }
    }
}