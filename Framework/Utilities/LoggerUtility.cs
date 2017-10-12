using log4net.Config;
using log4net;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.IO;

class LoggerUtility
{
    public static String filename = "log.txt";
    public static String file = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\" + filename;
    public static String myDir = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Screenshots";
    public static String report = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Reports";

    public static ExtentReports extent;
    public static ExtentTest test;
    public static ILog logger;
    

    public LoggerUtility()
    {
        Console.WriteLine(file);
        try
        {
            if (!File.Exists(file))
            {
                File.Create(file);
                Console.WriteLine("Empty Log File is created");
            }
            else
            {
                File.WriteAllText(file, string.Empty);
                Console.WriteLine("Log File already exist, contents are cleared.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }


    public String returnFilePath()
    {
        return file;
    }
        
    public void clearFiles()
    {        
        //Create an empty screenshots folder
        try {
            System.IO.Directory.CreateDirectory(myDir);
            System.IO.Directory.CreateDirectory(report);
        }
        catch (IOException e)
        {
            Console.WriteLine("Exception while creating Screenshots folder");
            Console.WriteLine(e.Message);
        }

        //clearing the contents of the folder
        string[] filePaths = Directory.GetFiles(myDir);
        foreach (string filePath in filePaths)
            File.Delete(filePath);
    }

    public String captureScreenshot(IWebDriver driver, String ssName)
    {
        String dest = myDir +"\\"+ ssName + ".png";
        try
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot sc = ts.GetScreenshot();
            sc.SaveAsFile(dest, ScreenshotImageFormat.Png);
        }
        catch (Exception e)
        {
            //logger.log(LogStatus.INFO, "Exception while taking Screenshot");
            Console.WriteLine(e.Message);
            return null;
        }
        return dest;
        //Console.WriteLine("Captured Screenshot");
    }

    public void log_initialize()
    {
            
    }

   public void ExtentReport_init_Report(String className)
    {
        //String fname = new SimpleDateFormat("yyyyMMddHHmss").format(new Date()) + className + "_Report";
        Console.WriteLine("in init report method");
        extent = new ExtentReports(report+"\\ExtentReport.html",true);
        Console.WriteLine("Extent object created");
        test = extent.StartTest(className);
        Console.WriteLine("extent test obj created");
        //logger = report.startTest(className);
        Console.WriteLine("logger created is "+test);
    }

    public void ExtentReport_Info(String message, IWebDriver driver, String ssName)
    {
        String ssPath = captureScreenshot(driver, ssName);
        test.Log(LogStatus.Info,message,message+ test.AddScreenCapture(ssPath));

    }

    public void ExtentReport_Pass(String message, IWebDriver driver, String ssName)
    {
        String ssPath = captureScreenshot(driver, ssName);
        test.Log(LogStatus.Pass, message, message + test.AddScreenCapture(ssPath));
    }

    public void ExtentReport_Fail(String message, IWebDriver driver, String ssName)
    {
        String ssPath = captureScreenshot(driver, ssName);
        test.Log(LogStatus.Fail, message, message + test.AddScreenCapture(ssPath));
    }

    public void ExtentReport_EndTest()
    {
        extent.Flush();
        extent.EndTest(test);
    }

    public void log4j_intialize(String className)
    {
        BasicConfigurator.Configure();
        logger = LogManager.GetLogger(className);
    }

    public void log4j_loginfo(String message)
    {
        logger.Info(message);
    }
   

}

