using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Viajes_FarSiman.Models
{
    public class Employee
    {
        [Key]

        public int id { get; set; }
        public string fristname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
    }
}
