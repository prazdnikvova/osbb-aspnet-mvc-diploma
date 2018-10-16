using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OSBB_N.ViewModels
{
    public class ResidentViewModel
    {
        public int ResidentId { get; set; }

        [Display(Name = "ПІБ")]
        [Required(ErrorMessage = "Обов'язково")]
        [StringLength(150, ErrorMessage = "ПІБ не може бути довшим за 150 символів")]
        [RegularExpression(@"^[а-яА-Я іїєґІЇЄҐ'’-]*$", ErrorMessage = "Введіть ПІБ мешканця українськими літерами")]
        public string Pib { get; set; }

        [Display(Name = "Квартира")]
        [Required(ErrorMessage = "Оберіть квартиру")]
        [Range(1, int.MaxValue, ErrorMessage = "Оберіть квартиру")]
        public int FlatId { get; set; }

        [Display(Name = "Телефон")]
        [StringLength(20, ErrorMessage = "Номер телефону не може бути довшим за 20 символів")]
        [RegularExpression(@"^[0-9+() -]*$", ErrorMessage = "Номер телефону може містити лише цифри, пробіли, дужки, «+» і «-»")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(100, ErrorMessage = "Адреса e-mail не може бути довшою за 100 символів")]
        [EmailAddress(ErrorMessage = "Введіть правильну адресу e-mail")]
        public string Email { get; set; }

        [Display(Name = "Власник квартири")]
        public bool IsOwner { get; set; }

        // Квартири для випадного списку у формі
        public IEnumerable<SelectListItem> Flats { get; set; }
    }
}