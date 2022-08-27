using com.tfljourney.automation.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tfljourney.automation.Pages
{
    class JourneyResultsPage
    {
        IWebDriver driver;
        ElementMethods em;
        Waits wait;
        public JourneyResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            em = new ElementMethods(driver);
            wait = new Waits(driver);
        }

        public By journeyResultsHeader = By.CssSelector(".jp-results-headline");
        public By fromJourneySummary = By.XPath("//span[text()='From:']/..//strong");
        public By toJourneySummary = By.XPath("//span[text()='To:']/..//strong");
        public By invalidJourneyMsgLoactor = By.CssSelector(".publictransport li.field-validation-error");
        public By editJourney = By.CssSelector(".edit-journey");
        public By updateJourney = By.CssSelector("#plan-a-journey .plan-journey-button");
        public By arrivingTime = By.XPath("//span[text()='Arriving:']/..//strong");
        public bool IsJourneyResultsHeader()
        {
            wait.WaitForElementVisibility(journeyResultsHeader);
            return em.GetWebElement(journeyResultsHeader).Displayed;
        }

        public bool VerifyFromJourneySummary(string expFromJourney)
        {
            return em.GetWebElement(fromJourneySummary).Text.Equals(expFromJourney);
        }

        public bool VerifyToJourneySummary(string expToJourney)
        {
            return em.GetWebElement(toJourneySummary).Text.Equals(expToJourney);
        }

        public bool VerifyInvalidJourneyMessage(string invalidPlanText)
        {
            wait.HoldsOn(4);
            return em.GetWebElement(invalidJourneyMsgLoactor).Text.Equals(invalidPlanText);
        }

        public void ClickEditJourney()
        {
            em.ClickOnElement(editJourney);
        }

        public void ClickUpdateJourney()
        {
            em.ClickOnElement(updateJourney);
        }

        public bool VerifyArrivingTimeOnResultsPage(string time)
        {
            return em.GetWebElement(arrivingTime).Text.Contains(time);
        }
    }
}
