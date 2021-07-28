using DunkeyItTest.Helper.Waiters;
using OpenQA.Selenium;

namespace DunkeyItTest.Clients.UiClient.Elements
{
    public abstract class BaseElement
    {
        protected IWebElement Element;
        protected IWebDriver Driver;

        protected BaseElement(IWebDriver driver)
        {
            this.Driver = driver;
        }

        protected BaseElement(IWebDriver driver, By by)
        {
            this.Driver = driver;
            this.Element = WaitForElement(by);
        }

        protected virtual IWebElement WaitForElement(By by)
            => ElementWaiter.WaitForElementDisplayed(() => Driver.FindElement(by), $"The element {by} is not found");
    }
}
