using Employee.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.Interfaces
{
    public interface IDepartment
    {
        int addDepartment(Department dept);

        int editDepartment(Department dept);

        int deleteDepartment(Department dept);

        List<Department> getAllDepartments();

        Department getDepartmentById(int deptId);
    }
}
