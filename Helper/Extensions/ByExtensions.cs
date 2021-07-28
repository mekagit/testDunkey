using OpenQA.Selenium;

namespace DunkeyItTest.Helper.Extensions
{
    public static class ByExtensions
    {
        public static By FormControlName(string name)
           => By.XPath($"//*[@formcontrolname='{name}']");
    }
}