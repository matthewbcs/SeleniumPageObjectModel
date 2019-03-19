using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumProject.Test.Helpers;

namespace SeleniumProject.Test.PageModel.SearchResults
{
    public class ResultsDiv: BaseSiteComponent
    {
        #region elements

        public IWebElement ProductContainer => GetElement(".product-list");

        #endregion

        #region actions

        public bool IsProductListingDisplayed()
        {
            bool displayed;

            // TODO: this can be improved by implementing a wait/ retry in the get element method can even pass in a poll count.. 
            try
            {
                displayed = ProductContainer.Displayed;
            }
            catch (Exception e)
            {
                displayed = false;
            }

            return displayed;

        }
        #endregion
    }
}
