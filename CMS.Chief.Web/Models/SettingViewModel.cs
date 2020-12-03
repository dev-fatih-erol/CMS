using System.ComponentModel.DataAnnotations;

namespace CMS.Chief.Web.Models
{
    public class SettingViewModel
    {
        [Required(ErrorMessage = "Lütfen bölgeye ait suyun m³ fiyatını girin")]
        public decimal Price { get; set; }
    }
}