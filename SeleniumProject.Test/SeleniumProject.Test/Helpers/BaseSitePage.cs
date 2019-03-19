using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Test.Helpers
{
    public class BaseSitePage: BasePage
    {
        public override string Url { get; set; }
        public override List<string> Urls { get; set; }

        public BaseSitePage():base(SiteWebAutomation.Current.Driver)
        {

        }
    }
}
