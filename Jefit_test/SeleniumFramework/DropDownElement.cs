using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Jefit_test.SeleniumFramework;

public class DropDownElement : BaseElement
{
    public DropDownElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }

    public void SelectOptionsByText(string text)
    {
        var select = new SelectElement(Element);
        select.SelectByText(text);
    }

    public void SelectOptionsByValue(string value)
    {
        var select = new SelectElement(Element);
        select.SelectByValue(value);
    }

    public string GetSelectedOption()
    {
        var select = new SelectElement(Element);
        return select.SelectedOption.Text;
    }
}