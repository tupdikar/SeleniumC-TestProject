using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Support.Extensions;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;


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
        public static By RequestOptButton = By.XPath("//*[@id=\"container\"]/div/div[3]/div/div[2]/div/form/div[3]/button");
        public static By VerifyOtpButton = By.XPath("//*[@id=\"container\"]/div/div[3]/div/div[2]/div/div/form/button");

        public class PageObjectModelMethods

        {

            private IWebDriver webDriver;

            public PageObjectModelMethods(IWebDriver driver)
            {
                webDriver = driver;
            }


            public void LandingPageLogoAndHeader()
            {

                    webDriver.FindElement(LandingPageLogo);
                    webDriver.FindElement(LandingPageGroceryLable);

            }

            public void LoginProccess(string userid)
            {

                webDriver.FindElement(LandingPageLogo);
                webDriver.FindElement(LoginButton);

                webDriver.FindElement(LoginButton).Click();
                webDriver.FindElement(LoginInputUserId).SendKeys(userid);
                webDriver.FindElement(RequestOptButton).Click();

            }



        }

    }
}