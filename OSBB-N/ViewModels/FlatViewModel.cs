using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OSBB_N.ViewModels
{
    public class FlatViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }


        [Display(Name = "Власника")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[&nbsp;а-яА-Я іїІЇ']*$", ErrorMessage = "Введіть ПІБ")]
        public string Pib { get; set; }

        [Display(Name = "Номер квартиры")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Можно вводить только цифры")]
        public long FlatIp1 { get; set; }


        [Display(Name = "Имя")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[а-яА-Я іїІЇ']*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string FlatName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[а-яА-Яі 0-9,їІЇ']*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string FlatAddress { get; set; }
        

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[а-яА-Яії ІЇ'0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Площа квартири")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int AreaMetr { get; set; }

        [Display(Name = "Ціна за метр")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int CostMetr { get; set; }

        [Display(Name = "Ціна за квартиру")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int CostOll { get; set; }

        [Display(Name = "Ціна з субсидією")]
        [Required(ErrorMessage = ("......")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int CostSubsidy { get; set; }

        [Display(Name = "Ціна з пільгою 75%")]
        [Required(ErrorMessage = (",,,,,")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int CostPrivilege75 { get; set; }

        [Display(Name = "Ціна з пільгою 50%")]
        [Required(ErrorMessage = ("ююююююю.")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int CostPrivilege50 { get; set; }
        




    }
}