using Employee.DomainModel;
using Employee.Repository;
using Employee.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Tests
{
    [TestClass]
    public class EmployeeRepoTest
    {
        IEmployee objEmployeeRepo;

        [TestMethod]
        public void addEmployeeTest()
        {
            objEmployeeRepo = new EmployeeRepository();

            int id = objEmployeeRepo.addEmployee(new Employees() { Name = "Ajju", Gender = "M", Designation = "Laravel Developer", DepartmentId = 4 });

            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void editAndGetEmployeeByIdTest()
        {
            //in this test case we will test two methods, First Is getEmployeeById method and Second is editEmployee.

            //Arrange
            objEmployeeRepo = new EmployeeRepository();
            Employees objEmployee = objEmployeeRepo.getEmployeeById(1); //get Employee whose EmployeeId is 3.
            objEmployee.Name = "Jignesh R Solanki";

            //Act
            int res = objEmployeeRepo.editEmployee(objEmployee);

            //Assert
            Assert.IsTrue(res > 0);

        }

        [TestMethod]
        public void deleteEmployeeTest()
        {
            //Arrange
            objEmployeeRepo = new EmployeeRepository();
            Employees objEmployee = objEmployeeRepo.getEmployeeById(3);

            //Act
            int res = objEmployeeRepo.deleteEmployee(objEmployee);


            //Assert
            Assert.IsTrue(res > 0);
        }

        [TestMethod]
        public void getAllEmployeesTest()
        {
            //Arrange
            objEmployeeRepo = new EmployeeRepository();

            //Act
            List<Employees> lstEmployees = objEmployeeRepo.getAllEmployees();

            //Assert
            Assert.IsNotNull(lstEmployees);
        }

    }
}
