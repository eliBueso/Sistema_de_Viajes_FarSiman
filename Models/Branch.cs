using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Viajes_FarSiman.Models
{
    public class Branch
    {
        [Key]

        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}
