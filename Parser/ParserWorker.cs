using AngleSharp.Common;
using AngleSharp.Html.Parser;
using System;
using System.Threading.Tasks;

namespace LanitParser.Parser
{
    class ParserWorker<T> where T : class
    {
        private readonly HtmlLoader loader;

        public event Action<object, T> OnCompleted;

        public IParser<T> Parser { get;  }

        public IParserSettings Settings { get; }

        public ParserWorker(IParser<T> parser)  
        {
            Parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings settings) : this(parser)
        {
            Settings = settings;
            loader = new HtmlLoader(settings);
        }

        public  void Start()
        {
            Worker();
        }

        private async void Worker()
        {
            var source = await loader.GetSource();
            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);
            var result = Parser.Parse(document);

            OnCompleted?.Invoke(this, result);
        }
    }
}
