using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace LanitParser.Parser.Concrete
{
    class LinkParser : IParser<List<string>>
    {
        public List<string> Parse(IHtmlDocument document)
        {
            List<string> responseLink = new List<string>();
            var items = document.QuerySelectorAll("a")
                 .Select(item => item?.Attributes.Where(x => x != null && x.Name == "href"));
        
            foreach(var item in items)
            {
                responseLink.AddRange(item.Select(x => x.Value));
            }    

            return responseLink;
        }
    }
}
