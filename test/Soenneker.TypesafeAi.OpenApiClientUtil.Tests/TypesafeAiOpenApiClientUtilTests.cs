using Soenneker.TypesafeAi.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.TypesafeAi.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TypesafeAiOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ITypesafeAiOpenApiClientUtil _openapiclientutil;

    public TypesafeAiOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ITypesafeAiOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
