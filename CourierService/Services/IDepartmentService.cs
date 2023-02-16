using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierService.Wrapper;

namespace CourierService.Services
{
    public interface IDepartmentService
    {
        public bool AddDepartment(Department dept);
        public bool RemoveDepartment(DepartmentType department);
        public IEnumerable<Department> GetDepartments();

    }
}
