using NUnit.Framework;

using static SuddanApplication.Application.IntegrationTests.Testing;

namespace SuddanApplication.Application.IntegrationTests;
[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }
}
