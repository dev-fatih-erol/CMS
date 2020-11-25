using System.ComponentModel.DataAnnotations;

namespace CMS.Admin.Web.Models
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Lütfen muhtar tc kimlik numarasını girin")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Lütfen muhtar adını girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen muhtar soyadını girin")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen muhtar kullanıcı adını girin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen muhtar şifresini girin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen köy veya mahalle adını girin")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Lütfen ilçe adını girin")]
        public string District { get; set; }

        [Required(ErrorMessage = "Lütfen şehir adını girin")]
        public string City { get; set; }
    }
}