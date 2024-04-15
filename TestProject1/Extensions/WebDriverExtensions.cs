using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement Wait(this IWebDriver driver, Func<IWebDriver, IWebElement> condition, int timeout = 25)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(condition);
        }

        public static WebDriverWait WebDriverWait(this IWebDriver driver)
        {
            return new WebDriverWait(driver, new TimeSpan(0, 0, 25));
        }

        public static void ScrollIntoView(this IWebElement element, IWebDriver driver, bool alignToTop = true)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(" + alignToTop.ToString().ToLower() + ");", element);
        }

        public static IWebElement WaitUntilElementVisible(IWebDriver Driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
    }
}