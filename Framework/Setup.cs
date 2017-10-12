using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using log4net;

namespace UnitTestProject1
{
    [TestClass]
    public class Setup
    {
        static IWebDriver driver;

        [TestMethod]
        public void TestMethod1()
        {
            driver = new ChromeDriver();
            WebUtility webUtil = new WebUtility();
            LoggerUtility logUtil = new LoggerUtility();
            logUtil.clearFiles();
            driver.Navigate().GoToUrl("http://www.google.com");
            logUtil.ExtentReport_init_Report("Setup");
            logUtil.log4j_intialize("Setup");
            logUtil.captureScreenshot(driver, "firstSS");
            logUtil.ExtentReport_Info("Info", driver, "firstSS");
            logUtil.log4j_loginfo("Captured Info SS");
            logUtil.ExtentReport_Pass("Pass", driver, "Pass");
            logUtil.log4j_loginfo("Captured Pass SS");
            logUtil.ExtentReport_Fail("Fail", driver, "Fail");
            logUtil.log4j_loginfo("Captured Fail SS");
            logUtil.ExtentReport_EndTest();
            webUtil.log("Sample text");
            
        }
    }
}
