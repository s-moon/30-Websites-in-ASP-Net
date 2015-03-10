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

        public QuoteEngine()
        {
            String path = HttpContext.Current.Server.MapPath(QUOTE_PATH);
            try
            {
                _xmlDocument = new XmlDocument();
                _xmlDocument.Load(path);
                _xmlNodeList = _xmlDocument.GetElementsByTagName("quote");
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new QuoteEngineException("File not found at path: " + path + ". " + e.Message);
            }
            catch (Exception e)
            {
                throw new QuoteEngineException(e.Message);
            }
        }

        /// <summary>
        /// Returns a randomly selected quote from the XML file as a string.
        /// </summary>
        /// <returns></returns>
        public string GetRandomQuote()
        {
            if (_xmlNodeList == null)
            {
                throw new QuoteEngineException("XML Node List has not been initialised.");
            }
            if (_xmlNodeList.Count == 0)
            {
                throw new QuoteEngineException("XML Node List is empty.");
            }
            Random rnd = new Random();
            return _xmlNodeList.Item(rnd.Next(_xmlNodeList.Count)).InnerText;
        }
    }

    public class QuoteEngineException : Exception
    {
        public QuoteEngineException()
        {
        }

        public QuoteEngineException(string message)
            : base(message)
        {
        }
    }
}