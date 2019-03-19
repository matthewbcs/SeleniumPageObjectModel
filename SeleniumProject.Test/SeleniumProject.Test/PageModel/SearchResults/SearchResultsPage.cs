using SeleniumProject.Test.Helpers;

namespace SeleniumProject.Test.PageModel.SearchResults
{
    public class SearchResultsPage: BaseSitePage
    {
        public override string Url { get { return "/search/"; } }

        public ResultsDiv ResultsDiv { get; set; }

        public SearchResultsPage()
        {
            ResultsDiv = new ResultsDiv();
        }
    }
}
