using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker
{
    public class Md2Html
    {
        private readonly Parser parser = new Parser();

        public string Convert(string markdown)
        {
            var doc = parser.Parse(markdown);
            return doc.ToHtml();
        }
    }
}
