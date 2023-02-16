using CourierService.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourierServiceTests
{
    [TestClass]
    public class DepartmentServiceTest
    {
        IDepartmentService? departmentService;
        [TestInitialize]
        public void Init()
        {
            departmentService = new DepartmentService();
        }
        [TestMethod]
        public void AddDepartment_Successfull()
        {
            var result = departmentService?.AddDepartment(new CourierService.Wrapper.Department { DepartmentId = 1, DepartmentType = CourierService.Wrapper.DepartmentType.Mail, WeightRangeMax = 1, WeightRangeMin = 0 });
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AddDepartment_NullDepartment_Throws_ArgumentNullException()
        {
            ArgumentNullException ex = Assert.ThrowsException<ArgumentNullException>(() => departmentService?.AddDepartment(null));

            Assert.IsTrue(ex.Message.Equals("Value cannot be null. (Parameter 'Department is null')"));
        }
        [TestMethod]
        public void AddDepartment_AlreadyExisting_Throws_Exception()
        {
            var result = departmentService?.AddDepartment(new CourierService.Wrapper.Department { DepartmentId = 1, DepartmentType = CourierService.Wrapper.DepartmentType.Mail, WeightRangeMax = 1, WeightRangeMin = 0 });

            Exception ex = Assert.ThrowsException<Exception>(() => departmentService?.AddDepartment(new CourierService.Wrapper.Department { DepartmentId = 1, DepartmentType = CourierService.Wrapper.DepartmentType.Mail, WeightRangeMax = 1, WeightRangeMin = 0 }));

            Assert.IsTrue(ex.Message.Equals("Department already exists"));
        }
        [TestMethod]
        public void Remove_AlreadyExisting_Successfull()
        {
            var result = departmentService?.AddDepartment(new CourierService.Wrapper.Department { DepartmentId = 1, DepartmentType = CourierService.Wrapper.DepartmentType.Mail, WeightRangeMax = 1, WeightRangeMin = 0 });
            Assert.IsTrue(result);
            result = departmentService?.RemoveDepartment(CourierService.Wrapper.DepartmentType.Mail);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Remove_NonExistingDepartment_ThrowsError()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => departmentService?.RemoveDepartment(CourierService.Wrapper.DepartmentType.Heavy));

            Assert.IsTrue(ex.Message.Equals("Department doesnot exists"));
        }
    }
}