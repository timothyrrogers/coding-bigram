using System;
using System.Collections.Generic;
using System.Text;

namespace BigramParser
{
    public class Histogram
    {
        public string DisplayHistogram(string value)
        {
            BigramParser parser = new BigramParser();
            StringBuilder histogram = new StringBuilder();

            histogram.AppendLine("<ul>");
            
            foreach(var item in parser.Parse(value))
            {
                histogram.AppendLine(string.Format("<li>\"{0}\" : {1}</li>", item.Key, item.Value));
            }

            histogram.AppendLine("</ul>");

            return histogram.ToString();
        }
    }
}
