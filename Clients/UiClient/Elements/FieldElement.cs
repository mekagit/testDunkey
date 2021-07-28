using OpenQA.Selenium;

namespace DunkeyItTest.Clients.UiClient.Elements
{
    public class FieldElement : BaseElement
    {
        public FieldElement(IWebDriver driver) : base(driver)
        {
        }

        public FieldElement(IWebDriver driver, By by): base(driver, by)
        {
        }

        public FieldElement SetText(string text)
        {
            Element.Clear();
            Element.SendKeys(text);
            return this;
        }
    }
}
