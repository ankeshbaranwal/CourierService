using CourierService.Services;
using CourierService.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Factory
{
    public class MailerFactory
    {
        public IMailingService? GetMailerService(DepartmentType department)
        {
            IMailingService? service = null;
            switch (department)
            {
                case DepartmentType.Mail:
                    service = new MailingService();
                    break;
                case DepartmentType.Regular:
                    service = new RegularMailService();
                    break;
                case DepartmentType.Heavy:
                    //Print and Send through Heavy service
                    service = new HeavyMailService();
                    break;

            }
            return service;
        }
    }
}
