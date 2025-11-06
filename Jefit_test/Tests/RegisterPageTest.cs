using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using Jefit_test.Pages;
using Jefit_test.TestData;

namespace Jefit_test.Tests
{
    public class RegisterPageTest : Jefit_BaseTest
    {
        private RegisterPage registerPage = new RegisterPage();

        [Test]
        [AllureTag("smoke")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Pavel")]
        [AllureSuite("Exist User Test")]
        [AllureStep("Проверка поведения при вводе уже существующей почты")]
        public void RegistrTest()
        {
            registerPage.OpenRegisterPage();
            Assert.That(driver.Url, Is.EqualTo(Links.RegisterPage), $"Начальная страница не открылась");
            registerPage.EnterMail("pawellm96@gmail.com");
            registerPage.CLickSubmit();
            Assert.That(registerPage.IsEmailErrorVisible(), Is.True, "При вводе существующей почты должно появиться сообщение об ошибке 'Email already in use.'");
        }
    }
}
