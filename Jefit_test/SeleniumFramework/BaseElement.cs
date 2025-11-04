using Jefit_test.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Jefit_test.SeleniumFramework;

public class BaseElement
{
    protected IWebDriver Driver = BrowserUtils.Driver;
    protected By Locator;
    protected WebDriverWait Wait;

    public BaseElement(By locator, int timeOutSeconds = 10)
    {
        Locator = locator;
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutSeconds));
    }

    public IWebElement Element => Wait.Until(driver => driver.FindElement(Locator));

    public bool IsDisplayed()
    {
        return Element.Displayed;
    }

    public bool IsEnabled()
    {
        return Element.Enabled;
    }

    public void ClickElement()
    {
        Wait.Until(ExpectedConditions.ElementToBeClickable(Locator)).Click();
    }

    public void SetUpText(string text)
    {
        Element.Clear();
        Element.SendKeys(text);
    }

    public string GetText()
    {
        return Element.Text;
    }

    public string? GetAttributeValue(string attributeName)
    {
        return Element.GetAttribute(attributeName);
    }
}