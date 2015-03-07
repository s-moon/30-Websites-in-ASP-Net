using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace W4_JonSkeetQuote
{
    public class QuoteEngine
    {
        private XmlDocument _xmlDocument;
        private XmlNodeList _xmlNodeList;
        public const string QUOTE_PATH = "Data/jon-skeet-quotes.xml";
 
        public QuoteEngine(string path)
        {
            _xmlDocument = new XmlDocument();    
            _xmlDocument.Load(path);
            _xmlNodeList = _xmlDocument.GetElementsByTagName("quote");
        }

        public string GetRandomQuote()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            if (_xmlNodeList != null && _xmlNodeList.Count > 0)
            {
                return _xmlNodeList.Item(rnd.Next(_xmlNodeList.Count)).InnerText;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}