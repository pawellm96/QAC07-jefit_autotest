using OpenQA.Selenium;

namespace Jefit_test.SeleniumFramework;

public class FrameElement : BaseElement
{
    public FrameElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }

    public void SwitchToFrame()
    {
        Driver.SwitchTo().Frame(Element);
    }

    public void SwitchToDefaultContext()
    {
        Driver.SwitchTo().DefaultContent();
    }

    public void SwitchToParentFrame()
    {
        Driver.SwitchTo().ParentFrame();
    }
}