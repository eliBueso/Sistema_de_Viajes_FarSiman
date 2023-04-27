using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Viajes_FarSiman.Models
{
    public class Employee_Branch
    {
        [Key]
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("EMPLOYEE ID")]
        public int employee_id { get; set; }
        [DisplayName("BRANCH ID")]
        public int branch_id { get; set; }
        [DisplayName("DISNTANCE ID")]
        public double distance_km { get; set; }
    }
}
