using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Wrapper
{
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public Address? Address { get; set; }
    }
    //public class Receipient
    //{
    //    public string Name { get; set; } = string.Empty;
    //    public Address? Address { get; set; }
    //}
}
