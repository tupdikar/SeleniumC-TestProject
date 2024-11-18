using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestConfigurator
{

    public class Browser
    {

        private IWebDriver webDriver;


        public static void BrowserInitilization()
        {

            IWebDriver Webdriver;
         
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArguments("----start --incognito");

            Webdriver = new ChromeDriver(@"C:\Automation Test Projects\Selenium C# Test Project\FlipKartPracticeProject\ChromeDriver\", chromeOptions);

            Webdriver.Navigate().GoToUrl("https://www.flipkart.com/");
            Webdriver.Manage().Window.Maximize();

         }
    }
}


