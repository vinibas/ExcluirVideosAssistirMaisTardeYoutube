using OpenQA.Selenium;
using System;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace ExcluirVideosAssistirMaisTardeYoutube.PageObjects
{
    class AssistirMaisTardePO
    {
        private readonly IWebDriver driver;

        private By ContainerPlaylist { get; } = By.CssSelector("ytd-playlist-video-list-renderer #contents");
        private By ÍtemPlaylist { get; } = By.TagName("ytd-playlist-video-renderer");
        private By ÍndiceItemPlaylist { get; } = By.Id("index");
        private By MenuÍtemPlaylist { get; } = By.Id("menu");
        private By OpçõesMenuÍtemPlaylist { get; } = By.CssSelector("#contentWrapper #items [role=\"menuitem\"] paper-item[role=\"option\"] yt-formatted-string");
        private By LoadingPlaylist { get; } = By.Id("spinner");
        private By TítuloTela { get; } = By.CssSelector("ytd-playlist-sidebar-renderer #items h1#title");

        public AssistirMaisTardePO(IWebDriver driver)
            => this.driver = driver;
        
        public void Acessar()
            => driver.Navigate().GoToUrl("https://www.youtube.com/playlist?list=WL");

        public void CarregarTudo()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            bool loadingExiste;

            do
            {
                var javascriptExecutor = (IJavaScriptExecutor)driver;
                javascriptExecutor.ExecuteScript(
                    "window.scrollTo(0, getComputedStyle(document.getElementById('content')).height.replace('px', ''))");

                loadingExiste = driver.WaitUntilOrReturnDefault(d => d.FindElement(LoadingPlaylist), TimeSpan.FromSeconds(3)) != null;
            } while (loadingExiste);
        }
        public void ExcluirVídeos(int[] ids)
        {
            var containerPlaylist = driver.FindElement(ContainerPlaylist);

            foreach (var id in ids.OrderByDescending(p => p))
            {
                var ítem = containerPlaylist.FindElements(ÍtemPlaylist)[id - 1];

                MoveToTítuloTela();

                ValidarSeÍtemPossuiÍndiceCorrespondente(ítem, id);

                if (id > 1)
                    MoverScrollParaÍtemAnterior(id - 2);

                driver.ActionsPerform(a => a.MoveToElement(ítem));
                
                ítem.FindElement(MenuÍtemPlaylist).Click();

                driver.FindElements(OpçõesMenuÍtemPlaylist)
                    .First(e => e.Text.Contains("Remover"))
                    .Click();
            }

            void MoveToTítuloTela()
                => driver.ActionsPerform(a => a.MoveToElement(driver.FindElement(TítuloTela)));


            void ValidarSeÍtemPossuiÍndiceCorrespondente(IWebElement ítem, int índice)
            {
                var índiceReal = int.Parse(ítem.FindElement(ÍndiceItemPlaylist).Text);
                if (índiceReal != índice)
                    throw new Exception($"O ítem encontrado não possui o índice esperado! Esperado: {índice}; Real: {índiceReal}.");
            }

            void MoverScrollParaÍtemAnterior(int idAnterior)
                => driver.ScrollTo(containerPlaylist.FindElements(ÍtemPlaylist)[idAnterior]);
        }

    }
}
