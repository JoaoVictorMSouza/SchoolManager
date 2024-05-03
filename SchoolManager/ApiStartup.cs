using FluentValidation.AspNetCore;
using SchoolManager.Domain.Validators;
using SchoolManager.Service;

namespace SchoolManager.Application
{
    public static class ApiStartup
    {
        public static IServiceCollection ApiRegister(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllersWithViews();

            serviceCollection
                .AddFluentValidation(x =>
                {
                    x.RegisterValidatorsFromAssemblyContaining<TurmaValidator>();
                    x.RegisterValidatorsFromAssemblyContaining<AlunoValidator>();
                    x.RegisterValidatorsFromAssemblyContaining<AlunoTurmaValidator>();
                });

            serviceCollection.ServiceRegister();

            return serviceCollection;
        }
    }
}
