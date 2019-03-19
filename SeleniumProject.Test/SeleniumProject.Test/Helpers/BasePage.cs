using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumProject.Test.Helpers
{
    public abstract class BasePage
    {
        private readonly IWebDriver _webDriver;

        public abstract string Url { get; set; }
        public abstract List<string> Urls { get; set; }
   

        protected BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
       

            
        }
    }
}
