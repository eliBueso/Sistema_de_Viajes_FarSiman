using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Viajes_FarSiman.Models
{
    public class Trip
    {
        [Key]
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("BRANCH ID")]
        public int branch_id { get; set; }
        [DisplayName("DRIVER ID")]
        public int driver_id { get; set; }
        [DisplayName("TRIPE DATE")]
        public DateTime trip_date { get; set; }
        [DisplayName("USER ID")]
        public int user_id { get; set; }
    }
}
