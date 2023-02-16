using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierService.Factory;
using CourierService.Wrapper;

namespace CourierService.Services
{
    public class ContainerService : IContainerService
    {
        private IDepartmentService _deptSevice;
        private IInsuranceService _insuranceService;
        private IEnumerable<Department> _departments;
        private MailerFactory _mailerFactory;
        public ContainerService(IDepartmentService departmentService, IInsuranceService insuranceService, MailerFactory mailerFactory)
        {
            _deptSevice = departmentService;
            _insuranceService = insuranceService;
            _mailerFactory = mailerFactory;
            _departments = _deptSevice.GetDepartments();
        }
        public void ProcessParcel(Container container)
        {
            if (container == null)
            {
                //code for Logging Error
                throw new Exception("Container is null");
            }

            foreach (var item in container.parcels)
            {

                Department? dept = (from dep in _departments
                                    where item.Weight >= dep.WeightRangeMin && item.Weight <= dep.WeightRangeMax
                                    select dep).FirstOrDefault();
                if (dept == null)
                {
                    //code for logging error
                }
                else
                {
                    try
                    {
                        Send(item, dept);
                    }
                    catch (Exception ex)
                    {
                        //Log error
                    }
                }
            }
            Console.ReadLine();
        }

        private bool Send(Parcel parcel, Department dept)
        {
            bool isSuccesful = false;
            bool isInsuranceSignOff = false;
            if (parcel.Value >= 1000)
            {
                isInsuranceSignOff = _insuranceService.InsuranceSignOff(parcel);
            }
            var mailerService = _mailerFactory.GetMailerService(dept.DepartmentType);
            if (mailerService != null)
            {
                isSuccesful = mailerService.SendParcel(parcel);
                Console.WriteLine("Parcel to Receipient : {0}, Value {1} processed successfully Insurance Sign Off : {2}", parcel?.Receipient?.Name, parcel?.Value, isInsuranceSignOff);
            }
            return isSuccesful;
        }
    }
}
