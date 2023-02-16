using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierService.Wrapper;

namespace CourierService.Services
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> departmentList;
        private static int counter = 1;
        public DepartmentService()
        {
           
                departmentList = new List<Department>();
            
        }
        public bool AddDepartment(Department dept)
        {
            if (dept == null)
            {
                throw new ArgumentNullException("Department is null");
            }
            if (departmentList.Exists(p => p.DepartmentType == dept.DepartmentType))
            {
                throw new Exception("Department already exists");
            }
            departmentList.Add(dept);
            return true;
        }

        public bool RemoveDepartment(DepartmentType deptType)
        {
            if (departmentList.Exists(p => p.DepartmentType == deptType))
            {
                departmentList.Remove(departmentList.First(p => p.DepartmentType == deptType));
                return true;
            }
            else
            {
                throw new Exception("Department doesnot exists");
            }

        }

        public IEnumerable<Department> GetDepartments()
        {
            return departmentList;
        }


    }
}
