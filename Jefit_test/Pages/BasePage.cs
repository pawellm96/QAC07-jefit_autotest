using Jefit_test.Utils;
using OpenQA.Selenium;

namespace Jefit_test.Pages;

public abstract class BasePage
{
    public IWebDriver driver = BrowserUtils.Driver;
}