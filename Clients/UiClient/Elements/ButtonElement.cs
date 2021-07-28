using OpenQA.Selenium;

namespace DunkeyItTest.Clients.UiClient.Elements
{
    public class ButtonElement : BaseElement
    {
        public ButtonElement(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public ButtonElement Click()
        {
            Element.Click();
            return this;
        }
    }
}
