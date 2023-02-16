using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierService.Wrapper;

namespace CourierService.Factory
{
    public interface IMailingService
    {
        public bool SendParcel(Parcel parcel);
    }
}
