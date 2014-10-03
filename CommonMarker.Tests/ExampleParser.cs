using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CommonMarker.Tests
{
    class ExampleParser
    {
        /// <summary>
        /// The <center> cannot hold it is too late.
        /// </summary>
        private readonly Regex Zalgo = new Regex(
            @"<div id=""example-(\d+)"" class=""example"" data-section="".+?"">\s*<div class=""examplenum"">\s*Example \d+\s*</div>\s*<pre class=""markdown""><code>(.*?)</code></pre>\s*<pre class=""html""><code>(.*?)</code></pre>\s*</div>",
            RegexOptions.Singleline);

        public IEnumerable<Example> Parse(string specHtml)
        {
            if (string.IsNullOrWhiteSpace(specHtml))
            {
                throw new ArgumentNullException("specHtml");
            }

            var matches = Zalgo.Matches(specHtml);
            var examples = new List<Example>();
            foreach (Match match in matches)
            {
                if (match.Groups.Count == 4)
                {
                    var exampleNumberString = match.Groups[1].ToString();
                    int exampleNumber;
                    if (int.TryParse(exampleNumberString, out exampleNumber) == false)
                    {
                        continue;
                    }
                    var example = new Example
                    {
                        Number = exampleNumber,
                        Markdown = match.Groups[2].ToString(),
                        Html = match.Groups[3].ToString()
                    };
                    examples.Add(example);
                }
            }

            return examples;
        }
    }
}
