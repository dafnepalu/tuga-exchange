using CryptoQuoteAPI;
using Xunit;

namespace CryptoQuoteApiTests;

public class UnitTest1
{
    [Fact]
    public void TestMethod1()
    {
        var api = new API();
        api.AddCoin("BackstreetBoys");
        var list = api.GetCoins();
        Assert.Contains("BackstreetBoys", list);

        api.RemoveCoin("BackstreetBoys");
        list = api.GetCoins();
        Assert.DoesNotContain("BackstreetBoys", list);

        Assert.Empty(list);
    }
}
