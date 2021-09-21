using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using OtpNet;
using System.Buffers.Text;

namespace LoginAutomation
{
    public class Automation
    {
        private readonly IWebDriver webDriver;

        public Automation(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Login(string username, string password)
        {
            webDriver.Url = "https://sample-project.tech-stack.dev/login";
            var input = webDriver.FindElement(By.Id("email"));
            input.SendKeys(username);
            input = webDriver.FindElement(By.Id("password"));
            input.SendKeys(password);
            ClickAndWaitForPageToLoad(webDriver, By.Id("button"));
        }

        private void ClickAndWaitForPageToLoad(IWebDriver driver, 
            By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var elements = driver.FindElements(elementLocator);
                if (elements.Count == 0)
                {
                    throw new NoSuchElementException(
                        "No elements " + elementLocator + " ClickAndWaitForPageToLoad");
                }
                var element = elements.FirstOrDefault(e => e.Displayed);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine(
                    "Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
    }
}
