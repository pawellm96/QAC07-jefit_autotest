using Allure.NUnit.Attributes;
using Jefit_test.SeleniumFramework;
using Jefit_test.TestData;
using Jefit_test.Utils;
using OpenQA.Selenium;

namespace Jefit_test.Pages
{
    public class AncetPage : BasePage
    {
        private TestDataReader userData;
        private ButtonElement buttonElement;
        private RadioButtonElement radioButtonElement;

        private readonly By maleRadio = By.XPath("//span[@role='radio' and .//p[text()='Male']]");
        private readonly By submitButton = By.CssSelector("button[type='submit']");
        private readonly By enduranceOptionLocator = By.XPath("//span[contains(@class, 'text-text-primary') and normalize-space(text())='Improve endurance']");
        private readonly By currentBuildOptionLocator = By.XPath("//span[normalize-space(text())='Average']");
        private readonly By bodyTypeOptionLocator = By.XPath("//span[contains(@class, 'text-text-primary') and normalize-space(text())='Berserk']");
        private readonly By bodyPartLocator = By.XPath("//span[contains(@class, 'text-text-primary') and normalize-space(text())='Legs']");
        private readonly By fitnessLevelOptionLocator = By.XPath("//span[contains(@class, 'text-text-primary') and normalize-space(text())='New to fitness']");
        private readonly By selectSILocator = By.XPath("//button[normalize-space(text())='CM/KG']");
        private readonly By inputHeightLocator = By.XPath("//input[@id='heightCm']");
        private readonly By inputWeightLocator = By.XPath("//input[@id='weight']");
        private readonly By inputGoalWeightLocator = By.XPath("//input[@id='weight']");
        private readonly By inputAgeLocator = By.XPath("//input[@id='Age']");
        private readonly By worckoutPlaceLocator = By.XPath("//span[contains(@class, 'text-text-primary') and normalize-space(text())='Home']");
        private readonly By gymLevelLocator = By.XPath("//span[contains(@class, 'text-text-primary') and normalize-space(text())='Advanced']");
        private readonly By timesToTrainLocator = By.XPath("//span[contains(@class, 'text-text-primary') and normalize-space(text())='5+ times per week']");
        private readonly By trainLenghtLocator = By.XPath("//span[contains(@class, 'text-text-primary') and normalize-space(text())='Up to 30 mins']");
        private readonly By startModeLocator = By.XPath("//span[contains(@class, 'text-text-secondary') and normalize-space(text())=\"It's a personal log and tracker for your workouts, and designed to replace a paper fitness journal\"]");
        private readonly By trainingLimitationsLocator = By.XPath("//span[contains(@class, 'text-text-primary') and normalize-space(text())='Sensitive knees']");


        [AllureStep("Открыть страницу Анкеты")]
        public void OpenAncetPage()
        {
            BrowserUtils.OpenPage(Links.AncetPage);
        }

        [AllureStep("Проверка текущей стадии формы регистрации по тексту заголовка")]
        public bool IsOnStage(string headerText)
        {
            var dynamicLocator = By.XPath($"//div[contains(@class, 'text-2xl') and normalize-space(text())='{headerText}']");
            var headerElement = new BaseElement(dynamicLocator);
            return headerElement.IsDisplayed();
        }

        [AllureStep("Проверяем состояние радиокнопки по локатору")]
        public bool IsRadioButtonSelected(By radioLocator)
        {
            WaitHelper.WaitUntilClickable(driver, radioLocator);
            radioButtonElement = new RadioButtonElement(radioLocator);
            return radioButtonElement.IsSelected();
        }

        [AllureStep("Нажать кнопку подтверждения 'Continue'")]
        public void CLickSubmit()
        {
            WaitHelper.WaitUntilClickable(driver, submitButton);
            buttonElement = new ButtonElement(submitButton);
            buttonElement.ClickIfEnabled();
        }

        [AllureStep("Загрузить данные пользователя из CSV")]
        public void LoadUserData()
        {
            userData = TestDataReader.FromCsv(@"TestData\UserHelthParameters.csv");
        }

        [AllureStep("Выбираем мужской пол")]
        public void SetMale()
        {
            WaitHelper.WaitUntilClickable(driver, maleRadio);
            radioButtonElement = new RadioButtonElement(maleRadio);
            radioButtonElement.Select();
        }

