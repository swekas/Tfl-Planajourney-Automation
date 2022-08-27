using com.tfljourney.automation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tfljourney.automation.StepDefinitions
{
    [Binding]
    class PlanAJourneyStepDef
    {
        IWebDriver driver;
        PlanAJourneyPage planAJourneyPage;
        JourneyResultsPage journeyResultsPage;
        string fromJourney = "";
        string toJourney = "";
        string time = "";

        [BeforeScenario]
        public void initBrowser()
        {
            driver = new ChromeDriver();
            planAJourneyPage = new PlanAJourneyPage(driver);
            journeyResultsPage = new JourneyResultsPage(driver);
        }

        [AfterScenario]
        public void closeInstance()
        {
            driver.Quit();
        }

        [Given(@"I am on the Tfl website")]
        public void GivenIAmOnTheTflWebsite()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "https://tfl.gov.uk/plan-a-journey/";
            planAJourneyPage.AcceptAllCookies();
        }

        [When(@"I enter journey from ""([^""]*)""")]
        public void WhenIEnterJourneyFrom(string _fromJourney)
        {
            fromJourney = _fromJourney;
            planAJourneyPage.EnterFromLocation(fromJourney);
        }

        [When(@"I enter journey to ""([^""]*)""")]
        public void WhenIEnterJourneyTo(string _toJourney)
        {
            toJourney = _toJourney;
            planAJourneyPage.EnterToLocation(toJourney);
        }

        [Then(@"I click on Plan my journey button")]
        public void ThenClickOnPlanMyJourneyButton()
        {
            planAJourneyPage.ClickPlanJourney();
        }

        [Then(@"I verify the Valid journey is planned")]
        public void ThenVerifyTheValidJourneyIsPlanned()
        {
            Assert.IsTrue(journeyResultsPage.IsJourneyResultsHeader());
            Assert.IsTrue(journeyResultsPage.VerifyToJourneySummary(toJourney));
            Assert.IsTrue(journeyResultsPage.VerifyFromJourneySummary(fromJourney));
        }

        [Then(@"I verify the invalid journey message")]
        public void ThenIVerifyTheInvalidJourneyMessage()
        {
            Assert.IsTrue(journeyResultsPage.VerifyInvalidJourneyMessage(
                          "Journey planner could not find any results to your search. Please try again"));
        }

        [When(@"I enter invalid from location ""([^""]*)""")]
        public void WhenIEnterInvalidFromLocation(string _fromJourney)
        {
            fromJourney = _fromJourney;
            planAJourneyPage.EnterFromLocation(fromJourney);
        }

        [When(@"I enter invalid to location ""([^""]*)""")]
        public void WhenIEnterInvalidToLocation(string _toJourney)
        {
            toJourney = _toJourney;
            planAJourneyPage.EnterToLocation(toJourney);
        }

        [Then(@"I verify field validation messages")]
        public void ThenVerifyFieldValidationMessages()
        {
            Assert.IsTrue(planAJourneyPage.VerifyFromFieldValidationMessage("The From field is required."));
            Assert.IsTrue(planAJourneyPage.VerifyToFieldValidationMessage("The To field is required."));
        }

        [Then(@"click on edit journey")]
        public void ThenClickOnEditJourney()
        {
            journeyResultsPage.ClickEditJourney();
        }

        [When(@"I clear and enter another journey to ""([^""]*)""")]
        public void WhenIClearAndEnterAnotherJourneyTo(string _toJourney)
        {
            toJourney = _toJourney;
            planAJourneyPage.ClearJourneyToInput();
            planAJourneyPage.EnterToLocation(toJourney);
        }

        [Then(@"I click on update journey")]
        public void ThenIClickOnUpdateJourney()
        {
            journeyResultsPage.ClickUpdateJourney();
        }

        [When(@"I click on change time")]
        public void WhenIClickOnChangeTime()
        {
            planAJourneyPage.ClickChangeTime();
        }

        [When(@"I click arrival time")]
        public void WhenIClickArrivalTime()
        {
            planAJourneyPage.ClickArriving();
        }

        [Then(@"I select arrival time ""([^""]*)""")]
        public void ThenISelectArrivalTime(string _arrivalTime)
        {
            time = _arrivalTime;
            planAJourneyPage.SelectArrivalTime(time);
        }

        [Then(@"I verify the journey plan based on arrival time ""([^""]*)""")]
        public void ThenIVerifyTheJourneyPlanBasedOnArrivalTime(string _arrivalTime)
        {
            time = _arrivalTime;
            Assert.IsTrue(journeyResultsPage.VerifyArrivingTimeOnResultsPage(time));
        }

        [Then(@"I click on edit journey on journey results page")]
        public void ThenIClickOnEditJourneyOnJourneyResultsPage()
        {
            journeyResultsPage.ClickEditJourney();
        }

        [When(@"I click on update journey")]
        public void WhenIClickOnUpdateJourney()
        {
            journeyResultsPage.ClickUpdateJourney();
        }

        [Then(@"I verify if journey to location is updated to ""([^""]*)""")]
        public void ThenIVerifyIfJourneyToLocationIsUpdatedTo(string toJourney)
        {
            Assert.IsTrue(journeyResultsPage.IsJourneyResultsHeader());
            Assert.IsTrue(journeyResultsPage.VerifyToJourneySummary(toJourney));
        }

    }
}
