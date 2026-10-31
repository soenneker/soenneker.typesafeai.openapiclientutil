using Soenneker.TypesafeAi.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.TypesafeAi.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ITypesafeAiOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<TypesafeAiOpenApiClient> Get(CancellationToken cancellationToken = default);
}
