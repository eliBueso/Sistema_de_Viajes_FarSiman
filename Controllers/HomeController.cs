using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistema_de_Viajes_FarSiman.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Sistema_de_Viajes_FarSiman.Models.Conection;

namespace Sistema_de_Viajes_FarSiman.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public Employee_Branch searchEmployeeBranch(int id)
        {
            Employee_Branch employee_Branch = new Employee_Branch();
            using (Conection db = new Conection())
            {
                employee_branch employee_branchs = db.Employee_branch.Find(id);

                employee_Branch.id = employee_branchs.id;
                employee_Branch.employee_id = employee_branchs.employee_id;
                employee_Branch.branch_id = employee_branchs.branch_id;
                employee_Branch.distance_km = employee_branchs.distance_km;
            }
            return employee_Branch;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            using (Conection db = new Conection()) 
            {
                var verifiedUser = db.Users.FirstOrDefault(u => u.name==user.name && u.password==user.password);
                if (verifiedUser != null)
                {
                    return RedirectToAction("Privacy");
                }

                TempData["mensaje"] = "User or Password incorrect";
                return RedirectToAction("Index");
            }
        }

        public IActionResult EmployeeBranchTable() {

            using (Conection db = new Conection()) {

                var EmpoyeeBranchs = db.Employee_branch.Select(eb => new Employee_Branch
                {
                    id = eb.id,
                    employee_id = eb.employee_id,
                    branch_id = eb.branch_id,
                    distance_km = eb.distance_km,
                }).ToList();
                return View(EmpoyeeBranchs);
            }
            
        }


        public IActionResult CreateEmployeBranch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployeBranch(Employee_Branch employee_branch)
        {
            try
            {
                using (Conection db = new Conection())
                {
                    var verifiedEmployee_branch = db.Employee_branch.FirstOrDefault(eb => eb.id == employee_branch.id);

                    if (verifiedEmployee_branch == null)
                    {
                        employee_branch employee_Branch = new employee_branch();

                        employee_Branch.id = employee_branch.id;
                        employee_Branch.employee_id = employee_branch.employee_id;
                        employee_Branch.branch_id = employee_branch.branch_id;
                        employee_Branch.distance_km = employee_branch.distance_km;

                        db.Employee_branch.Add(employee_Branch);

                        int filasAfectadas = db.SaveChanges();
                        if (filasAfectadas > 0)
                        {
                            ViewBag.ShowSuccessMessage = true;
                            return RedirectToAction("EmployeeBranchTable");
                        }
                        else
                        {
                            Console.WriteLine("Hubo un error");
                            ViewBag.resCreate = 1;
                            return View();
                        }
                    }
                }
                return RedirectToAction("EmployeeBranchTable");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al acceder a la base de datos: " + ex.InnerException.Message;
                return View();
            }
          
        }
        public IActionResult EditEmployeBranch(int id)
        {
            Employee_Branch found = this.searchEmployeeBranch(id);

            return View(found);
        }
        [HttpPost]
        public IActionResult EditEmployeBranch(Employee_Branch employee_branchs)
        {
            using (Conection db = new Conection())
            {
                employee_branch employee_Branch = db.Employee_branch.Find(employee_branchs.id);
                employee_Branch.id = employee_branchs.id;
                employee_Branch.employee_id = employee_branchs.employee_id;
                employee_Branch.branch_id = employee_branchs.branch_id;
                employee_Branch.distance_km = employee_branchs.distance_km;

                int filas = db.SaveChanges();
                if (filas > 0)
                    Console.WriteLine("Modificado");
                else
                {
                    Console.WriteLine("Hubo un error");
                    return View(employee_branchs);
                }
            }
            return RedirectToAction("EmployeeBranchTable");
        }
        public IActionResult DeleteEmployeBranch(int id)
        {
            Employee_Branch found = this.searchEmployeeBranch(id);

            return View(found);
        }

        [HttpPost, ActionName("DeleteEmployeBranch")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployeBranchs(int id)
        {
            try { 
                using (Conection db = new Conection())
                {
                    employee_branch employee_Branch = db.Employee_branch.Find(id);
                    db.Employee_branch.Remove(employee_Branch);
                    int filas = db.SaveChanges();
                    if (filas > 0)
                        Console.WriteLine("Eliminado");
                    else
                    {
                        Console.WriteLine("Hubo un error");
                        Employee_Branch encontrado = this.searchEmployeeBranch(id);
                        return View(encontrado);
                    }
                }
                     return RedirectToAction("EmployeeBranchTable");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al acceder a la base de datos: " + ex.InnerException.Message;
                    return View();
            }

          }


          public IActionResult CreateTrip()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTrip(Trip trip)
        {
            try { 
                using (Conection db = new Conection())
                {
                    var verifiedTrip = db.Trips.FirstOrDefault(t => t.id == trip.id);
            
                    if (verifiedTrip == null)
                    {
                        trips Trip = new();

                        Trip.id = trip.id;
                        Trip.branch_id = trip.branch_id;
                        Trip.driver_id = trip.driver_id;
                        Trip.trip_date = trip.trip_date;
                        Trip.user_id = trip.user_id;

                        db.Trips.Add(Trip);

                        int filasAfectadas = db.SaveChanges();
                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine("Usuario guardado");
                            return RedirectToAction("CreateDetailTrip");
                        }
                        else
                        {
                            Console.WriteLine("Hubo un error");
                            ViewBag.resCreate = 1;
                                return View();
                        }
                    }
                    return RedirectToAction("EmployeeBranchTable");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al acceder a la base de datos: " + ex.InnerException.Message;
                return View();
            }
        }

        public IActionResult CreateDetailTrip()
        {
         
                List<Employee_Branch> Employee_Branch = new List<Employee_Branch>();

                using (Conection db = new Conection())
                {
                    var lastTrip = db.Trips.OrderByDescending(t => t.id).FirstOrDefault();
                    if (lastTrip != null)
                    {
                        var employeeBranchs = db.Employee_branch
                      .Where(eb => eb.branch_id == lastTrip.branch_id)
                      .ToList();

                        foreach (var item in employeeBranchs)
                        {
                            var empBranch = new Employee_Branch()
                            {
                                id = item.id,
                                employee_id = item.employee_id,
                                branch_id = item.branch_id,
                                distance_km = item.distance_km
                            };

                            Employee_Branch.Add(empBranch);
                        }
                    }
                    return View(Employee_Branch);
                }
 
        }

        [HttpPost]
        public IActionResult CreateDetailTrip(IFormCollection form)
        {
            string[] selectedValues = new string[] { };


            if (form.ContainsKey("myCheckbox") && form["myCheckbox"].Count > 0)
            {
                selectedValues = form["myCheckbox"];
            }
            try{ 
                using (Conection db = new Conection())
                {

                    int count = db.Trips_detail.Count() + 1;
                    int i = 0;
                    var lastTrip = db.Trips.OrderByDescending(t => t.id).FirstOrDefault();
                    var employeeBranchs = db.Employee_branch
                   .Where(eb => eb.branch_id == lastTrip.branch_id)
                   .ToList();
                    int filasAfectadas = 0;
           
                    foreach (var value in selectedValues)
                    {
                        int employeeId = int.Parse(value);
                        var employeeBranch = employeeBranchs.FirstOrDefault(eb => eb.employee_id == employeeId);
                        trips_detail Trip_Detail = new();
                        Trip_Detail.id = count + i;
                        Trip_Detail.trip_id = lastTrip.id;
                        Trip_Detail.employee_id = int.Parse(value);
                        Trip_Detail.distance_km = employeeBranch.distance_km;
                        db.Trips_detail.Add(Trip_Detail);
                        filasAfectadas = db.SaveChanges();
                        i++;
                    }


                    if (filasAfectadas > 0)
                    {
                        ViewBag.ShowSuccessMessage = true;
                        return RedirectToAction("Saved");
                    }
                    else
                    {
                        Console.WriteLine("Hubo un error");
                        ViewBag.resCreate = 1;
                        return View();
                    }

                }
            }
             catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al acceder a la base de datos: " + ex.InnerException.Message;
                return View();
            }
        }

        public IActionResult Saved()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
