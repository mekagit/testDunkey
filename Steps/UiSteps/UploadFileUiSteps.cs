using System.Collections.Generic;
using System.Linq;
using DunkeyItTest.Helper.Waiters;
using DunkeyItTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DunkeyItTest.Steps.UiSteps
{
    [Binding]
    public class UploadFileUiSteps : BaseUISteps
    {
        private UploadFilePage _uploadFilePage = null;

        [Given(@"I launch the application")]
        public void GivenLaunchTheApplication()
        {
            WebDriver.Navigate().GoToUrl("http://localhost:9220");
            DriverWaiter.WaitForStateIsReady(WebDriver);

            _uploadFilePage = new UploadFilePage(WebDriver);
        }

        [When(@"I set (.*) value to user name")]
        public void WhenSetUserName(string userName)
        {
            _uploadFilePage.SetUserName(userName);
        }

        [When(@"I upload file with name (.*)")]
        public void WhenUploadFile(string fileName)
        {
            _uploadFilePage.UploadFile(fileName);
        }

        [Then(@"Uploaded file displayed in table with (.*) user")]
        public void ThenUploadedFileDisplayedInTable(string user)
        {
            var rowData = _uploadFilePage.GetDataLastRow;
            Assert.Multiple(() =>
            {
                var arrayDataRow = rowData.Split(" ");
                if (arrayDataRow.All(d => !d.Equals(user)))
                {
                    throw new AssertionException($"Row in table dose not contains UserName {user}");
                }
            });
        }

        [Then(@"I see only (.*) format allowed error")]
        public void ISeeInvalidFormatError(string allowedFormat)
        {
            Assert.AreEqual($"Only {allowedFormat} formats allowed", _uploadFilePage.GetError().Trim());
        }

        [Then(@"I see Max allowed file (.*) size error")]
        public void ISeeMaxAllowedFileSizeError(string size)
        {
            Assert.AreEqual($"Maximum allowed file size is: {size} kb", _uploadFilePage.GetError().Trim());
        }
    }
}