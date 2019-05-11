using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.DomainModel;

namespace Employee.Repository.Interfaces
{
    public interface IEmployee
    {
        int addEmployee(Employees emp);

        int editEmployee(Employees emp);

        int deleteEmployee(Employees emp);

        List<Employees> getAllEmployees();

        Employees getEmployeeById(int empId);
    }
}
