using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumProject.Test.Helpers.BaseWebElements;

namespace SeleniumProject.Test.Helpers
{
    public abstract class BasePageComponent
    {
        protected abstract BaseWebAutomation WebAutomation { get; }

        protected IWebElement GetElement(string jquerySelector)
        {
            return WebAutomation.Driver.FindElement(By.CssSelector(jquerySelector));
        }
      
    }


}
