using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Viajes_FarSiman.Models
{
    public class Trip_Detail
    {
        [Key]
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("TRIP ID")]
        public int trip_id { get; set; }

        [DisplayName("DISTANCE")]
        public ICollection<int> distance_km { get; set; }

        public ICollection<Employee_Branch> Employee_Branchs { get; set; }

    }
}
