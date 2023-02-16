using CourierService.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Factory
{
    public class HeavyMailService : IMailingService
    {
        public bool SendParcel(Parcel parcel)
        {
            return true;
        }
    }
}
