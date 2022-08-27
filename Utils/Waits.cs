using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tfljourney.automation.Utils
{
     class Waits
    {
        IWebDriver driver;
        public Waits(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WebDriverWait GetWaitInstance()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait;
        }

        public void WaitForElementClickable(By ele)
        {
            GetWaitInstance().Until(ExpectedConditions.ElementToBeClickable(ele));
        }

        public void WaitForElementVisibility(By ele)
        {
            GetWaitInstance().Until(ExpectedConditions.ElementIsVisible(ele));
        }

        public void WaitForElementDisplayed(By ele)
        {
            GetWaitInstance().Until(d => d.FindElement(ele).Displayed);
        }

        public void HoldsOn(int seconds)
        {
            Thread.Sleep(1000 * seconds);
        }
    }
}
