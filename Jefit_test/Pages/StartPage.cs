using Jefit_test.Utils;

namespace Jefit_test.Pages
{
    internal class StartPage : BasePage
    {
        public void OpenPage()
        {
            BrowserUtils.OpenPage("https://www.jefit.com/");
        }
    }
}
