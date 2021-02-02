using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace maksym_nosov_test_project_coloplast.StepDefinitions
{
    [Binding]
    public class NavigationMenuBarButtonsSteps : IDisposable
    {
        private ChromeDriver chromeDriver;
        public NavigationMenuBarButtonsSteps() => chromeDriver = new ChromeDriver();

        [Given(@"Main page is opened")]
        public void GivenMainPageIsOpened()
        {
            chromeDriver.Navigate().GoToUrl("https://www.coloplast.com/");
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("coloplast"));
        }

        [When(@"User clicks About Coloplast button")]
        public void WhenUserClicksAboutColoplastButton()
        {
            var aboutColoplastButton = chromeDriver.FindElementByXPath("//span[contains(text(),'About Coloplast')]");
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            aboutColoplastButton.Click();
        }
        
        [Then(@"About Coloplast page is opened")]
        public void ThenAboutColoplastPageIsOpened()
        {
            // Verify that URL is correct
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("https://www.coloplast.com/about-coloplast/"));
            // Verify that title of page is correct
            Assert.IsTrue(chromeDriver.FindElementByXPath("//h1[contains(text(),'Welcome to Coloplast')]").Displayed);
        }
        
        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }
    }
}
