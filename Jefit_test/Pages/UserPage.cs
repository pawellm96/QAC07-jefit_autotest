using Allure.NUnit.Attributes;
using Jefit_test.SeleniumFramework;
using Jefit_test.Utils;
using OpenQA.Selenium;

namespace Jefit_test.Pages
{
    public class UserPage : BasePage
    {
        private ButtonElement buttonElement;
        private BaseElement inputElement;

        private readonly By nameFieldLocator = By.XPath("//input[@name='username' and @type='text']");
        private readonly By passwordFieldLocator = By.XPath("//input[@type='password' and @name='password']");
        private readonly By loginButtonLocator = By.XPath("//button[@type='submit' and normalize-space(text())='Log In']");
        private readonly By continueButtonLocator = By.XPath("//button[normalize-space(text())='Continue' and @type='button']");
        private readonly By exercisesBattonLocator = By.XPath("//a[@href='/my-jefit/exercises' and .//p[text()='Exercises']]");
        private readonly By createCustomExerciseButtonLocator = By.XPath("//button[.//text()[contains(.,'Create custom exercise')]]");
        private readonly By exerciseTitleInputLocator = By.XPath("//input[@placeholder='Add an Exercise Title' and @name='name']");
        private readonly By saveExerciseButtonLocator = By.XPath("//button[text()='Save Exercise']");
        private readonly By menuButtonLocator = By.XPath("//button[@aria-haspopup='menu' and contains(@class,'inline-flex')]");
        private readonly By deleteLabelLocator = By.XPath("//div[@data-slot='label' and text()='Delete']");
        private readonly By confirmDeleteButtonLocator = By.XPath("//button[text()='Delete' and contains(@class,'inline-flex')]");


        [AllureStep("Открыть страницу Login")]
        public void OpenLoginPage()
        {
            BrowserUtils.OpenPage(Links.LoginPage);
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

        [AllureStep("Выбор меню упражнений")]
        public void SelectExercises()
        {
            buttonElement = new ButtonElement(exercisesBattonLocator);
            buttonElement.ClickIfEnabled();
        }

        [AllureStep("Создание кастомного упражнения")]
        public void CreatCustomExercise(string newExerciseName)
        {
            buttonElement = new ButtonElement(createCustomExerciseButtonLocator);
            buttonElement.ClickIfEnabled();
            var inputWait = WaitUntilClickable(exerciseTitleInputLocator);
            inputElement = new BaseElement(exerciseTitleInputLocator);
            inputElement.SetUpText(newExerciseName);
            buttonElement = new ButtonElement(saveExerciseButtonLocator);
            buttonElement.ClickIfEnabled();
        }


        [AllureStep("Удаление всех кастомных упражнений")]
        public void DeleteCustomExercise()
        {
            var menuWait = WaitUntilClickable(menuButtonLocator);
            buttonElement = new ButtonElement(menuButtonLocator);
            buttonElement.ClickIfEnabled();
            var deleteWait = WaitUntilClickable(deleteLabelLocator);
            buttonElement = new ButtonElement(deleteLabelLocator);
            buttonElement.ClickIfEnabled();
            var confirmWait = WaitUntilClickable(confirmDeleteButtonLocator);
            buttonElement = new ButtonElement(confirmDeleteButtonLocator);
            buttonElement.ClickIfEnabled();
        }

        [AllureStep("Проверка кнопки 'Create custom exercise' с динамическим текстом")]
        public void VerifyCreateCustomExerciseButtonText(string expectedCounter)
        {
            var buttonElement = new BaseElement(createCustomExerciseButtonLocator);
            string buttonText = buttonElement.GetText();

            Assert.That(buttonText.Contains(expectedCounter), Is.True,
                $"Ожидалось, что кнопка будет содержать '{expectedCounter}', но текст кнопки: '{buttonText}'");
        }
    }
}
