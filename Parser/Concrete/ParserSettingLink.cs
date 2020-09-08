namespace LanitParser.Parser.Concrete
{
    class ParserSettingLink : IParserSettings
    {
        public string Url { get; set; }
        public int LinkDeep { get; set; }
    }
}
