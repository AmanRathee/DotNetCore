using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>() {
                                                    new Employee(){Id=1,Name="Neeti",Department="Teching",Email="gjhgjh@hghg.com" },
                                                    new Employee(){Id=2,Name="Aman",Department="IT",Email="gjhgjh@hghg.com" },
                                                    new Employee(){Id=3,Name="Kridha",Department="Fun",Email="gjhgjh@hghg.com" }
                                                 };

        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == Id);
        }
    }
}
