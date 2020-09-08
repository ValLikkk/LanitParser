using LanitParser.Parser;
using LanitParser.Parser.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LanitParser
{
    class StartParser
    {
        private ParserWorker<List<string>> linkParser;
        private ParserWorker<string> textParser;
        public void Start()
        {
            var linkSettings = new ParserSettingLink() { LinkDeep = 2, Url = "http://www.russianmajorleague.ru/" };
            startParsing(linkSettings);
        }

        private void startParsing(IParserSettings settings)
        {
            linkParser = new ParserWorker<List<string>>(new LinkParser(), settings);
            linkParser.Start();
            linkParser.OnCompleted += LinkParser_OnCompleted;
        }


        private void LinkParser_OnCompleted(object arg1, List<string> arg2)
        {
            var currentSettings = ((ParserWorker<List<string>>)arg1).Settings;
            if (currentSettings.LinkDeep > 1)
            {
                startParsing(new ParserSettingLink() { LinkDeep = currentSettings.LinkDeep - 1, Url = currentSettings.Url });
            }

            foreach (var link in arg2)
            {
                var url = link;
                if (!IsValidUrl(link))
                {
                    url = currentSettings.Url + link;
                }
                var textSetting = new ParserSettingLink() { Url = url };
                textParser = new ParserWorker<string>(new TextParser(), textSetting);
                textParser.Start();
                textParser.OnCompleted += TextParser_OnCompleted;
            }
        }

        private bool IsValidUrl(string url)
        {
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        private void TextParser_OnCompleted(object arg1, string arg2)
        {
            //В arg2 Будет  текс  контент страницы
        }
    }
}
