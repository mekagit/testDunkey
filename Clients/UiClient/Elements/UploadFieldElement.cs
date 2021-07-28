using DunkeyItTest.Helper.Waiters;
using OpenQA.Selenium;

namespace DunkeyItTest.Clients.UiClient.Elements
{
    public class UploadFieldElement : BaseElement
    {
        public UploadFieldElement(IWebDriver driver) : base(driver)
        {
        }

        public UploadFieldElement(IWebDriver driver, By @by) : base(driver, @by)
        {
        }

        protected override IWebElement WaitForElement(By by)
            => ElementWaiter.WaitForElementEnabled(() => Driver.FindElement(by), $"The element {by} is not found");

        public UploadFieldElement UploadFile(string filePath)
        {
            Element.SendKeys(filePath);
            return this;
        }
    }
}