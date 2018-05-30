using System.ComponentModel.DataAnnotations;

namespace OSBB.ViewModels
{
    public class FlatViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }

        public int Id { get; set; }

        [Display(Name = "Flat Name")]
        [Required(ErrorMessage = ("Flat Name is Requred.")), RegularExpression(@"^[a-zA-Z*$", ErrorMessage ="Only Alphabetic characters are allowed.")]
        public string Name { get; set; }
    }
}