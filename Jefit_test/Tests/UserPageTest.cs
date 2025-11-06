using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Jefit_test.Pages;
using Jefit_test.SeleniumFramework;
using Jefit_test.TestData;
using Jefit_test.Utils;
using OpenQA.Selenium;

namespace Jefit_test.Tests
{
    [TestFixture]
    [AllureTag("smoke")]
    [AllureOwner("Pavel")]
    [AllureNUnit]
    public class UserPageTest : Jefit_BaseTest
    {
        private UserPage userPage = new UserPage();

        [Test, Order(1)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("User page")]
        [AllureStep("Выполнить вход на страницу пользователя, через ввод данных пользователя")]
        public void OpenUserPage()
        {
            userPage.OpenLoginPage();
            userPage.EnterLoginData("pawellm96@gmail.com", "Wasd123@");
            WaitHelper.WaitUntilLoading(driver, Links.UserJefit);
            Assert.That(driver.Url.Contains("/my-jefit"), Is.True, "После успешного входа пользователь должен быть перенаправлен на страницу профиля /my-jefit");
        }

        [Test, Order(2)]
        [AllureSeverity(SeverityLevel.trivial)]
        [AllureSuite("Exercises Menu")]
        [AllureStep("Выбрать Меню упражнений")]
        public void ExercisesMenuTest()
        {
            userPage.SelectExercises();
            WaitHelper.WaitUntilLoading(driver, Links.ExercisePage);
            Assert.That(driver.Url.Contains("/exercises"), Is.True, "Страница с упражнениями должна быть открыта");
        }

        [Test, Order(3)]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSuite("Create custom exercise")]
        [AllureStep("Создать 3 упражнения")]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CreateCustomExerciseTest(int number)
        {
            string exerciseName = $"Тестовое упражнение {number}";
            userPage.CreatCustomExercise(exerciseName);
            var exerciseElement = new BaseElement(By.XPath($"//p[text()='{exerciseName}']"));
            Assert.That(exerciseElement.IsDisplayed(), Is.True, $"Упражнение '{exerciseName}' должно быть на странице");
            if (number == 3)
            {
                var createButton = new BaseElement(By.XPath("//button[contains(text(),'Create custom exercise') and contains(@class,'inline-flex')]"));
                Assert.That(!createButton.IsEnabled(), Is.True, "Кнопка создания упражнения должна быть неактивной после 3-го упражнения");
            }
        }

        [Test, Order(4)]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSuite("Delete custom exercise")]
        public void DeleteCustomExercisesTest()
        {
            int exercisesToDelete = 3;

            for (int i = 1; i <= exercisesToDelete; i++)
            {
                userPage.DeleteCustomExercise();
                userPage.RefreshPage();
                userPage.WaitForPageToLoad();
            }

            string actualButtonText = userPage.GetCreateCustomExerciseButtonText();
            Assert.That(actualButtonText.Contains("(0/3)"), Is.True,  $"Ожидалось, что кнопка будет содержать '(0/3)'");
        }
    }
}
