using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Sistema_de_Viajes_FarSiman.Models
{
    public class Conection : DbContext
    {

        public string connectionString = @"Data Source=DESKTOP-P9R6KPK;Initial Catalog=FarSiman;Integrated Security=True";
        public DbSet<employee> Employees { get; set; }
        public DbSet<branch> Branchs { get; set; }
        public DbSet<employee_branch> Employee_branch { get; set; }
        public DbSet<users> Users { get; set; }
        public DbSet<trips> Trips { get; set; }
        public DbSet<trips_detail> Trips_detail { get; set; }
        public DbSet<driver> Drivers { get; set; }
     


        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlServer(connectionString);

        public class users
        {
            [Key]

            public int id { get; set; }
            public string name { get; set; }
            public string password { get; set; }
            public string role { get; set; }

        }
        public class employee
        {
            [Key]

            public int id { get; set; }
            public string fristname { get; set; }
            public string lastname { get; set; }
            public string address { get; set; }

        }

        public class branch
        {
            [Key]

            public int id { get; set; }
            public string name { get; set; }
            public string address { get; set; }

        }


        public class employee_branch
        {
            [Key]

            public int id { get; set; }
            public int employee_id { get; set; }
            public int branch_id { get; set; }
            public double distance_km { get; set; }

        }

        public class trips
        {
            [Key]
            public int id { get; set; }
            public int branch_id { get; set; }
            public int driver_id { get; set; }
            public DateTime trip_date { get; set; }
            public int user_id { get; set; }

        }
        public class trips_detail
        {
          
            [Key]
            [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            public int trip_id { get; set; }
            public int employee_id { get; set; }
            public double distance_km { get; set; }

        }

        public class driver
        {
            [Key]
            public int id { get; set; }
            public string name { get; set; }

            public float rate_km { get; set; }
        }

        //public DbSet<Sistema_de_Viajes_FarSiman.Models.Trip> Trip { get; set; }
    }
}
