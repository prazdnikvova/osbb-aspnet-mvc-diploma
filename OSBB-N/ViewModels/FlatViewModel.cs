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
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[&nbsp;а-яА-Я іїІЇ']*$", ErrorMessage = "Введіть ПІБ власника квантири")]
        public string Pib { get; set; }

        [Display(Name = "Податковий№")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9а]*$", ErrorMessage = "Дозволено водити лише цифри")]
        public long FlatIp1 { get; set; }


        [Display(Name = "Мобілький")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[а-яА-Я 0-9іїІ+)(Ї']*$", ErrorMessage = "Введіть номер власника квантири")]
        public string FlatName { get; set; }

        [Display(Name = "Адреса")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[а-яА-Яі 0-9,їІЇ'-]*$", ErrorMessage = "Введіть адресу квантири")]
        public string FlatAddress { get; set; }
        

        [Display(Name = "Домашній")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[а-яА-Яії ІЇ'0-9]*$", ErrorMessage = "Введіть номер власника квантири")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Площа кв.")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Введіть площу квантири, дозволено водити лише цифри")]
        public int AreaMetr { get; set; }

        [Display(Name = "Ціна за метр")]
        [Required(ErrorMessage = ("Обов'язково")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int CostMetr { get; set; }

        [Display(Name = "Всього")]
        [Required(ErrorMessage = ("1")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int CostOll { get; set; }

        [Display(Name = "Субсидія")]
        [Required(ErrorMessage = ("1")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int CostSubsidy { get; set; }

        [Display(Name = "Пільга 75%")]
        [Required(ErrorMessage = ("1")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int CostPrivilege75 { get; set; }

        [Display(Name = "Пільга 50%")]
        [Required(ErrorMessage = ("1")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public int CostPrivilege50 { get; set; }
        




    }
}