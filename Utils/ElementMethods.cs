using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tfljourney.automation.Utils
{
    class ElementMethods
    {
        IWebDriver driver;
        Waits waits;

        public ElementMethods(IWebDriver driver)
        {
            this.driver = driver;
            waits = new Waits(driver);
        }
        public void ClickOnElement(By ele)
        {
            try
            {
                waits.WaitForElementClickable(ele);
                GetWebElement(ele).Click();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public void ClearAndEnterText(By ele, String inputText)
        {
            try
            {
                waits.WaitForElementVisibility(ele);
                GetWebElement(ele).Clear();
                GetWebElement(ele).SendKeys(inputText);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public void EnterText(By ele, String inputText)
        {
            try
            {
                waits.WaitForElementVisibility(ele);
                GetWebElement(ele).SendKeys(inputText);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public IWebElement GetWebElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public IJavaScriptExecutor GetJavaScriptExecutor()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            return jse;
        }

        public void ClickUsingJS(By ele)
        {
            GetJavaScriptExecutor().ExecuteScript("arguments[0].click();", GetWebElement(ele));
        }

    }
}
