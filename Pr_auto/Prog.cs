using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace LoginAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            var webDriver = LaunchBrowser();
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing automation");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                webDriver.Quit();
            }
        }

        static IWebDriver LaunchBrowser()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

            var driver = new ChromeDriver(Environment.CurrentDirectory, options);
            return driver;
        }
    }
}