using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumProject.Test.Helpers;

namespace SeleniumProject.Test.PageModel
{
    public class ArgosPage:BaseSitePage
    {
        public override string Url { get { return "/Home"; } }
        public TopDivSection TopDivSection { get; set; }

        public ArgosPage()
        {
            TopDivSection = new TopDivSection();
        }
    }
}
