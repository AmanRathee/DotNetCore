using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
namespace EmployeeManagement.Controllers
{
    public class HomeController:Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
            return View(_employeeRepository.GetAllEmployee());
        }
        public ViewResult Details(int id)
        {
            return View(_employeeRepository.GetEmployee(id));
        }
    }
}
