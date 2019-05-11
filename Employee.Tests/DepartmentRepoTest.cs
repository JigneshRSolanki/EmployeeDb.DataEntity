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
    public class DepartmentRepoTest
    {
        IDepartment objDepartmentRepo;

        [TestMethod]
        public void addDepartmentTest()
        {
            objDepartmentRepo = new DepartmentRepository();

            int id = objDepartmentRepo.addDepartment(new Department() { Name = "IT" });

            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void editAndGetDepartmentByIdTest()
        {
            //in this test case we will test two methods, First Is getDepartmentById method and Second is editDepartment.

            //Arrange
            objDepartmentRepo = new DepartmentRepository();
            Department objDepartment = objDepartmentRepo.getDepartmentById(5); //get department whose DepartmentId is 3.
            objDepartment.Name = "Sales";

            //Act
            int res = objDepartmentRepo.editDepartment(objDepartment);

            //Assert
            Assert.IsTrue(res > 0);

        }

        [TestMethod]
        public void deleteDepartmentTest()
        {
            //Arrange
            objDepartmentRepo = new DepartmentRepository();
            Department objDepartment = objDepartmentRepo.getDepartmentById(3);
            
            //Act
            int res = objDepartmentRepo.deleteDepartment(objDepartment);


            //Assert
            Assert.IsTrue(res > 0);
        }

        [TestMethod]
        public void getAllDepartmentsTest()
        {
            //Arrange
            objDepartmentRepo = new DepartmentRepository();

            //Act
            List<Department> lstDepartments = objDepartmentRepo.getAllDepartments();

            //Assert
            Assert.IsNotNull(lstDepartments);
        }
    }
}
