using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CommonMarker.Tests
{
    class UnitTestCreator
    {
        private const string TestMethodTemplate =
@"        [TestMethod]
        public void Example@Number()
        {
            const string input = @""@markdown"";
            const string expected = @""@html"";

            TestExample(input, expected);
        }

";

        public string Create(IEnumerable<Example> examples)
        {
            var sb = new StringBuilder(
@"using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonMarker.Tests
{
    [TestClass]
    public class Spec
    {
        private void TestExample(string input, string expected)
        {

            var target = new Md2Html();
            var actual = target.Convert(input).Replace(""\r\n"", ""\n"");

            Assert.AreEqual(expected, actual);
        }

");

            foreach (var example in examples)
	        {
                var markdown = example.Markdown.Replace('\u2192', '\t')
                    .Replace("\"", "\"\"");
                var html = WebUtility.HtmlDecode(example.Html)
                    .Replace("\"", "\"\""); ;
                var exampleTest = TestMethodTemplate.Replace("@Number", example.Number.ToString("D3"))
                    .Replace("@markdown", markdown)
                    .Replace("@html", html);
                sb.Append(exampleTest);
	        }

            sb.Append(
@"    }
}");

            return sb.ToString();
        }
    }
}
