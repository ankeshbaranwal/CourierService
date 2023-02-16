using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CourierService.Wrapper
{
    public class Parcel
    {
        [XmlElement(ElementName = "Sender")]
        public Person? Sender { get; set; }

        [XmlElement(ElementName = "Receipient")]
        public Person? Receipient { get; set; }

        public float Weight { get; set; }
        public float Value { get; set; }
    }
}
