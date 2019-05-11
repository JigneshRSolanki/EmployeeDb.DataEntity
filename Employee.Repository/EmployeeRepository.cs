using Employee.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.DomainModel;
using EmployeeDb.DataEntity;

namespace Employee.Repository
{
    public class EmployeeRepository : IEmployee
    {
        #region "Employee CRUD Operation"
        public int addEmployee(Employees emp)
        {
            int empId = 0;
            try
            {
                using (MyDBEntities db = new MyDBEntities())
                {
                    tblEmployee objtblEmp = fillEntityModel(emp);

                    db.tblEmployee.Add(objtblEmp);

                    empId = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empId;
        }

        public int deleteEmployee(Employees emp)
        {
            int empId = 0;
            try
            {
                using (MyDBEntities db = new MyDBEntities())
                {
                    tblEmployee objtblEmp = fillEntityModel(emp);

                    db.Entry(objtblEmp).State = System.Data.Entity.EntityState.Deleted;

                    empId = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empId;
        }

        public int editEmployee(Employees emp)
        {
            int empId = 0;
            try
            {
                using (MyDBEntities db = new MyDBEntities())
                {
                    tblEmployee objtblEmp = fillEntityModel(emp);

                    db.Entry(objtblEmp).State = System.Data.Entity.EntityState.Modified;

                    empId = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empId;
        }

        public List<Employees> getAllEmployees()
        {
            List<Employees> lstEmployees = new List<Employees>();
            try
            {
                using (MyDBEntities db = new MyDBEntities())
                {
                    List<tblEmployee> lsttbEmployees = db.tblEmployee.ToList();

                    foreach (var objtbEmployee in lsttbEmployees)
                    {
                        Employees objEmployee = fillDomainModel(objtbEmployee);
                        lstEmployees.Add(objEmployee);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEmployees;
        }

        public Employees getEmployeeById(int empId)
        {
            Employees objEmployee = new Employees();
            try
            {
                using (MyDBEntities db = new MyDBEntities())
                {
                    tblEmployee objtbEmployee = db.tblEmployee.Where(e => e.EmpId == empId).FirstOrDefault();
                    objEmployee = fillDomainModel(objtbEmployee);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEmployee;
        }
        #endregion


        #region "Fill Entity And Domain Model"

        tblEmployee fillEntityModel(Employees emp)
        {
            tblEmployee objTblEmployee = new tblEmployee();

            objTblEmployee.EmpId = emp.Id;
            objTblEmployee.EmpName = emp.Name;
            objTblEmployee.EmpGender = emp.Gender;
            objTblEmployee.EmpDesignation = emp.Designation;
            objTblEmployee.DepartmentId = emp.DepartmentId;

            return objTblEmployee;
        }

        Employees fillDomainModel(tblEmployee objtbEmployee)
        {
            Employees objEmployee = new Employees();

            objEmployee.Id = objtbEmployee.EmpId;
            objEmployee.Name = objtbEmployee.EmpName;
            objEmployee.Gender = objtbEmployee.EmpGender;
            objEmployee.Designation = objtbEmployee.EmpDesignation;
            objEmployee.DepartmentId = objtbEmployee.DepartmentId;

            return objEmployee;
        }

        #endregion
    }
}
