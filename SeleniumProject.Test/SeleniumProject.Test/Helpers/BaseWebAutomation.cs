using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.Test.Helpers.BaseWebElements;

namespace SeleniumProject.Test.Helpers
{
    public class BaseWebAutomation
    {
        private IWebDriver _webDriver;
        private readonly string _baseUrl;
        private BasePage _currentPage;

       //public static HtmlElement parentContainerElement;

        public static BaseWebAutomation CurrentWebAutomation;

        protected BaseWebAutomation(string baseUrl)
        {
            if (baseUrl.EndsWith("/"))
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1); 

            _baseUrl = baseUrl;

        }

        public IWebDriver Driver
        {
            get
            {
                
                if (_webDriver != null)
                    return _webDriver;

                // setup browser config
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("test-type");
                options.AddArgument("start-maximized");
                options.AddArgument("--disable-extensions");
                options.AddArgument("no-sandbox"); 

                _webDriver = new ChromeDriver(options);
                    
                
                _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);

                return _webDriver;
            }
        }
        public void GoTo(string lastPart, object append = null)
        {
            

            //Can use append for things like id ie /Payment/Process/{append}
            string fullUrl = GetFullUrl(lastPart, append);

            if (GetCurrentUrl() != fullUrl)
                Navigate(fullUrl);

        }
        public bool IsOnDefaultPage { get; private set; }
        public void Navigate(string fullUrl)
        {
            IsOnDefaultPage = fullUrl == "about:blank";

            try
            {
                Driver.Navigate().GoToUrl(fullUrl);
            }
            catch (Exception e)
            {
                string currentUrl = "NOT SET";

                try
                {
                    currentUrl = Driver.Url;
                }
                catch
                {
                }

                
            }
        }
        public string GetFullUrl(string lastPart, object append)
        {
            if (lastPart == "about:blank")
                return lastPart;

            if (!lastPart.StartsWith("/"))
                lastPart = "/" + lastPart;

            if (lastPart.EndsWith("/"))
                lastPart = lastPart.Substring(0, lastPart.Length - 1);  //Chop off last /

            string appendStr = append != null ? "/" + append.ToString() : "";

            return "http://" + _baseUrl + lastPart + appendStr;
        }
        public T GetCurrentPage<T>() where T : BasePage
        {
            return _currentPage as T;
        }
        public string GetCurrentUrl(bool returnRelativePath = false)
        {
            string url = _webDriver.Url;

            if(returnRelativePath)
            {
                Regex reg = new Regex("http://[^/]*");
                url = reg.Replace(url, "");
            }

            return url;
        }

        public void SetCurrentPage<T>(T currentPage) where T : BasePage
        {
            _currentPage = currentPage;
        }
        public void ClearAllCookies() => _webDriver?.Manage().Cookies.DeleteAllCookies();
        public object RunJavascript(string js, params object[] param)
        {
           
            return (Driver as IJavaScriptExecutor).ExecuteScript(js, param);
        }
    }
    public abstract class BaseWebAutomation<T> : BaseWebAutomation where T : BaseWebAutomation, new()
    {
        private static T _current;
        public bool IsActive { get; set; }

        public static bool IsActiveWeb => _current != null;

        protected BaseWebAutomation(string baseUrl) : base(baseUrl)
        {
            IsActive = true;
        }

        public static T Current => _current ?? (_current = new T());

    

        public void TestFinished()
        {
            try
            {
                IsActive = false;
                ClearAllCookies();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error clearing cookies: {e.Message}");
            }
        }

        public static  void Quit()
        {
            _current.Driver.Quit();
            _current = null;
        }
    }
}
