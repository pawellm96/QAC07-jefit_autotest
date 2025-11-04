using Allure.NUnit.Attributes;
using Jefit_test.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Jefit_test.Pages
{    
    internal class StartPage : BasePage
    {
        private readonly By productsMenuLocator = By.XPath("//p[text()='Products']");
        private readonly By maximizedWindowItemLocator = By.XPath("//a[@href='/elite']");
        private readonly By minimalWindowItemLocator = By.XPath("//p[text()='Elite']");

        [AllureStep("Открыть начальную страницу")]
        public void OpenPage()
        {
            BrowserUtils.OpenPage("https://www.jefit.com/");
        }

        [AllureStep("Вызвать выпадающий список 'Products'")]
        public void OpenDropeDown()
        {
            var productsMenu = WaitUntilClickable(productsMenuLocator);
            productsMenu.Click();

            try
            {
                WaitUntilVisible(maximizedWindowItemLocator);
            }
            catch (WebDriverTimeoutException)
            {
                WaitUntilVisible(minimalWindowItemLocator);
            }
        }
    }
}
