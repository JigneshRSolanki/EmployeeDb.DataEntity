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
    public class DepartmentRepository : IDepartment
    {
        #region "Department CRUD Operation"

        public int addDepartment(Department dept)
        {
            int deptId = 0;
            try
            {
                using (MyDBEntities db = new MyDBEntities())
                {
                    tblDepartment objtblDept = fillEntityModel(dept);

                    db.tblDepartment.Add(objtblDept);

                    deptId = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deptId;
        }

        public int deleteDepartment(Department dept)
        {
            int deptId = 0;
            try
            {
                using (MyDBEntities db = new MyDBEntities())
                {
                    tblDepartment objtblDept = fillEntityModel(dept);

                    db.Entry(objtblDept).State = System.Data.Entity.EntityState.Deleted;

                    deptId = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deptId;
        }

        public int editDepartment(Department dept)
        {
            int deptId = 0;
            try
            {
                using (MyDBEntities db = new MyDBEntities())
                {
                    tblDepartment objtblDept = fillEntityModel(dept);

                    db.Entry(objtblDept).State = System.Data.Entity.EntityState.Modified;

                    deptId = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deptId;
        }

        public List<Department> getAllDepartments()
        {
            List<Department> lstDepartments = new List<Department>();
            try
            {
                using (MyDBEntities db = new MyDBEntities())
                {
                    List<tblDepartment> lsttbDepartments = db.tblDepartment.ToList();

                    foreach (var objtbDepartment in lsttbDepartments)
                    {
                        Department objDepartment = fillDomainModel(objtbDepartment);
                        lstDepartments.Add(objDepartment);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDepartments;
        }

        public Department getDepartmentById(int deptId)
        {
            Department objDepartment = new Department();
            try
            {
                using (MyDBEntities db = new MyDBEntities())
                {
                    tblDepartment objtbDepartment = db.tblDepartment.Where(d => d.DeptId == deptId).FirstOrDefault();
                    objDepartment = fillDomainModel(objtbDepartment);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objDepartment;
        }

        #endregion

        #region "Fill Entity and Domain Model"

        tblDepartment fillEntityModel(Department dept)
        {
            tblDepartment objTblDepartment = new tblDepartment();

            objTblDepartment.DeptId = dept.Id;
            objTblDepartment.DeptName = dept.Name;

            return objTblDepartment;
        }

        Department fillDomainModel(tblDepartment objtbDepartment)
        {
            Department objDepartment = new Department();

            objDepartment.Id = objtbDepartment.DeptId;
            objDepartment.Name = objtbDepartment.DeptName;

            return objDepartment;
        }

        #endregion

    }
}
