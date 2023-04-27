using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Viajes_FarSiman.Models
{
    public class Driver
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public float rate_km { get; set; }
    }
}
