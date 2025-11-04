using Jefit_test.Pages;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace Jefit_test.Tests
{
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
    }
}
