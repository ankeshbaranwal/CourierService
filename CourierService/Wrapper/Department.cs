namespace CourierService.Wrapper
{
    public enum DepartmentType
    {
        Mail, Regular, Heavy, Insurance
    }
    public class Department
    {
        public int DepartmentId { get; set; }
        public DepartmentType DepartmentType { get; set; }
        public float WeightRangeMin { get; set; }
        public float WeightRangeMax { get; set; }
        public Department()
        { }
    }
    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public Address() { }
    }
  
    
   
}