﻿namespace BhuHelpAPI.Infracture.Extensions;

public static class InfraService
{
    public static IServiceCollection AddInfraService(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddDataProtection();
        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
       .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(
                config.GetConnectionString(CommonFields.ApplicationUserDBConnection),
                mod => mod.MigrationsAssembly(CommonFields.BhuHelpAPIInfracture));
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        services.AddScoped<SignInManager<ApplicationUser>>();

        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IBhuInfoRepository, BhuInfoRepository>();
        return services;
    }
}
