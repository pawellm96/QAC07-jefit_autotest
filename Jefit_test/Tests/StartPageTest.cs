using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Jefit_test.Pages;
using OpenQA.Selenium;

namespace Jefit_test.Tests
{
    [AllureNUnit]
    public class StartPageTest : Jefit_BaseTest
    {
        private StartPage StartPage = new StartPage();

        [Test]
        [AllureTag("smoke")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Pavel")]
        [AllureSuite("SuccessfulOpeningSatrtPage")]
        [AllureStep("Проверка открытия начальной страницы сайта")]
        public void OpenStartPageTest()
        {
            StartPage.OpenPage();
            Assert.That(driver.Url, Is.EqualTo("https://www.jefit.com/"), $"Начальная страница не открылась");
        }

        [Test]
        [AllureTag("smoke")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Pavel")]
        [AllureSuite("DropdownMenu")]
        [AllureStep("Проверка вызова выпадающего списка Products")]
        public void OpenDropdownList()
        {
            StartPage.OpenPage();
            StartPage.OpenDropeDown();

            IWebElement dropdownItem;
            try
            {
                dropdownItem = driver.FindElement(By.XPath("//a[@href='/elite']"));
            }
            catch (NoSuchElementException)
            {
                dropdownItem = driver.FindElement(By.XPath("//p[text()='Elite']"));
            }

            Assert.That(dropdownItem.Displayed, Is.True, "Выпадающее меню 'Products' не открылось после клика");
        }
    }
}
