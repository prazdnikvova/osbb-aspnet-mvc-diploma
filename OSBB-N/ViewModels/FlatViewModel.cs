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


        [Display(Name = "Номер квартиры")]
        [Required(ErrorMessage = ("Номер квартиры должен быть заполнен")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Можно вводить только цифры")]
        public string Pib { get; set; }

        [Display(Name = "Номер квартиры")]
        [Required(ErrorMessage = ("Номер квартиры должен быть заполнен")), RegularExpression(@"^[0-9]*$", ErrorMessage = "Можно вводить только цифры")]
        public long FlatIp1 { get; set; }


        [Display(Name = "Имя")]
        [Required(ErrorMessage = ("Studnet Name is required.")), RegularExpression(@"^[0-9а-я]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string FlatName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = ("Studnet Name is required.")), RegularExpression(@"^[а-яА-Я]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string FlatAddress { get; set; }
        

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = ("Studnet Name is required.")), RegularExpression(@"^[а-яА-Я]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "AreaMetr")]
        [Required(ErrorMessage = ("Studnet Name is required.")), RegularExpression(@"^[а-яА-Я]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string AreaMetr { get; set; }

        [Display(Name = "AreaMetr")]
        [Required(ErrorMessage = ("Studnet Name is required.")), RegularExpression(@"^[а-яА-Я]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string CostMetr { get; set; }

        [Display(Name = "AreaMetr")]
        [Required(ErrorMessage = ("Studnet Name is required.")), RegularExpression(@"^[а-яА-Я]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string CostOll { get; set; }

        [Display(Name = "AreaMetr")]
        [Required(ErrorMessage = ("Studnet Name is required.")), RegularExpression(@"^[а-яА-Я]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string CostSubsidy { get; set; }

        [Display(Name = "AreaMetr")]
        [Required(ErrorMessage = ("Studnet Name is required.")), RegularExpression(@"^[а-яА-Я]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string CostPrivilege75 { get; set; }

        [Display(Name = "AreaMetr")]
        [Required(ErrorMessage = ("Studnet Name is required.")), RegularExpression(@"^[а-яА-Я]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string CostPrivilege50 { get; set; }
        




    }
}