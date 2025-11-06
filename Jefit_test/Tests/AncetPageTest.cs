using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Jefit_test.Pages;
using Jefit_test.Utils;

namespace Jefit_test.Tests
{
    [TestFixture]
    [AllureTag("smoke")]
    [AllureOwner("Pavel")]
    [AllureNUnit]
    public class AncetPageTest : Jefit_BaseTest
    {
        private AncetPage ancetPage = new AncetPage();

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("SuccessfulOpeningAncetPage")]
        [AllureStep("Проверка открытия страницыы с анкетой перед регистрацыей")]
        public void SetUserParameters()
        {
            ancetPage.OpenAncetPage();
            Assert.That(driver.Url, Is.EqualTo(Links.AncetPage), $"Проверка начальной страницы");
            ancetPage.WaitForPageToLoad();
            Assert.That(ancetPage.IsOnStage("Select your gender"), Is.True, "Страница должна находится на этапе 'Select your gender'");
            ancetPage.SetMale();
            ancetPage.SetEnduranceOption();
            ancetPage.SetAverageOption();
            ancetPage.SetBodyTypeOption();
            ancetPage.SetBodyPart();
            ancetPage.CLickSubmit();
            ancetPage.SetIntermediateOption();
            ancetPage.SetSIOption();
            ancetPage.EnterHeight();
            ancetPage.CLickSubmit();
            ancetPage.EnterWeight();
            ancetPage.CLickSubmit();
            ancetPage.EnterGoalWeight();
            ancetPage.CLickSubmit();
            ancetPage.EnterAge();
            ancetPage.CLickSubmit();
            ancetPage.SetHomeOption(); 
            ancetPage.SetAdvancedOption();
            ancetPage.SetTimesToTrainOption();
            ancetPage.SetTrainLenghtOption();
            ancetPage.SetModeOption();
            ancetPage.SetLimitationsOption();
            ancetPage.WaitUntilLoading(Links.ResultPage, 10);
            Assert.That(driver.Url, Is.EqualTo(Links.ResultPage), $"По завершению заполнения формы должна открыться страница результата");
        }
    }
}
