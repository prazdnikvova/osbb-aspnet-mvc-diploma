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


        [Display(Name = "ПІБ")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[а-яА-Я іїєґІЇЄҐ'’-]*$", ErrorMessage = "Введіть ПІБ власника квартири українськими літерами")]
        public string Pib { get; set; }

        [Display(Name = "Податковий №")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Податковий номер може містити лише цифри")]
        public long FlatIp1 { get; set; }


        [Display(Name = "Мобільний")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[а-яА-Я 0-9іїІ+)(Ї']*$", ErrorMessage = "Введіть номер мобільного телефону власника квартири")]
        public string FlatName { get; set; }

        [Display(Name = "Адреса")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[а-яА-Яі 0-9,.№/їєґІЇЄҐ'’-]*$", ErrorMessage = "Введіть адресу квартири українськими літерами й цифрами")]
        public string FlatAddress { get; set; }
        

        [Display(Name = "Домашній")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[а-яА-Яії ІЇ'0-9]*$", ErrorMessage = "Введіть номер домашнього телефону власника квартири")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Площа кв.")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Введіть площу квартири, дозволено вводити лише цифри")]
        public int AreaMetr { get; set; }

        [Display(Name = "Ціна за метр")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Введіть ціну за метр, дозволено вводити лише цифри")]
        public int CostMetr { get; set; }

        [Display(Name = "Всього")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Сума всього має бути цілим числом")]
        public int CostOll { get; set; }

        [Display(Name = "Субсидія")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Сума із субсидією має бути цілим числом")]
        public int CostSubsidy { get; set; }

        [Display(Name = "Пільга 75%")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Сума з пільгою 75% має бути цілим числом")]
        public int CostPrivilege75 { get; set; }

        [Display(Name = "Пільга 50%")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Сума з пільгою 50% має бути цілим числом")]
        public int CostPrivilege50 { get; set; }
        




    }
}