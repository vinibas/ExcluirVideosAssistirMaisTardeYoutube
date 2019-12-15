using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace ExcluirVideosAssistirMaisTardeYoutube
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementIfExists(this ISearchContext element, By by)
        {
            var elements = element.FindElements(by);
            return elements.Count > 0 ? elements[0] : null;
        }

        public static TResult WaitUntilOrReturnDefault<TResult>(
            this IWebDriver driver,
            Func<IWebDriver, TResult> condition,
            TimeSpan waitFromSeconds)
        {
            var wait = new WebDriverWait(driver, waitFromSeconds);
            try
            {
                return wait.Until(condition);
            }
            catch (Exception ex) when (ex is StaleElementReferenceException || ex is WebDriverTimeoutException)
            {
                return default(TResult);
            }
        }

        public static void ActionsPerform(this IWebDriver driver, Func<Actions, Actions> actions)
            => actions.Invoke(new Actions(driver)).Build().Perform();

        public static void ScrollTo(this IWebDriver driver, IWebElement element)
            => ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        //{
        //    var javascriptExecutor = (IJavaScriptExecutor)driver;
        //    javascriptExecutor.ExecuteScript(
        //        $"window.scrollTo({element.Location.X}, {element.Location.Y}");
        //}
    }
}
