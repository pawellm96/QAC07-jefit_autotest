using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Jefit_test.Utils
{
    public static class WaitHelper
    {
        private static WebDriverWait GetWait(IWebDriver driver, int timeoutSeconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        }

        public static IWebElement WaitUntilVisible(IWebDriver driver, By locator, int timeoutSeconds = 5)
        {
            return GetWait(driver, timeoutSeconds).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitUntilClickable(IWebDriver driver, By locator, int timeoutSeconds = 5)
        {
            return GetWait(driver, timeoutSeconds).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitUntilInvisibility(IWebDriver driver, By locator, int timeoutSeconds = 5)
        {
            GetWait(driver, timeoutSeconds).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void WaitUntilLoading(IWebDriver driver, string link, int timeoutSeconds = 5)
        {
            GetWait(driver, timeoutSeconds).Until(ExpectedConditions.UrlContains(link));
        }

        public static void WaitForPageToLoad(IWebDriver driver, int timeoutSeconds = 10)
        {
            GetWait(driver, timeoutSeconds).Until(d =>
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public static void WaitSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}