        [AllureStep("Выбираем опцию 'Improve endurance'")]
        public void SetEnduranceOption()
        {
            WaitHelper.WaitUntilClickable(driver, enduranceOptionLocator);
            radioButtonElement = new RadioButtonElement(enduranceOptionLocator);
            radioButtonElement.Select();
        }

        [AllureStep("Выбираем опцию 'Average'")]
        public void SetAverageOption()
        {
            WaitHelper.WaitUntilClickable(driver, currentBuildOptionLocator);
            radioButtonElement = new RadioButtonElement(currentBuildOptionLocator);
            radioButtonElement.Select();
        }

        [AllureStep("Выбираем опцию 'Berserk'")]
        public void SetBodyTypeOption()
        {
            buttonElement = new ButtonElement(bodyTypeOptionLocator);
            buttonElement.ClickIfEnabled();
        }

        [AllureStep("Выбираем целевую группу")]
        public void SetBodyPart()
        {
            WaitHelper.WaitUntilClickable(driver, bodyPartLocator);
            buttonElement = new ButtonElement(bodyPartLocator);
            buttonElement.ClickIfEnabled();
        }

        [AllureStep("Выбираем опцию 'Intermediate'")]
        public void SetIntermediateOption()
        {
            WaitHelper.WaitUntilClickable(driver, fitnessLevelOptionLocator);
            radioButtonElement = new RadioButtonElement(fitnessLevelOptionLocator);
            radioButtonElement.Select();
        }

        [AllureStep("Выбираем единицы измерения СИ")]
        public void SetSIOption()
        {
            WaitHelper.WaitUntilClickable(driver, selectSILocator);
            buttonElement = new ButtonElement(selectSILocator);
            buttonElement.ClickIfEnabled();
        }

        [AllureStep("Вводим рост")]
        public void EnterHeight()
        {
            WaitHelper.WaitUntilClickable(driver, inputHeightLocator);
            var heightInput = new BaseElement(inputHeightLocator);
            heightInput.SetUpText(userData.Height);
        }

        [AllureStep("Вводим Вес")]
        public void EnterWeight()
        {
            WaitHelper.WaitUntilClickable(driver, inputWeightLocator);
            var weightInput = new BaseElement(inputWeightLocator);
            weightInput.SetUpText(userData.Weight);
        }

        [AllureStep("Вводим Желаемый Вес")]
        public void EnterGoalWeight()
        {
            WaitHelper.WaitUntilClickable(driver, inputGoalWeightLocator);
            var weightInput = new BaseElement(inputGoalWeightLocator);
            weightInput.SetUpText(userData.GoalWeight);
        }

        [AllureStep("Вводим Возраст")]
        public void EnterAge()
        {
            var ageInput = new BaseElement(inputAgeLocator);
            ageInput.SetUpText(userData.Age);
        }

        [AllureStep("Выбираем опцию 'Home'")]
        public void SetHomeOption()
        {
            radioButtonElement = new RadioButtonElement(worckoutPlaceLocator);
            radioButtonElement.Select();
        }

        [AllureStep("Выбираем опцию 'Advanced'")]
        public void SetAdvancedOption()
        {
            radioButtonElement = new RadioButtonElement(gymLevelLocator);
            radioButtonElement.Select();
        }

        [AllureStep("Выбираем опцию '5+ Times per week'")]
        public void SetTimesToTrainOption()
        {
            radioButtonElement = new RadioButtonElement(timesToTrainLocator);
            radioButtonElement.Select();
        }

        [AllureStep("Выбираем опцию 'up to 30 mins'")]
        public void SetTrainLenghtOption()
        {
            radioButtonElement = new RadioButtonElement(trainLenghtLocator);
            radioButtonElement.Select();
        }

        [AllureStep("Выбираем опцию 'Tracker mode'")]
        public void SetModeOption()
        {
            radioButtonElement = new RadioButtonElement(startModeLocator);
            radioButtonElement.Select();
        }

        [AllureStep("Выбираем опцию 'Sensitive knees'")]
        public void SetLimitationsOption()
        {
            radioButtonElement = new RadioButtonElement(trainingLimitationsLocator);
            radioButtonElement.Select();
        }
    }
}
