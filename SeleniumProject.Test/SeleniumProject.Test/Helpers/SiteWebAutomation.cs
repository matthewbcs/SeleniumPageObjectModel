using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Test.Helpers
{
    public class SiteWebAutomation: BaseWebAutomation<SiteWebAutomation>
    {
        public static string BaseUrl => TestConstants.BaseUrl;
        public SiteWebAutomation() : base(BaseUrl)
        {
           
        }
    }
}
