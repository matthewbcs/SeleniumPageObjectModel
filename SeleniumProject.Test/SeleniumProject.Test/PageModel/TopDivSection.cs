using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumProject.Test.Helpers;

namespace SeleniumProject.Test.PageModel
{
    public class TopDivSection:BaseSiteComponent
    {
        #region elements

        private IWebElement SearchBar => GetElement("#searchTerm");
        private IWebElement SearchButton => GetElement("div.xs-auto--none:nth-child(1) > form:nth-child(1) > button:nth-child(3)");
   

        #endregion

        #region actions

        public void SetSearchText(string search)
        {
            SearchBar.Clear();
            SearchBar.SendKeys(search);
        }

        public void ClickSearchBtn() => SearchButton.Click();

        #endregion
    }
}
