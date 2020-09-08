using AngleSharp.Html.Dom;

namespace LanitParser.Parser
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
