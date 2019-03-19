using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumProject.Test.Helpers.BaseWebElements
{
    public class HtmlElement
    {
          
        protected readonly IWebElement _webElement;
        protected readonly BaseWebAutomation _parentAutomation;

        public HtmlElement(IWebElement webElement, BaseWebAutomation parentAutomation)
        {
            _webElement = webElement;
            _parentAutomation = parentAutomation;
        }

        public void Click(int timeoutMs = 1000)
        {

            if (!IsVisible)
                WaitFor(this, el => el.IsVisible, timeoutMs); 

         
            _parentAutomation.RunJavascript("arguments[0].click();", _webElement);
        }


        public void ClickNative(int timeoutMs = 5000)
        {
           
            if (!IsVisible)
                WaitFor(this, el => el.IsVisible, timeoutMs); 


            _webElement.Click();

        }

        public string InnerHtml
        {
            get { return _webElement.Text; }
        }

        public bool IsVisible
        {
            get { return _webElement.Displayed; }
        }

        public Point Location
        {
            get { return _webElement.Location; }
        }

        public int Width { get { return _webElement.Size.Width; } }
        public int Height { get { return _webElement.Size.Height; } }

		  internal static bool WaitFor<T>(T element, Func<T, bool> func, int timeoutMs, bool throwExc = false) where T : HtmlElement
        {

            DateTime expiry = DateTime.Now.AddMilliseconds(timeoutMs);
            bool didFind = false;

            try
            {
                do
                {
                    didFind = func(element);

                    if (didFind)
                        break;

                    Thread.Sleep(TestConstants.MaxPoll);

                } while (DateTime.Now < expiry);
            }
            catch (StaleElementReferenceException)
            {
                //didFind will be false
            }

            if (!didFind && throwExc)
                throw new Exception("Element not found");

	        return didFind;

        }

        public string GetAttribute(string attribute)
        {
            return _webElement.GetAttribute(attribute);
        }

        public string GetCssValue(string propertyName)
        {
            return _webElement.GetCssValue(propertyName);
        }
        public bool IsSelected()
        {
            return _webElement.Selected;
        }

        public bool IsDisabled()
        {
            return _webElement.GetAttribute("disabled") == "true";
        }
        

        public bool HasClass(string desiredClass)
        {
            string cssClasses = _webElement.GetAttribute("class");

            if (!string.IsNullOrEmpty(cssClasses))
            {
                string[] classes = cssClasses.Split(' ');
                return classes.Any(a => a == desiredClass); //This is case sensitive as css classes in general are case sensitive
            }
            
            return false;
        }

        public void SendKeys(string text)// this is needed to allow user to send text all html elements incase javascript intercepts text 
        {
            _webElement.SendKeys(text); 
        }

        public void ClickOfSetByElement(int x, int y)
        {
            new Actions(_parentAutomation.Driver).MoveToElement(_webElement).MoveByOffset(x, y).Click().Perform();
        }
    }
    }

