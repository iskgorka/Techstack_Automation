static void Main(string[] args)
{
    var webDriver = LaunchBrowser();
    try
    {
        var Automation = new Automation(webDriver);
        facebookAutomation.Login("email", "password");
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