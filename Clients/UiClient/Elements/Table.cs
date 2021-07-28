using System.Collections.Generic;
using System.Linq;
using DunkeyItTest.Helper.Waiters;
using DunkeyItTest.Pages.TableColumnNames;
using OpenQA.Selenium;

namespace DunkeyItTest.Clients.UiClient.Elements
{
    public class Table : BaseElement
    {
        private readonly By _rowsBy = By.XPath(".//tbody/tr");
        
        private IList<IWebElement> tableRows;
        
        public Table(IWebDriver driver, By by) : base(driver, by)
        {
        }

        protected IList<IWebElement> WaitForElements(By by)
            => ElementWaiter.WaitForElementDisplayed(()=> Driver.FindElements(by), $"The element {by} is not found");

        public IList<IWebElement> TableRows => this.tableRows ??= WaitForElements(_rowsBy);

        public string GetValue(int rowIndex)
        {
            var data = TableRows.ElementAt(rowIndex);
            return data.Text;
        }
    }
}
