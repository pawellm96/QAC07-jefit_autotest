using OpenQA.Selenium;

namespace Jefit_test.Utils
{
    public class ScreenshotUtils
    {
        protected IWebDriver driver = BrowserUtils.Driver;

        public string SaveScreenshotAndReturnFileName()
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = $"screenshot_{Guid.NewGuid()}.png";
            var filePath = Path.Combine("allure-results", fileName);
            screenshot.SaveAsFile(filePath);
            return fileName;
        }
    }
}
