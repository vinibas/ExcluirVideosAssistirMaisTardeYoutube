using OpenQA.Selenium;
using System;
using System.Threading;

namespace ExcluirVideosAssistirMaisTardeYoutube
{
    public static class SeleniumHelper
    {
        public static void TryAction(
            Action condition,
            int times = 2,
            int milissecondsToWait = 500)
        {
            var attempts = 1;
            while (true)
                try
                {
                    condition.Invoke();
                    return;
                }
                catch (StaleElementReferenceException e)
                {
                    if (attempts < times)
                    {
                        attempts++;
                        if (milissecondsToWait > 0)
                            Thread.Sleep(milissecondsToWait);
                    }
                    else
                        throw e;
                }
        }
    }
}
