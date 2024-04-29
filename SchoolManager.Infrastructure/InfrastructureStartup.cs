using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SchoolManager.Domain.Interface.Repository;
using SchoolManager.Infrastructure.Repositories;

namespace SchoolManager.Infrastructure
{
    public static class InfrastructureStartup
    {
        public static IServiceCollection InfrastructureRegister(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddScoped<IAlunoRepository, AlunoRepository>();
            serviceCollection.AddScoped<ITurmaRepository, TurmaRepository>();
            serviceCollection.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();

            return serviceCollection;
        }
    }
}
