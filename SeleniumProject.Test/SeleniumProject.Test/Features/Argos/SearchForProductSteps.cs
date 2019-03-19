using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SeleniumProject.Test.Helpers;
using SeleniumProject.Test.PageModel;
using SeleniumProject.Test.PageModel.SearchResults;
using TechTalk.SpecFlow;

namespace SeleniumProject.Test.Features.Argos
{
    [Binding, Scope(Feature = "SearchForProduct")]
    public sealed class SearchForProductSteps
    {
        [Given(@"I am on the Argos home page")]
        public void GivenIAmOnTheArgosHomePage()
        {
            SiteWebAutomation.Current.Navigate("https://www.argos.co.uk");
        }
        
        [When(@"I search for item '(.*)'")]
        public void WhenISearchForItem(string s)
        {
            ArgosPage argosPage = new ArgosPage();
            argosPage.TopDivSection.SetSearchText(s);
            argosPage.TopDivSection.ClickSearchBtn();
        }
        [Then(@"the list of booked available are displayed")]
        public void ThenTheListOfBookedAvailableAreDisplayed()
        {
            // TODO: could improve this buy maybe checking for a specific product or all of them.
            SearchResultsPage argosSearchResultPage = new SearchResultsPage();
            Assert.IsTrue(argosSearchResultPage.ResultsDiv.IsProductListingDisplayed());
        }





    }
}
