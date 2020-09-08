using AngleSharp.Html.Dom;


namespace LanitParser.Parser.Concrete
{
    class TextParser : IParser<string>
    {
        public string Parse(IHtmlDocument document)
        {
            return document.Body.TextContent; 
        }
    }
}
