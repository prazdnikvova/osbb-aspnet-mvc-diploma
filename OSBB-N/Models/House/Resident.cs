using System.ComponentModel.DataAnnotations;

namespace OSBB_N.Models.House
{
    // Мешканець квартири: власник, член родини або орендар
    public class Resident
    {
        public int ResidentId { get; set; }

        [Required]
        [StringLength(150)]
        public string Pib { get; set; }

        // Зовнішній ключ на квартиру (таблиця Flats)
        public int FlatId { get; set; }
        public Flat Flat { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public bool IsOwner { get; set; }
    }
}