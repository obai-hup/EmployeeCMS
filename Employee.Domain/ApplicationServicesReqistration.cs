using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Employee.Domain
{
    public static class ApplicationServicesReqistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
             services.AddAutoMapper(Assembly.GetExecutingAssembly());



            return services;
        }
    }
}
