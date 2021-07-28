using System;
using System.Threading;
using OpenQA.Selenium;

namespace DunkeyItTest.Helper.Waiters
{
    public static class DriverWaiter
    {
        public static void WaitForStateIsReady(IWebDriver driver, int timeOutSecond = 5, int delayMillisecond = 50)
        {
            var totalWaitingTime = 0;
            var timeOutMillisecond = timeOutSecond * 1000;

            do
            {
                try
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    var readyState = js.ExecuteScript("return document.readyState;").ToString();
                    if (readyState.ToLower().Equals("complete"))
                    {
                        return;
                    }
                }
                finally
                {
                    Thread.Sleep(delayMillisecond);
                    totalWaitingTime += delayMillisecond;
                }
            } while (totalWaitingTime < timeOutMillisecond);

            throw new Exception($"The state is not Completed, waiting time {timeOutSecond} second.");
        }
    }
}
