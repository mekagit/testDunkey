using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace DunkeyItTest.Steps.UiSteps
{
    public abstract class BaseUISteps
    {
        protected readonly IWebDriver WebDriver;

        protected BaseUISteps()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriver.Quit();
        }
    }
}