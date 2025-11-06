using Jefit_test.Utils;
using OpenQA.Selenium;

namespace Jefit_test.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver = BrowserUtils.Driver;

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        public void WaitForPageToLoad(int timeoutSeconds = 10)
        {
            WaitHelper.WaitForPageToLoad(driver, timeoutSeconds);
        }
    }
}
