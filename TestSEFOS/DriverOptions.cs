using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestSEFOS
{
    internal static class DriverOptions
    {
        public static IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--no-sandbox");
            IWebDriver driver = new ChromeDriver(options);
            return driver;
        }
        public static IWebDriver GetFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            options.AddArgument("--width=1920");
            options.AddArgument("--height=1080");
            options.AddArgument("--safe-mode");
            IWebDriver driver = new FirefoxDriver(options);
            return driver;
        }
        public static IWebDriver GetEdgeDriver()
        {
            var options = new EdgeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--no-sandbox");
            IWebDriver driver = new EdgeDriver(options);
            return driver;
        }
    }
}
