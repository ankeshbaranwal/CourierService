using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierService.Wrapper;

namespace CourierService.Factory
{
    public class MailingService : IMailingService
    {
        public bool SendParcel(Parcel parcel)
        {

            return true;
        }
    }
}
