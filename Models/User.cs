using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Viajes_FarSiman.Models
{
    public class User
    {
        [Key]

        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string role  { get; set; }
    }
}
