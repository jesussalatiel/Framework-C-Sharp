using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TestWare.Engines.Selenium.Configuration;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace TestWare.Engines.Selenium.Factory;

internal static class BrowserFactory
{
    public static IBrowserDriver Create(Capabilities capabilities)
    {
        return capabilities.GetDriver() switch
        {
            SupportedBrowsers.Chrome => CreateChromeDriver(capabilities),
            SupportedBrowsers.Firefox => CreateFirefoxDriver(capabilities),
            SupportedBrowsers.Edge => CreateEdgeDriver(capabilities),
            SupportedBrowsers.Invalid => throw new NotImplementedException(),
            _ => throw new NotSupportedException($"Browser type is invalid."),
        };
    }

    private static IBrowserDriver CreateChromeDriver(Capabilities capabilities)
    {
        ChromeOptions options = new();
        options.AddArguments(capabilities.Arguments);

        new DriverManager().SetUpDriver(new ChromeConfig());
        return  new ChromeDriver(options);
    }

    private static IBrowserDriver CreateFirefoxDriver(Capabilities capabilities)
    {
        FirefoxOptions options = new();
        options.AddArguments(capabilities.Arguments);

        new DriverManager().SetUpDriver(new FirefoxConfig());
        return new FirefoxDriver(options);
    }

    private static IBrowserDriver CreateEdgeDriver(Capabilities capabilities)
    {
        EdgeOptions options = new();
        options.AddArguments(capabilities.Arguments);

        new DriverManager().SetUpDriver(new EdgeConfig());
        return new EdgeDriver(options);
    }
}