using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SchoolManager.Domain.Interface.Repository;
using SchoolManager.Infrastructure;
using SchoolManager.Service.Services;

namespace SchoolManager.Service
{
    public static class ServiceStartup
    {
        public static IServiceCollection ServiceRegister(this IServiceCollection serviceCollection)
        {
            serviceCollection.InfrastructureRegister();
            serviceCollection.TryAddScoped<IAlunoService, AlunoService>();
            serviceCollection.TryAddScoped<ITurmaService, TurmaService>();
            serviceCollection.TryAddScoped<IAlunoTurmaService, AlunoTurmaService>();

            return serviceCollection;
        }
    }
}
