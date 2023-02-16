using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Wrapper
{
    public class Container
    {
        public int Id { get; set; }
        public DateTime ShippingDate { get; set; }
        public List<Parcel> parcels { get; set; }
        public Container()
        {
            parcels = new List<Parcel>();
        }
    }
}
