    using OpenQA.Selenium;

    namespace Jefit_test.SeleniumFramework;

    public class InputElement : BaseElement
    {
        public InputElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }

        public bool IsReadOnly()
        {
            return bool.Parse(GetAttributeValue("value"));
        }
    }