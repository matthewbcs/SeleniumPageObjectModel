using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Test.Helpers
{
    public class BaseSiteComponent: BasePageComponent
    {
        protected override BaseWebAutomation WebAutomation
        {
            get { return SiteWebAutomation.Current; }
        }
    }
}
