using DunkeyItTest.Clients.UiClient.Elements;
using DunkeyItTest.Helper.Waiters;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DunkeyItTest.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        private ButtonElement HomeButtonElement => new ButtonElement(Driver, By.XPath("//a[text()='Home']"));

        protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            DriverWaiter.WaitForStateIsReady(driver);
        }

        public UploadFilePage ClickOneHomeButton()
        {
            HomeButtonElement.Click();
            return new UploadFilePage(Driver);
        }
    }
}