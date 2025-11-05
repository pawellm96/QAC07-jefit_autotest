using OpenQA.Selenium;

namespace Jefit_test.SeleniumFramework
{
    public class RadioButtonElement : BaseElement
    {
        public RadioButtonElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }

        public bool IsSelected()
        {
            return Element.Selected;
        }

        public void Select()
        {
            if (!IsSelected())
            {
                ClickElement();
            }
        }
    }
}
