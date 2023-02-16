using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierService.Wrapper;

namespace CourierService.Services
{
    public  interface IContainerService
    {
        public void ProcessParcel(Container container);
    }
}
