using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace CommonMarker.Blocks
{
    class HtmlBlock : MultiLineBlock
    {
        private const string htmlTags = "article|header|aside|hgroup|blockquote|hr|iframe|body|li|map|button|object|canvas|ol|caption|output|col|p|colgroup|pre|dd|progress|div|section|dl|table|td|dt|tbody|embed|textarea|fieldset|tfoot|figcaption|th|figure|thead|footer|footer|tr|form|ul|h1|h2|h3|h4|h5|h6|video|script|style";
        //Zalgo?
        private readonly Regex htmlRegex = new Regex(" {0,3}&lt;/?(" + htmlTags + ")");
        private readonly Regex htmlClosingTag = new Regex("&lt;/(" + htmlTags + ")");

        public override bool AcceptsLine(string line)
        {
            if (!_open)
            {
                return false;
            }

            if (RawLines.Count == 0)
            {
                return AcceptsFirstLine(line);
            }

            return !string.IsNullOrWhiteSpace(line);
        }

        public override void AddLine(string line)
        {
            base.AddLine(line);

            _open = !IsClosingTag(line);
        }

        private bool IsClosingTag(string line)
        {
            var match = htmlClosingTag.Match(line);
            if (match.Groups.Count < 2)
            {
                return false;
            }

            var closingTag = match.Groups[1].Value;

            var openingTag = GetTag(RawLines.First());
            return openingTag == closingTag;
        }

        private bool AcceptsFirstLine(string line)
        {
            return htmlRegex.Match(line).Success;
        }

        private string GetTag(string line)
        {
            var match = htmlRegex.Match(line);
            if (match.Groups.Count > 1)
            {
                return match.Groups[1].Value;
            }

            return "";
        }

        public override void BuildHtml(StringBuilder builder)
        {
            builder.Append(string.Join(Environment.NewLine,
                RawLines.Select(
                    x => WebUtility.HtmlDecode(x))));
        }

        private bool _open = true;
    }
}
