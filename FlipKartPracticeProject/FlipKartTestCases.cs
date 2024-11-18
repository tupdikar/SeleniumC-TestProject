using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using Landing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestCaseID;
using TestConfigurator;
using System;
using System.Collections.Generic;
using System.Net.Mail;


namespace FlipKartPracticeProject
{

    public class TestCases_FlipKart
    {
        IWebDriver Webdriver;
        public TestCases_FlipKart()
        {

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArguments("----start --incognito");

            Webdriver = new ChromeDriver(@"C:\Automation Test Projects\Selenium C# Test Project\FlipKartPracticeProject\ChromeDriver\", chromeOptions);

            Webdriver.Navigate().GoToUrl("https://www.flipkart.com/");
            Webdriver.Manage().Window.Maximize();

        }

        public static ExtentTest test;
        public static ExtentReports extent;
        public static string ExtentReportPath;

        [OneTimeSetUp]
        public void ExtentStart()
        {

            //Extent report setup
            extent = new ExtentReports();
            ExtentReportPath = "C:\\Automation Test Projects\\Selenium C# Test Project\\FlipKartPracticeProject\\Test Reports\\" + "Test Results.html";
            ExtentSparkReporter spark = new ExtentSparkReporter(ExtentReportPath);
            extent.AttachReporter(spark);

        }


        [OneTimeTearDown]
        public void Cleanup()
        {
            Webdriver.Close();
            Webdriver.Quit();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        [Test]
        public void Sr01_LandingPageVerification()
        {
            test = extent.CreateTest(FlipkartTestCaseID.TC01).Info("Test Started");

            LandingPage.PageObjectModelMethods LandingPageNew = new LandingPage.PageObjectModelMethods(Webdriver);

            LandingPageNew.LandingPageLogoAndHeader();

            test.Pass("Test Case Passed:Landing page verified successfully");
        }

        [Test]
        public void Sr02_UserLogin()
        {

             test = extent.CreateTest(FlipkartTestCaseID.TC02).Info("Test Started");
            LandingPage.PageObjectModelMethods Landing = new LandingPage.PageObjectModelMethods(Webdriver);
            string userid = "8421147865";
            Landing.LoginProccess(userid);

            test.Pass("Login Successful");

        }


    }
}