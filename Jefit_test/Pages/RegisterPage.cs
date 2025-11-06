using Allure.NUnit.Attributes;
using Jefit_test.SeleniumFramework;
using Jefit_test.TestData;
using Jefit_test.Utils;
using OpenQA.Selenium;

namespace Jefit_test.Pages
{
    public class RegisterPage : BasePage
    {
        private ButtonElement buttonElement;

        private readonly By emailErrorLocator = By.XPath("//p[@id='email-error' and normalize-space(text())='Email already in use.']");
        private readonly By emailInputLocator = By.XPath("//input[@id='email']");
        private readonly By submitButtonLocator = By.CssSelector("button[type='submit']");

        [AllureStep("Открыть страницу Регистрации")]
        public void OpenRegisterPage()
        {
            BrowserUtils.OpenPage(Links.RegisterPage);
        }

        [AllureStep("Вводим Почту")]
        public void EnterMail(string mail)
        {
            WaitHelper.WaitUntilClickable(driver, emailInputLocator);
            var heightInput = new BaseElement(emailInputLocator);
            heightInput.SetUpText(mail);
        }

        [AllureStep("Нажать кнопку подтверждения 'Continue'")]
        public void CLickSubmit()
        {
            WaitHelper.WaitUntilClickable(driver, submitButtonLocator);
            buttonElement = new ButtonElement(submitButtonLocator);
            buttonElement.ClickIfEnabled();
        }

        [AllureStep("Ждём появление сообщения 'Email already in use.'")]
        public bool IsEmailErrorVisible(int timeoutSeconds = 10)
        {
            try
            {
                var element = WaitHelper.WaitUntilVisible(driver, emailErrorLocator, timeoutSeconds);
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
