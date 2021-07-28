using System.Threading;
using DunkeyItTest.Clients.ApiClient.Models;
using DunkeyItTest.Constants;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DunkeyItTest.Steps.ApiSteps
{
    [Binding]
    public class ConfigurationApiSteps : BaseApiSteps
    {
        private void WaitUntilAppliedConfigurationChanges(string configName, string configValue)
        {
            int iteration = 0;
            while (iteration != 10)
            {
                var config = Client.GetConfiguration(configName);
                if (config.ConfigurationValue == configValue)
                {
                    return;
                }

                iteration++;
                Thread.Sleep(200);
            }
        }

        [Given(@"I set (.*) file max value")]
        public void GivenSetFileMaxValue(string maxSize)
        {
            var requestModel = new ConfigurationRequestModel
            {
                ConfigurationName = ConfigurationName.MaxAllowedSize,
                ConfigurationValue = maxSize
            };
            Client.UpdateConfiguration(requestModel);
            WaitUntilAppliedConfigurationChanges(ConfigurationName.MaxAllowedSize, maxSize);
        }

        [Given(@"I set (.*) allowed file types")]
        public void GivenSetAllowedFileTypes(string allowedFileTypes)
        {
            var requestModel = new ConfigurationRequestModel
            {
                ConfigurationName = ConfigurationName.AllowedFileType,
                ConfigurationValue = allowedFileTypes
            };
            Client.UpdateConfiguration(requestModel);
            WaitUntilAppliedConfigurationChanges(ConfigurationName.AllowedFileType, allowedFileTypes);
        }

        [Then(@"I max value is (.*) and allowed file type are (.*)")]
        public void ThenAssertFields(string maxSize, string allowedTypes)
        {
            var actualFileFormat = Client.GetConfiguration(ConfigurationName.AllowedFileType);
            var actualMaxSize = Client.GetConfiguration(ConfigurationName.MaxAllowedSize);
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(maxSize, actualMaxSize.ConfigurationValue, "The file size is not saved");
                Assert.AreEqual(allowedTypes, actualFileFormat.ConfigurationValue, "The allowed file type is not saved");
            });
        }
    }
}