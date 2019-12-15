using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcluirVideosAssistirMaisTardeYoutube.PageObjects
{
    class LoginPO
    {
        private readonly IWebDriver driver;

        private By Email { get; } = By.CssSelector("#identifierId");
        private By Senha { get; } = By.CssSelector("#password input");

        public LoginPO(IWebDriver driver)
            => this.driver = driver;

        public void Acessar()
            => driver.Navigate().GoToUrl("https://accounts.google.com/ServiceLogin?service=youtube");

        public void Logar(string usuário, string senha)
        {
            var el = driver.FindElement(Email);
            el.SendKeys(usuário);
            el.SendKeys(Keys.Enter);

            el = driver.FindElement(Senha);
            el.SendKeys(senha);
            System.Threading.Thread.Sleep(500);
            el.SendKeys(Keys.Enter);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url.Contains("https://myaccount.google.com"));
            driver.Navigate().GoToUrl("https://www.youtube.com.br");
        }
    }
}
