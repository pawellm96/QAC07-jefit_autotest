using Allure.Net.Commons;
using Jefit_test.Utils;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Jefit_test.Tests
{
    public class Jefit_BaseTest
    {
        public IWebDriver driver;
        private ScreenshotUtils screenshotUtils;

        [SetUp]
        public void Setup()
        {
            driver = BrowserUtils.Driver;
            driver.Manage().Window.Maximize();
            screenshotUtils = new ScreenshotUtils();
        }

        [TearDown]
        public void TearDown()
        {
            var context = TestContext.CurrentContext;

            if (context.Result.Outcome.Status == TestStatus.Failed)
            {
                AllureLifecycle.Instance.UpdateTestCase(x =>
                {
                    x.attachments.Add(new Attachment
                    {
                        name = "Failure Screenshot",
                        type = "image/png",
                        source = screenshotUtils.SaveScreenshotAndReturnFileName()
                    });
                });
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            BrowserUtils.Quit();
        }
    }
}
