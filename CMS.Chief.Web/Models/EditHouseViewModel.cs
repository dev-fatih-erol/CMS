using System.ComponentModel.DataAnnotations;

namespace CMS.Chief.Web.Models
{
    public class EditHouseViewModel
    {
        [Required(ErrorMessage = "Lütfen kimlik numarasını girin")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Lütfen adını girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadını girin")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen adresi girin")]
        public string Address { get; set; }
    }
}