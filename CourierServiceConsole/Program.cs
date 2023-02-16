// See https://aka.ms/new-console-template for more information

using CourierService.Factory;
using CourierService.Services;
using CourierService.Wrapper;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Serialization;

ServiceCollection services = new ServiceCollection();
// Injecting Dependencies
services.AddScoped<IInsuranceService, InsuranceService>();
services.AddScoped<IContainerService, ContainerService>();
services.AddScoped<IDepartmentService, DepartmentService>();
services.AddSingleton<MailerFactory>();

ServiceProvider provider = services.BuildServiceProvider();

//Getting department service from IOC container
var deptService = provider.GetService<IDepartmentService>();
if (deptService != null)
{
    deptService.AddDepartment(new CourierService.Wrapper.Department { DepartmentId = 1, DepartmentType = CourierService.Wrapper.DepartmentType.Mail, WeightRangeMax = 1, WeightRangeMin = 0 });
    deptService.AddDepartment(new CourierService.Wrapper.Department { DepartmentId = 2, DepartmentType = CourierService.Wrapper.DepartmentType.Regular, WeightRangeMax = 10, WeightRangeMin = 0 });
    deptService.AddDepartment(new CourierService.Wrapper.Department { DepartmentId = 3, DepartmentType = CourierService.Wrapper.DepartmentType.Heavy, WeightRangeMax = 100000, WeightRangeMin = 10 });
    deptService.AddDepartment(new CourierService.Wrapper.Department { DepartmentId = 4, DepartmentType = CourierService.Wrapper.DepartmentType.Insurance, WeightRangeMax = 0, WeightRangeMin = 0 });
}

XmlSerializer serializer = new XmlSerializer(typeof(Container));
Container? container;
try
{
    using (FileStream fileStream = new FileStream(Environment.CurrentDirectory + "/Container/Container.xml", FileMode.Open))
    {
        container = (Container?)serializer.Deserialize(fileStream);
    }
    if (container != null)
    {
        var containerService = provider.GetService<IContainerService>();
        if (containerService != null)
        {
            containerService.ProcessParcel(container);
        }
    }

}
catch
{
    //Log Exception
}

