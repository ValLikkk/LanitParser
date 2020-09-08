using LanitParser.Parser;
using LanitParser.Parser.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LanitParser
{
    class Program
    {

        static void Main(string[] args)
        {
            var StartParser = new StartParser();
            StartParser.Start();
            Console.ReadKey();// Нужно заблокировать маин, чтобы не сбрасывать асинхронные операции
        }
    }
}

