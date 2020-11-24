using System.ComponentModel.DataAnnotations;

namespace CMS.Admin.Web.Models
{
    public class IndexViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı girin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter uzunluğunda olmalıdır")]
        public string Password { get; set; }
    }
}