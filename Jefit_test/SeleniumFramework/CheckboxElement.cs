using OpenQA.Selenium;

namespace Jefit_test.SeleniumFramework;

public class CheckboxElement : BaseElement
{
    public CheckboxElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }

    public bool IsChecked()
    {
        return Element.Selected;
    }

    public void SetChecked(bool value)
    {
        if (!IsChecked())
        {
            ClickElement();
        }
    }
}