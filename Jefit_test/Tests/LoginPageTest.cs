using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Jefit_test.Pages;
using Jefit_test.TestData;
using Jefit_test.Utils;

namespace Jefit_test.Tests
{
    [TestFixture]
    [AllureTag("smoke")]
    [AllureOwner("Pavel")]
    [AllureNUnit]
    public class LoginPageTest : Jefit_BaseTest
    {
        private LoginPage loginPage = new LoginPage();

        [Test, Order(1)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("Login page")]
        [AllureStep("Выполнить вход на страницу логина через кнопку на начальной странице")]
        public void OpenLogInPage()
        {
            loginPage.OpenPage();
            loginPage.CLickLogIn();
            bool isLoginFieldVisible = loginPage.WaitUntilLoginFieldVisible();
            Assert.That(driver.Url.Contains("/login"), Is.True, "Пользователь должен быть перенаправлен на страницу логина");
            Assert.That(isLoginFieldVisible, Is.True, "Поле ввода логина должно быть отображено на странице");
        }

        [Test, Order(2)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("Enter Login Data")]
        [AllureStep("Выполнить вход на страницу логина через кнопку на начальной странице")]
        public void EnterUserData() 
        {
            loginPage.EnterLoginData("pawellm96@gmail.com", "Wasd123@");
            WaitHelper.WaitUntilLoading(driver, Links.UserJefit);
            Assert.That(driver.Url.Contains("/my-jefit"), Is.True, "После успешного входа пользователь должен быть перенаправлен на страницу профиля /my-jefit");
        }

        [Test, Order(3)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("Sign out")]
        [AllureStep("Выполнить выход через кабинет пользователя")]
        public void SignOut()
        {
            loginPage.RefreshPage();
            WaitHelper.WaitUntilLoading(driver, Links.UserJefit);
            loginPage.CLickUserField();
            Assert.That(driver.Url.Equals(Links.StartPage), Is.True, "После выхода пользователь должен быть перенаправлен на стартовую страницу");
        }
    }
}
