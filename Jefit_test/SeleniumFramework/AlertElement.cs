using Jefit_test.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationTesting.SeleniumFramework;

public class AlertElement
{
    protected IWebDriver Driver = BrowserUtils.Driver;

    public bool IsAlertPresent(int timeOutSeconds = 10)
    {
        try
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutSeconds))
                .Until(ExpectedConditions.AlertIsPresent());
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public void AlertAccept()
    {
        Driver.SwitchTo().Alert().Accept();
    }

    public void AlertDismiss()
    {
        Driver.SwitchTo().Alert().Dismiss();
    }

    public string? GetAlertText()
    {
        return Driver.SwitchTo().Alert().Text;
    }

    public void AlertSendText(string text)
    {
        Driver.SwitchTo().Alert().SendKeys(text);
    }
}