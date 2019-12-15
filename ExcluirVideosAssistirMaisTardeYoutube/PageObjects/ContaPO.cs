using OpenQA.Selenium;

namespace ExcluirVideosAssistirMaisTardeYoutube.PageObjects
{
    class ContaPO
    {
        private readonly IWebDriver driver;

        private By AvatarButton { get; } = By.Id("avatar-btn");
        private By ContaSelecionada { get; } = By.Id("account-name");
        private By AlternarContaBtn { get; } =
            By.XPath("//ytd-compact-link-renderer/a//yt-formatted-string[@id=\"label\"][text() = \"Alternar conta\"]/ancestor::a");

        private By SessãoContas { get; } = By.TagName("ytd-account-section-list-renderer");

        public ContaPO(IWebDriver driver)
            => this.driver = driver;

        public void SelecionarConta(string conta)
        {
            driver.FindElement(AvatarButton).Click();
            
            if (driver.FindElement(ContaSelecionada).Text != conta)
            {
                driver.FindElement(AlternarContaBtn).Click();

                driver.FindElement(SessãoContas)
                    .FindElement(By.XPath($"//ytd-account-item-renderer//yt-formatted-string[text() = \"{conta}\"]"))
                    .Click();
            }
        }
    }
}
