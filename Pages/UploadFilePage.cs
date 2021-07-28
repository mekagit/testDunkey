using System.IO;
using System.Threading;
using DunkeyItTest.Clients.UiClient.Elements;
using DunkeyItTest.Pages.TableColumnNames;
using OpenQA.Selenium;

namespace DunkeyItTest.Pages
{
    public class UploadFilePage : BasePage
    {
        #region Locators

        private TextElement UploadError => new TextElement(Driver, By.ClassName("upload-error"));
       
        private Table TenantTable => new Table(Driver, By.XPath("//table"));
       
        private FieldElement UserNameFieldElement => new FieldElement(Driver, By.XPath("//input[@placeholder='User Name']"));

        private UploadFieldElement UploadFieldElement => new UploadFieldElement(Driver, By.XPath("//input[@type='file']"));

        private ButtonElement UploadButtonElement => new ButtonElement(Driver, By.XPath("//button[text()='Upload File']"));
        #endregion

        public UploadFilePage(IWebDriver driver) : base(driver)
        {
        }

        public UploadFilePage SetUserName(string userName)
        {
            UserNameFieldElement.SetText(userName);
            return this;
        }

        public UploadFilePage ClickOnUploadButton()
        {
            UploadButtonElement.Click();
            return this;
        }

        public UploadFilePage UploadFile(string fileName)
        {
            var filePath = Path.GetFullPath(Path.Combine(Thread.GetDomain().BaseDirectory, $"Files\\{fileName}"));
            UploadFieldElement.UploadFile(filePath);

            return this;
        }

        public string GetError()
        {
            return UploadError.GetValue;
        }

        public string GetDataLastRow
        {
            get
            {
                var rowCount = TenantTable.TableRows.Count;
                var rowData = TenantTable.GetValue(rowCount - 1);
                
                return rowData;
            }
        }
    }
}