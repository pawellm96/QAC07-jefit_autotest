using Allure.NUnit.Attributes;
using Jefit_test.Utils;
using OpenQA.Selenium;

namespace Jefit_test.Pages
{    
    internal class StartPage : BasePage
    {
        private readonly By productsMenuLocator = By.XPath("//p[text()='Products']");
        private readonly By maximizedWindowItemLocator = By.XPath("//a[@href='/elite']");
        private readonly By minimalWindowItemLocator = By.XPath("//p[text()='Elite']");
        private readonly By exerciseTipsHeaderLocator = By.XPath("//h3[text()='Exercise Tips']");
        private readonly By jefitWatchTextLocator = By.XPath("//p[@data-slot='text' and contains(text(),'Learn how to make consistent strength gains')]");

        [AllureStep("Открыть начальную страницу")]
        public void OpenPage()
        {
            BrowserUtils.OpenPage(Links.StartPage);
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

        [AllureStep("Прокрутить страницу до заголовка Exercise Tips")]
        public void ScrollToExerciseTips()
        {
            var header = WaitUntilVisible(exerciseTipsHeaderLocator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior:'smooth', block:'center'});", header);
        }

        [AllureStep("Нажать на ссылку JEFIT Watch Upgrade")]
        public void ClickJefitWatchLink()
        {
            ScrollToExerciseTips();
            var link = WaitUntilClickable(jefitWatchTextLocator);
            link.Click();
        }
    }
}
