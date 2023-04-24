namespace WebApplication2;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureSameSiteNoneCookies(this IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
            options.OnAppendCookie = cookieContext => CheckSameSite(cookieContext.CookieOptions);
            options.OnDeleteCookie = cookieContext => CheckSameSite(cookieContext.CookieOptions);
        });

        return services;
    }

    private static void CheckSameSite(CookieOptions options)
    {
        if (options.SameSite == SameSiteMode.None && options.Secure == false)
        {
            options.SameSite = SameSiteMode.Unspecified;
        }
    }
}
