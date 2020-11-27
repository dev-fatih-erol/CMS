using System.ComponentModel.DataAnnotations;

namespace CMS.Admin.Web.Models
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Lütfen kimlik numarasını girin")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Lütfen adını girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadını girin")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adını girin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifresini girin")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter uzunluğunda olmalıdır")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen köy veya mahalle adını girin")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Lütfen ilçe adını girin")]
        public string District { get; set; }

        [Required(ErrorMessage = "Lütfen şehir adını girin")]
        public string City { get; set; }
    }
}