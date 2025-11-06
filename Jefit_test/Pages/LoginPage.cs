using Allure.NUnit.Attributes;
using Jefit_test.SeleniumFramework;
using Jefit_test.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Jefit_test.Pages
{
    public class LoginPage : BasePage
    {
        private ButtonElement buttonElement;
        private BaseElement inputElement;

        private readonly By buttonToLoginPage = By.XPath("//a[@href='/login' and normalize-space(text())='Log In']");
        private readonly By nameField = By.XPath("//input[@name='username' and @type='text']");
        private readonly By passwordField = By.XPath("//input[@type='password' and @name='password']");
        private readonly By loginButton = By.XPath("//button[@type='submit' and normalize-space(text())='Log In']");
        private readonly By continueButton = By.XPath("//button[normalize-space(text())='Continue' and @type='button']");
        private readonly By userMenu = By.XPath("//span[contains(@class,'truncate') and text()='kaR35xPCGFKcQM3m']");
        private readonly By signOutButton = By.XPath("//div[@data-slot='label' and normalize-space(text())='Sign out']");
        private readonly By modalPanel = By.XPath("//div[@data-headlessui-state='open' and .//h2[contains(text(),'Welcome to the new My Jefit Dashboard!')]]");

        [AllureStep("Открыть начальную страницу")]
        public void OpenPage()
        {
            BrowserUtils.OpenPage(Links.StartPage);
        }

        [AllureStep("Открыть форму логина через кнопку на начальной странице")]
        public void CLickLogIn()
        {
            buttonElement = new ButtonElement(buttonToLoginPage);
            buttonElement.ClickIfEnabled();
        }

        [AllureStep("Ввестиданные на странице, выполнить вход, закрыть всплавающее окно")]
        public void EnterLoginData(string email, string password)
        {
            inputElement = new BaseElement(nameField);
            inputElement.SetUpText(email);

            inputElement = new BaseElement(passwordField);
            inputElement.SetUpText(password);

            buttonElement = new ButtonElement(loginButton);
            buttonElement.ClickIfEnabled();

            buttonElement = new ButtonElement(continueButton);
            buttonElement.ClickIfEnabled();

        }

        [AllureStep("Закрыть модальное окно и дождаться исчезновения")]
        public void CloseModalIfVisible()
        {
            try
            {
                var modal = new BaseElement(modalPanel, 3); // короткий таймаут
                if (modal.IsDisplayed())
                {
                    buttonElement = new ButtonElement(continueButton);
                    buttonElement.ClickIfEnabled();

                    // дождаться, пока модальное окно скроется
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(d =>
                    {
                        try
                        {
                            return !modal.IsDisplayed();
                        }
                        catch (NoSuchElementException)
                        {
                            return true; // если элемента уже нет — считаем, что окно закрыто
                        }
                    });
                }
            }
            catch (NoSuchElementException)
            {
                // Модального окна нет — продолжаем
            }
        }

        public bool WaitUntilLoginFieldVisible()
        {
            return WaitUntilVisible(nameField) != null;
        }

        [AllureStep("Открыть выпадающий список поля пользователя")]
        public void CLickUserField()
        {
            CloseModalIfVisible();
            var waitUserMenu = WaitUntilClickable(userMenu);
            buttonElement = new ButtonElement(userMenu);
            buttonElement.ClickIfEnabled();
            var waitSignoutButton = WaitUntilClickable(signOutButton);
            buttonElement = new ButtonElement(signOutButton);
            buttonElement.ClickIfEnabled();
        }
    }
}
