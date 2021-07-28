using OpenQA.Selenium;

namespace DunkeyItTest.Clients.UiClient.Elements
{
    public class TextElement : BaseElement
    {
        public TextElement(IWebDriver driver) : base(driver)
        {
        }

        public TextElement(IWebDriver driver, By @by) : base(driver, @by)
        {
        }

        public string GetValue =>
            Element.Text;
    }
}