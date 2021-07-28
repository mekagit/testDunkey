using DunkeyItTest.Helper.Waiters;
using DunkeyItTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DunkeyItTest.Steps.UiSteps
{
    [Binding]
    public sealed class ConfigurationUiSteps : BaseUISteps
    {
        private ConfigurationPage _configPage = null;

        [Given(@"I launch the application with go to Configuration page")]
        public void GivenLaunchTheApplicationAndGoToConfigurationPage()
        {
            WebDriver.Navigate().GoToUrl("http://localhost:9220/configuration");
            DriverWaiter.WaitForStateIsReady(WebDriver);

            _configPage = new ConfigurationPage(WebDriver);
        }

        [When(@"I set (.*) value to max file size field")] 
        public void WhenSetMaxSize(string size)
        {
            _configPage.SetFileSize(size);
        }

        [When(@"I set (.*) value to allowed file types")]
        public void WhenSetAllowedFileType(string types)
        {
            _configPage.SetAllowedFileType(types);
        }

        [When(@"I click save")]
        public void WhenClickSave()
        {
            _configPage.ClickSave();
        }
    }
}