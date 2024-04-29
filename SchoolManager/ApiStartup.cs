using SchoolManager.Service;

namespace SchoolManager.Application
{
    public static class ApiStartup
    {
        public static IServiceCollection ApiRegister(this IServiceCollection serviceCollection)
        {
            serviceCollection.ServiceRegister();

            return serviceCollection;
        }
    }
}
