using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace DunkeyItTest.Helper.Waiters
{
    public static class ElementWaiter
    {
        /// <summary>
        /// </summary>
        /// <param name="action">Wait for Find Element not empty and Displayed</param>
        /// <param name="timeOutSecond"></param>
        /// <param name="delayMillisecond"></param>
        /// <returns></returns>
        public static IList<IWebElement> WaitForElementDisplayed(Func<IList<IWebElement>> action, string message, int timeOutSecond = 8, int delayMillisecond = 50)
        {
            var totalWaitingTime = 0;
            var timeOutMillisecond = timeOutSecond * 1000;

            do
            {
                try
                {
                    var condition = action.Invoke();
                    if (condition.Any() && condition.First().Displayed)
                    {
                        return condition;
                    }
                }
                catch (NoSuchElementException) { }
                finally
                {
                    Thread.Sleep(delayMillisecond);
                    totalWaitingTime += delayMillisecond;
                }
            } while (totalWaitingTime < timeOutMillisecond);

            throw new Exception($"{message}, waiting time {timeOutSecond} second.");
        }

        public static IWebElement WaitForElementEnabled(Func<IWebElement> action, string message, int timeOutSecond = 8, int delayMillisecond = 50)
        {
            var totalWaitingTime = 0;
            var timeOutMillisecond = timeOutSecond * 1000;

            do
            {
                try
                {
                    var condition = action.Invoke();
                    if (condition.Enabled)
                    {
                        return condition;
                    }
                }
                catch (NoSuchElementException) { }
                finally
                {
                    Thread.Sleep(delayMillisecond);
                    totalWaitingTime += delayMillisecond;
                }
            } while (totalWaitingTime < timeOutMillisecond);

            throw new Exception($"{message}, waiting time {timeOutSecond} second.");
        }


        public static IWebElement WaitForElementDisplayed(Func<IWebElement> action, string message, int timeOutSecond = 8, int delayMillisecond = 50)
        {
            var totalWaitingTime = 0;
            var timeOutMillisecond = timeOutSecond * 1000;

            do
            {
                try
                {
                    var condition = action.Invoke();
                    if (condition.Displayed)
                    {
                        return condition;
                    }
                }
                catch (NoSuchElementException) { }
                finally
                {
                    Thread.Sleep(delayMillisecond);
                    totalWaitingTime += delayMillisecond;
                }
            } while (totalWaitingTime < timeOutMillisecond);

            throw new Exception($"{message}, waiting time {timeOutSecond} second.");
        }
    }
}
