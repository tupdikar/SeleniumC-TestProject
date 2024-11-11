using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Landing
{

    class LandingPage

    {

        //Landing page

        public static By LandingPageLogo = By.XPath("//*[@id=\"container\"]/div/div[1]/div/div/div/div/div[1]/div/div/div/div[1]/div[1]/header/div[1]/div[1]/a/picture/img");
        public static By LandingPageGroceryLable = By.XPath("//*[@id=\"container\"]/div/div[1]/div/div/div/div/div[1]/div/div/div/div[2]/div[1]/div/div[1]/div/div/div/div/div[1]/a[1]/div/div/span");
        public static By LandingPageMobileLable = By.XPath("//*[@id=\"container\"]/div/div[1]/div/div/div/div/div[1]/div/div/div/div[2]/div[1]/div/div[1]/div/div/div/div/div[1]/a[2]/div/div/span/span");
        public static By LoginButton = By.XPath("//*[@id=\"container\"]/div/div[1]/div/div/div/div/div[1]/div/div/div/div[1]/div[1]/header/div[2]/div[2]/div/div/div/div/a/span");
        public static By LoginInputUserId = By.XPath("//*[@id=\"container\"]/div/div[3]/div/div[2]/div/form/div[1]/input");
        public static By LoginPageHeader = By.XPath("//*[@id=\"container\"]/div/div[3]/div/div[1]/span/span");
        public static By LoginPageSubHeader = By.XPath("//*[@id=\"container\"]/div/div[3]/div/div[1]/p/span");
        public static By RequestOptButton = By.XPath("/html/body/div[3]/div/div/div/div[2]/div/form/div[3]/button");
        public static By VerifyOtpButton = By.XPath("/html/body/div[3]/div/div/div/div[2]/div/div/form/button");

        public class PageObjectModelMethods
        {

            IWebDriver webDriver;

            public PageObjectModelMethods(IWebDriver driver)
            {
                this.webDriver = driver;
            }

            public void PageRefresh()
            {
                webDriver.Navigate().Refresh();

            }
            public void LandingPageSwitchURL(string URL)
            {

                webDriver.Navigate().GoToUrl(URL);
                Thread.Sleep(4000);
            }

            public void TakeScreenShotLanding(string ScrShootPath)
            {

                // Take screen shots
                string ScrTimeStamp = "." + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".";
                string ScreenShootPath;
                ScreenShootPath = ScrShootPath + "\\LandingPage";


                //try
                //{
                //    webDriver.FindElement(CookieCloseBtn).Click();
                //    Thread.Sleep(4000);
                //    VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting());
                //    webDriver.TakeScreenshot(vcd).ToMagickImage().ToBitmap().Save(ScreenShootPath + ScrTimeStamp + System.Drawing.Imaging.ImageFormat.Png);
                //}

                //catch (Exception)
                //{
                //    Thread.Sleep(4000);
                //    VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting());
                //    webDriver.TakeScreenshot(vcd).ToMagickImage().ToBitmap().Save(ScreenShootPath + ScrTimeStamp + System.Drawing.Imaging.ImageFormat.Png);
                //};
            }



            public List<string> LandingPageLogoAndHeader()
            {
                TimeSpan sp = TimeSpan.FromSeconds(15);
                WebDriverWait wait = new WebDriverWait(this.webDriver, sp);

                try
                {
                    wait.Until(driver => driver.FindElement(LandingPageLogo));
                    wait.Until(driver => driver.FindElement(LandingPageGroceryLable));
                }

                catch (Exception)
                {
                    webDriver.Navigate().Refresh();
                    wait.Until(driver => driver.FindElement(LandingPageLogo));
                    wait.Until(driver => driver.FindElement(LandingPageGroceryLable));

                };

                List<string> listVal = new List<string>
                {
                     webDriver.FindElement(LandingPageGroceryLable).Text,
                     webDriver.FindElement(LandingPageMobileLable).Text
                };
                return listVal;
            }

            public List<string> LoginProccess(string userid)
            {
                TimeSpan sp = TimeSpan.FromMilliseconds(15000);
                WebDriverWait wait = new WebDriverWait(this.webDriver, sp);

                wait.Until(driver => driver.FindElement(LandingPageLogo));
                wait.Until(driver => driver.FindElement(LoginButton));

                webDriver.FindElement(LoginButton).Click();
                webDriver.FindElement(LoginInputUserId).SendKeys(userid);
                webDriver.FindElement(RequestOptButton).Click();

                List<string> listVal = new List<string>
                {
                    webDriver.FindElement(LoginPageHeader).Text,
                    webDriver.FindElement(LoginPageSubHeader).Text
                };

                return listVal;
            }



        }

    }
}
