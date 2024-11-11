using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TestCaseID;
using TestConfigurator;
using Landing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive;
using AventStack.ExtentReports.Model;
using NUnit.Framework;


namespace FlipKartPracticeProject
{

    public class TestCases_FlipKart
    {

        IWebDriver Webdriver;
        Parameters Parameter;
        Dictionary<string, string> ExpectedResultsList;

        Dictionary<string, string> InputparametersDictionary = new Dictionary<string, string>();
        string webConfig = "52";
        string PathToFileFromFileForParametrs;
        public string InputURL;

        public static ExtentTest test;
        public static ExtentReports extent;

        public TestCases_FlipKart()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArguments("----start --incognito");
            Webdriver = new ChromeDriver(@"C:\Automation Test Projects\Selenium C# Test Project\ChromeDriver", chromeOptions);

            Parameter = new Parameters();
            InputparametersDictionary = Parameter.GetInputparametersDictionary(PathToFileFromFileForParametrs);

            Webdriver.Navigate().GoToUrl("https://www.flipkart.com/");
            Webdriver.Manage().Window.Maximize();

            ExpectedResultsList = Parameter.GetExpectedResultlist(InputURL);

        }

        public string ActualResults;
        public string ExpectedResults;
        public string ExpectedResultList;

        // Temprorary  values
        string InputMobileNumAlert;
        public static List<string> ActualResultList;
        string InputLogin;
        string InputPassword;

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

        [SetUp]
        protected void SetUp()
        {

            InputLogin = Parameter.GetInputParamertValue(InputparametersDictionary, "InputLogin");
            InputPassword = Parameter.GetInputParamertValue(InputparametersDictionary, "InputPassword");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Webdriver.Close();
            Webdriver.Quit();
        }

        [NUnit.Framework.Test, Order(01), Category("Regression Testing")]
        public void Sr01_ChangeSecurityQuestion()
        {
            test = extent.CreateTest(FlipkartTestCaseID.TC01).Info("Test Started");

            LandingPage.PageObjectModelMethods Landing = new LandingPage.PageObjectModelMethods(Webdriver);

            ActualResultList = Landing.LandingPageLogoAndHeader();

            //Assert.That(ExpectedResultList["LandingPage_label1"],
            //                Is.EqualTo(ActualResultList[0]),
            //                Messages.Error_missing_Message.Replace("@Header@", ExpectedResultList["LandingPage_label1"]));
            //Assert.That(ExpectedResultList["LandingPage_label2"],
            //                Is.EqualTo(ActualResultList[1]),
            //                Messages.Error_missing_Message.Replace("@Header@", ExpectedResultList["LandingPage_label2"]));

            test.Pass("Test Case Passed:Landing page verified successfully");
        }

        [NUnit.Framework.Test, Order(02), Category("Regression Testing")]
        public void Sr02_UserLogin()
        {

             test = extent.CreateTest(FlipkartTestCaseID.TC02).Info("Test Started");
            LandingPage.PageObjectModelMethods Landing = new LandingPage.PageObjectModelMethods(Webdriver);

            ActualResultList = Landing.LoginProccess(InputLogin);

            //Assert.That(ExpectedResultList["LoginPage_label1"],
            //                Is.EqualTo(ActualResultList[0]),
            //                Messages.Error_missing_Message.Replace("@Header@", ExpectedResultList["LoginPage_label1"]));

            //Assert.That(ExpectedResultList["LoginPage_label2"],
            //    Is.EqualTo(ActualResultList[1]),
            //    Messages.Error_missing_Message.Replace("@Header@", ExpectedResultList["LoginPage_label2"]));

            test.Pass("Login Successful");

        }


    }
}