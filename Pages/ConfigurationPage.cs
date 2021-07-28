using DunkeyItTest.Clients.UiClient.Elements;
using DunkeyItTest.Helper.Extensions;
using OpenQA.Selenium;

namespace DunkeyItTest.Pages
{
    public class ConfigurationPage : BasePage
    {
        #region Locators

        private FieldElement FileSizeFieldElement => new FieldElement(Driver, ByExtensions.FormControlName("maximumSize"));

        private FieldElement AllowedFileTypeFieldElement => new FieldElement(Driver, ByExtensions.FormControlName("allowedFormats"));

        private ButtonElement SaveButtonElement => new ButtonElement(Driver, By.XPath("//button[text()='Save']"));
        #endregion

        public ConfigurationPage(IWebDriver driver) : base(driver)
        {
        }

        public ConfigurationPage SetFileSize(string size)
        {
            FileSizeFieldElement.SetText(size);
            return this;
        }

        public ConfigurationPage SetAllowedFileType(string allowedFileType)
        {
            AllowedFileTypeFieldElement.SetText(allowedFileType);
            return this;
        }

        public ConfigurationPage ClickSave()
        {
            SaveButtonElement.Click();
            return this;
        }
    }
}