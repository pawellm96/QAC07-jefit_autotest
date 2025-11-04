using Jefit_test.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Jefit_test.Pages;

public abstract class BasePage
{
    public IWebDriver driver = BrowserUtils.Driver;

    protected WebDriverWait Wait(int timeoutSeconds = 5)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
    }

    protected IWebElement WaitUntilVisible(By locator, int timeoutSeconds = 5)
    {
        return Wait(timeoutSeconds).Until(ExpectedConditions.ElementIsVisible(locator));
    }

    protected IWebElement WaitUntilClickable(By locator, int timeoutSeconds = 5)
    {
        return Wait(timeoutSeconds).Until(ExpectedConditions.ElementToBeClickable(locator));
    }
}