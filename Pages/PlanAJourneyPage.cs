using com.tfljourney.automation.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tfljourney.automation.Pages
{
    class PlanAJourneyPage
    {
        IWebDriver driver;
        ElementMethods em;
        Waits wait;
        public PlanAJourneyPage(IWebDriver driver)
        {
            this.driver = driver;
            em = new ElementMethods(driver);
            wait = new Waits(driver);
        }

        public By inputFromTextBox = By.Id("InputFrom");
        public By inputToTextBox = By.Id("InputTo");
        public By planJourneyButton = By.Id("plan-journey-button");
        public By selectLocation = By.CssSelector(".stop-name");
        public By acceptAllCookiesBtn = By.CssSelector("#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll");
        public By doneBtn = By.CssSelector("#cb-confirmedSettings .cb-button");
        public By fromFieldValidationError = By.Id("InputFrom-error");
        public By toFieldValidationError = By.Id("InputTo-error");
        public By changeTime = By.CssSelector(".change-departure-time");
        public By arrivingTime = By.Id("arriving");
        public By arrivalTimeSelection = By.CssSelector(".hours");
        public By clearToInput = By.CssSelector("#search-filter-form-1 div.remove-content-container a");
        public void AcceptAllCookies()
        {
            wait.HoldsOn(3);
            em.ClickOnElement(acceptAllCookiesBtn);
            em.ClickOnElement(doneBtn);
        }

        public void EnterFromLocation(string fromLocationName)
        {
            em.EnterText(inputFromTextBox,fromLocationName);
            wait.HoldsOn(4);
            IList<IWebElement> li = driver.FindElements(By.XPath("//span[@class='stop-name']"));
            foreach(var e in li)
            {

            if (e.Text.Equals(fromLocationName))
                {
                    e.Click();
                    break;
                }
            }
          }

        public void EnterToLocation(string toLocationName)
        {
            em.EnterText(inputToTextBox, toLocationName);
            wait.HoldsOn(4);
            IList<IWebElement> li = driver.FindElements(By.XPath("//span[@class='stop-name']"));
            foreach (var e in li)
            {
                if (e.Text.Equals(toLocationName))
                {
                    e.Click();
                    break;
                }
            }
        }

        public void ClickPlanJourney()
        {
            em.ClickUsingJS(planJourneyButton);
        }

        public void SearchJourney(string fromLocationName, string toLocationName)
        {
            EnterFromLocation(fromLocationName);
            EnterToLocation(toLocationName);
            em.ClickOnElement(planJourneyButton);
        }

        public bool VerifyFromFieldValidationMessage(string errorMsg)
        {
            return em.GetWebElement(fromFieldValidationError).Text.Equals(errorMsg);
        }

        public bool VerifyToFieldValidationMessage(string errorMsg)
        {
            return em.GetWebElement(toFieldValidationError).Text.Equals(errorMsg);
        }

        public void ClickChangeTime()
        {
            em.ClickOnElement(changeTime);
        }

        public void ClickArriving()
        {
            em.ClickUsingJS(arrivingTime);
        }

        public void SelectArrivalTime(string time)
        {
            IWebElement timeSelector = driver.FindElement(By.CssSelector("select#Time"));
            IList<IWebElement> options = timeSelector.FindElements(By.XPath("//option"));
            int listCount = options.Count;
            for (int i = 0; i < listCount; i++)
            {
                if (options[i].Text == time)
                {
                    options[i].Click();
                }
            }
        }
        public void ClearJourneyToInput()
        {
            IWebElement toInput = driver.FindElement(By.Id("InputTo"));
            toInput.SendKeys(Keys.Control + "a");
            toInput.SendKeys(Keys.Delete);
        }
    }

}
