using Allure.NUnit.Attributes;
using Jefit_test.SeleniumFramework;
using Jefit_test.Utils;
using OpenQA.Selenium;

namespace Jefit_test.Pages
{
    public class LoginPage : BasePage
    {
        private ButtonElement buttonElement;
        private BaseElement inputElement;

        private readonly By buttonToLoginPageLocator = By.XPath("//a[@href='/login' and normalize-space(text())='Log In']");
        private readonly By nameFieldLocator = By.XPath("//input[@name='username' and @type='text']");
        private readonly By passwordFieldLocator = By.XPath("//input[@type='password' and @name='password']");
        private readonly By loginButtonLocator = By.XPath("//button[@type='submit' and normalize-space(text())='Log In']");
        private readonly By continueButtonLocator = By.XPath("//button[normalize-space(text())='Continue' and @type='button']");
        private readonly By userMenuLocator = By.XPath("//span[contains(@class,'truncate') and text()='kaR35xPCGFKcQM3m']");
        private readonly By signOutButtonLocator = By.XPath("//div[@data-slot='label' and normalize-space(text())='Sign out']");

        [AllureStep("Открыть начальную страницу")]
        public void OpenPage()
        {
            BrowserUtils.OpenPage(Links.StartPage);
        }

        [AllureStep("Открыть форму логина через кнопку на начальной странице")]
        public void CLickLogIn()
        {
            buttonElement = new ButtonElement(buttonToLoginPageLocator);
            buttonElement.ClickIfEnabled();
        }

        [AllureStep("Ввестиданные на странице, выполнить вход, закрыть всплавающее окно")]
        public void EnterLoginData(string email, string password)
        {
            inputElement = new BaseElement(nameFieldLocator);
            inputElement.SetUpText(email);

            inputElement = new BaseElement(passwordFieldLocator);
            inputElement.SetUpText(password);

            buttonElement = new ButtonElement(loginButtonLocator);
            buttonElement.ClickIfEnabled();

            buttonElement = new ButtonElement(continueButtonLocator);
            buttonElement.ClickIfEnabled();
        }

        public bool WaitUntilLoginFieldVisible()
        {
            return WaitUntilVisible(nameFieldLocator) != null;
        }

        [AllureStep("Открыть выпадающий список поля пользователя")]
        public void CLickUserField()
        {
            var waitUserMenu = WaitUntilClickable(userMenuLocator);
            buttonElement = new ButtonElement(userMenuLocator);
            buttonElement.ClickIfEnabled();
            var waitSignoutButton = WaitUntilClickable(signOutButtonLocator);
            buttonElement = new ButtonElement(signOutButtonLocator);
            buttonElement.ClickIfEnabled();
        }
    }
}
