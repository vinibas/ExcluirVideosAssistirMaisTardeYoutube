using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ExcluirVideosAssistirMaisTardeYoutube
{
    class WebDriverConfig : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverConfig()
        {
            this.Driver = new ChromeDriver(@"C:\SeleniumDrivers");
            this.Driver.Manage().Window.Maximize();
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
        }

        public void Dispose()
            => Driver.Quit();
    }
}
