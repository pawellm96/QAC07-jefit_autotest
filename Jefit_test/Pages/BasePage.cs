using Jefit_test.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Jefit_test.Pages;

public abstract class BasePage
{
    public IWebDriver driver = BrowserUtils.Driver;

    public void RefreshPage()
    {
        driver.Navigate().Refresh();
    }
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

    public void WaitUntilLoading(string link, int timeoutSeconds = 5)
    {
        Wait(timeoutSeconds).Until(ExpectedConditions.UrlContains(link));
    }

    public void WaitForPageToLoad(int timeoutSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        wait.Until(driver =>
            ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete"
        );
    }

    public void WaitUntilInvisibility(By locator, int timeoutSeconds = 5)
    {
        Wait(timeoutSeconds).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
    }
}