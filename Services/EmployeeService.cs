using Session3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session3.Services
{
    public class EmployeeService
    {
        private static ICollection<Employee> employees;

        public EmployeeService()
        {
            employees = new List<Employee>();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == id);
            return employee;
        }

        public bool RemoveEmployee(int id)
        {
            Employee employee = GetEmployee(id);
            if(employee != null)
            {
                employees.Remove(employee);
                return true;
            }
            return false;            
        }

        public void AddEmployee(Employee employee)
        {
            employee.Id = GetNextId();
            employees.Add(employee);
        }

        private int GetNextId()
        {
            var employee = employees.LastOrDefault();
            if(employee != null)
            {
                return employee.Id + 1;
            }return 1;            
        }
    }
}
