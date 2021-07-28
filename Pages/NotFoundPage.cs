using DunkeyItTest.Clients.UiClient.Elements;
using OpenQA.Selenium;

namespace DunkeyItTest.Pages
{
    public class NotFoundPage : BasePage
    {
        #region Locators
        private ButtonElement BackToHomeButtonElement => new ButtonElement(Driver, By.XPath(""));
        #endregion

        public NotFoundPage(IWebDriver driver) : base(driver)
        {
        }

    }
}