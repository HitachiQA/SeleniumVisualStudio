using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WebUtility
{
    static TextWriter tw;
    Boolean logfile = false;

    public WebUtility()
    {
        LoggerUtility log = new LoggerUtility();
        String fpath = log.returnFilePath();
                

        try
        {
            tw = new StreamWriter(fpath);
            //tw.WriteLine("The very first line!");
            logfile = true;
            Console.WriteLine("Log file accessible to write");
            log.clearFiles();
        }
        catch (IOException e)
        {
            Console.WriteLine("Exception in accessing the file to write");
            Console.Write(e.StackTrace);
        }

    }

    public void log(String message)
    {
        if (logfile)
        {
            try
            {
                tw.WriteLine(message);
                tw.Flush();
            }
            catch (IOException e)
            {
                Console.Write(e.StackTrace);
            }
        }
    }

    //enter text in a text box 
    //identifierType : id, name, xpath etc
    //identifier: value of id, name , xpath etc sent from calling function
    public Exception EnterTextValue(String textVal, String identifier, IWebDriver driver, String field, String identifierType)
    {
        //System.out.println("Inside EnterText Value function");
        Console.WriteLine(identifier);
        switch (identifierType)
        {
            case "id":
                //enterTextUsingID(textVal,identifier,driver,field);
                try
                {
                    driver.FindElement(By.Id(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from EnterTextValue using id for field " + field);
                    Console.WriteLine(e.Message);
                    return e;
                }
                driver.FindElement(By.Id(identifier)).SendKeys(textVal);
                break;
            case "name":
                try
                {
                    driver.FindElement(By.Name(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from EnterTextValue using name for field " + field);
                    return e;
                }
                driver.FindElement(By.Name(identifier)).SendKeys(textVal);
                //enterTextUsingName(textVal,identifier,driver,field);
                break;
            case "xpath":
                try
                {
                    driver.FindElement(By.XPath(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from EnterTextValue using xpath for field " + field);
                    return e;
                }
                driver.FindElement(By.XPath(identifier)).SendKeys(textVal);
                //enterTextUsingXpath(textVal,identifier,driver,field);
                break;
            case "classname":
                try
                {
                    driver.FindElement(By.ClassName(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from EnterTextValue using className for field " + field);
                    return e;
                }
                driver.FindElement(By.ClassName(identifier)).SendKeys(textVal);
                break;
        }
        log("Entered " + textVal + " in : " + field);
        return null;
    }

    //clicks a button 
    //identifierType : id, name, xpath etc
    //identifier: value of id, name , xpath etc sent from calling function
    public Exception ClickButton(String identifier, IWebDriver driver, String field, String identifierType)
    {

        switch (identifierType)
        {
            case "id":
                try
                {
                    driver.FindElement(By.Id(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickButton using id " + field);
                    return e;
                }
                driver.FindElement(By.Id(identifier)).Click();
                break;
            case "name":
                try
                {
                    driver.FindElement(By.Name(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickButton using name " + field);
                    return e;
                }
                driver.FindElement(By.Name(identifier)).Click();
                break;
            case "xpath":
                try
                {
                    driver.FindElement(By.XPath(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickButton using xpath " + field);
                    return e;
                }
                driver.FindElement(By.XPath(identifier)).Click();
                break;
            case "classname":
                try
                {
                    driver.FindElement(By.ClassName(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickButton using className " + field);
                    return e;
                }
                driver.FindElement(By.ClassName(identifier)).Click();
                break;
        }
        log("Clicked on button - " + field);
        return null;
    }


    //clicks a link 
    //identifierType : id, name, xpath etc
    //identifier: value of id, name , xpath etc sent from calling function
    public Exception ClickLink(String identifier, IWebDriver driver, String field, String identifierType)
    {

        switch (identifierType)
        {
            case "id":
                try
                {
                    driver.FindElement(By.Id(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickLink using id " + field);
                    return e;
                }
                driver.FindElement(By.Id(identifier)).Click();
                //clickLinkUsingId(identifier,driver,field);
                break;
            case "text":
                try
                {
                    driver.FindElement(By.LinkText(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickLink using text " + field);
                    return e;
                }
                driver.FindElement(By.LinkText(identifier)).Click();
                break;
            //clickLinkUsingLinkText(identifier,driver,field);				
            case "partialtext":
                try
                {
                    driver.FindElement(By.PartialLinkText(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickLink using partialLinkText " + field);
                    return e;
                }
                driver.FindElement(By.PartialLinkText(identifier)).Click();
                //clickLinkUsingPartialText(identifier, driver, field);
                break;
            case "xpath":
                try
                {
                    driver.FindElement(By.XPath(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickLink using xpath " + field);
                    return e;
                }
                driver.FindElement(By.XPath(identifier)).Click();
                //clickLinkUsingXpath(identifier,driver,field);
                break;
        }
        log("Clicked on link - " + field);
        return null;
    }


    //clicks an image 
    //identifierType : id, name, xpath etc
    //identifier: value of id, name , xpath etc sent from calling function
    public Exception ClickImage(String identifier, IWebDriver driver, String field, String identifierType)
    {

        switch (identifierType)
        {
            case "id":
                try
                {
                    driver.FindElement(By.Id(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickImage using id " + field);
                    return e;
                }
                driver.FindElement(By.Id(identifier)).Click();
                //clickImageUsingID(identifier,driver,field);
                break;
            case "name":
                try
                {
                    driver.FindElement(By.Name(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickImage using name " + field);
                    return e;
                }
                driver.FindElement(By.Name(identifier)).Click();
                //clickImageUsingName(identifier,driver,field);
                break;
            case "classname":
                try
                {
                    driver.FindElement(By.ClassName(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickImage Using className " + field);
                    return e;
                }
                driver.FindElement(By.ClassName(identifier)).Click();
                //clickImageUsingClassName(identifier, driver, field);
                break;
            case "xpath":
                try
                {
                    driver.FindElement(By.XPath(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickImage Using Xpath " + field);
                    return e;
                }
                driver.FindElement(By.XPath(identifier)).Click();
                //clickImageUsingXpath(identifier,driver,field);
                break;
        }
        log("Clicked on Image - " + field);
        return null;
    }


    //Selects a row in a table  
    //identifierType : id, name, xpath etc
    //identifier: value of id, name , xpath etc sent from calling function
    public Exception ClickRowOfTable(String identifier, IWebDriver driver, String field, String identifierType)
    {
        switch (identifierType)
        {

            case "id":
                try
                {
                    driver.FindElement(By.Id(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickRow using id " + field);
                    return e;
                }
                driver.FindElement(By.Id(identifier)).Click();
                //clickRowUsingId(identifier,driver,field);
                break;
            case "name":
                try
                {
                    driver.FindElement(By.Name(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickRow using name " + field);
                    return e;
                }
                driver.FindElement(By.Name(identifier)).Click();
                //clickRowUsingName(identifier,driver,field);
                break;
            case "xpath":
                try
                {
                    driver.FindElement(By.XPath(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from clickRow using xpath " + field);
                    return e;
                }
                driver.FindElement(By.XPath(identifier)).Click();
                //clickRowUsingXpath(identifier,driver,field);
                break;
        }
        log("Clicked on a row in a table - " + field);
        return null;
    }

    //Selects a dropdown value 
    //identifierType : id, name, xpath etc
    //identifier: value of id, name , xpath etc sent from calling function
    public Exception SelectDropdownValue(String identifier, String dropdownVal, IWebDriver driver, String field, String identifierType)
    {
        SelectElement dropdown;
        switch (identifierType)
        {
            case "id":
                try
                {
                    driver.FindElement(By.Id(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from selectValueFromDropdownUsingId " + field);
                    return e;
                }
                dropdown = new SelectElement(driver.FindElement(By.Id(identifier)));
                dropdown.SelectByValue(dropdownVal);
                break;
            case "name":
                try
                {
                    driver.FindElement(By.Name(identifier));
                }
                catch (NoSuchElementException e)
                {
                    log("Error returned from selectValueFromDropdownUsingName " + field);
                    return e;
                }
                dropdown = new SelectElement(driver.FindElement(By.Name(identifier)));
                dropdown.SelectByValue(dropdownVal);
                break;
            case "xpath":
                selectValueFromDropdownUsingXpath(identifier, dropdownVal, driver, field);
                break;
        }
        log("Selected " + dropdownVal + " from drop down : " + field);
        return null;
    }

    //selecting dropdown value by value using xpath
    public Exception selectValueFromDropdownUsingXpath(String xpath, String selectValue, IWebDriver driver, String field)
    {
        try
        {
            driver.FindElement(By.XPath(xpath));
        }
        catch (NoSuchElementException e)
        {
            log("Error returned from selectValueFromDropdownUsingXpath " + field);
            return e;
        }
        SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath(xpath)));
        dropdown.SelectByValue(selectValue);
        log("Selected " + selectValue + " from drop down : " + field);
        return null;
    }

    //Selecting drop down value by index using xpath
    public Exception selectValueFromDropdownUsingXpath(String xpath, int id, IWebDriver driver, String field)
    {
        try
        {
            driver.FindElement(By.XPath(xpath));
        }
        catch (NoSuchElementException e)
        {
            log("Error returned from selectValueFromDropdownUsingXpath " + field);
            return e;
        }
        SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath(xpath)));
        dropdown.SelectByIndex(id);
        log("Selected " + id + " from drop down : " + field);
        return null;
    }

}

