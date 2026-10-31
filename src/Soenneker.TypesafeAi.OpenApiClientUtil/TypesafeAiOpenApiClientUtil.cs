using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.TypesafeAi.HttpClients.Abstract;
using Soenneker.TypesafeAi.OpenApiClientUtil.Abstract;
using Soenneker.TypesafeAi.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.TypesafeAi.OpenApiClientUtil;

///<inheritdoc cref="ITypesafeAiOpenApiClientUtil"/>
public sealed class TypesafeAiOpenApiClientUtil : ITypesafeAiOpenApiClientUtil
{
    private readonly AsyncSingleton<TypesafeAiOpenApiClient> _client;

    public TypesafeAiOpenApiClientUtil(ITypesafeAiOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<TypesafeAiOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("TypesafeAi:ApiKey");
            string authHeaderName = configuration["TypesafeAi:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["TypesafeAi:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

            return new TypesafeAiOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<TypesafeAiOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
