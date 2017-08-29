using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace Demo.SimpleWeb
{
    class SimpleWebProgram
    {
        static void Main(string[] args)
        {
            Welcome();
            while (true)
            {
                string query = GetQuery();
                HtmlDocument htmlDoc = GetHTML(query);
                string paragraph = GetFirstParagraph(htmlDoc);
                WriteResults(paragraph); 
            }
        }

        /// <summary>
        /// Writes a welcome message to the user, explaining how the application works.
        /// </summary>
        public static void Welcome()
        {
            Console.WriteLine("Welcome. This application takes your input and searches\n" +
                "the English Wikipedia for results, returning the first\n" +
                "paragraph of the resulting article. \n");
        }

        /// <summary>
        /// Receives a user input string and converts it to a Wikipedia search URL.
        /// </summary>
        /// <returns></returns>
        public static string GetQuery()
        {
            Console.Write("Search: ");
            return "https://en.wikipedia.org/w/index.php?search=" + Console.ReadLine();
        }

        /// <summary>
        /// Searches for a HTML page based on the argument given.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static HtmlDocument GetHTML(string query)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = web.Load(query);

            return htmlDoc;
        }

        /// <summary>
        /// Searches a Wikipedia page for the first paragraph and returns it.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static string GetFirstParagraph(HtmlDocument doc)
        {
            HtmlNode node = doc.DocumentNode.SelectNodes("//p")[0];
            return node.InnerText;
        }

        /// <summary>
        /// Clears console and writes a string to the console. After user presses a key, clears the console again.
        /// </summary>
        /// <param name="result"></param>
        public static void WriteResults(string result)
        {
            Console.Clear();
            Console.WriteLine(result);
            Console.WriteLine("\n\nPress any key to return.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
