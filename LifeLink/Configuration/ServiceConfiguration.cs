using LifeLink.Repositories.EvacPersons;
using LifeLink.Repositories.FieldOperators;
using LifeLink.Repositories.Parameters;
using LifeLink.Repositories.Users;
using LifeLink.Services.EvacPersons;
using LifeLink.Services.FieldOperators;
using LifeLink.Services.Parameters;
using LifeLink.Services.Users;

namespace LifeLink.Configuration;
public static class ServiceConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Services
        services.AddScoped<IParameterService, ParameterService>();
        services.AddScoped<IEvacPersonService, EvacPersonService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFieldOperatorService, FieldOperatorService>();
        
        // Repositories
        services.AddScoped<IParameterRepository, ParameterRepository>();
        services.AddScoped<IEvacPersonRepository, EvacPersonRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFieldOperatorRepository, FieldOperatorRepository>();
    }
}