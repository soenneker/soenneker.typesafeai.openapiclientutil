using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.TypesafeAi.HttpClients.Registrars;
using Soenneker.TypesafeAi.OpenApiClientUtil.Abstract;

namespace Soenneker.TypesafeAi.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class TypesafeAiOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="TypesafeAiOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddTypesafeAiOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddTypesafeAiOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ITypesafeAiOpenApiClientUtil, TypesafeAiOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="TypesafeAiOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddTypesafeAiOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddTypesafeAiOpenApiHttpClientAsSingleton()
                .TryAddScoped<ITypesafeAiOpenApiClientUtil, TypesafeAiOpenApiClientUtil>();

        return services;
    }
}
