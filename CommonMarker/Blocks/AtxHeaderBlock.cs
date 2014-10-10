using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CommonMarker.Blocks
{
    class AtxHeaderBlock : SingleLineBlock
    {
        private readonly Regex leRegex = new Regex(@"^ {0,3}(#{1,6})( .*)?$");

        private string parsedString;
        private Match match;
        public override bool AcceptsLine(string line)
        {
            if (Raw != null)
            {
                return false;
            }

            match = leRegex.Match(line);
            if (match.Success)
            {
                parsedString = line;
                return true;
            }

            return false;
        }

        public override void AddLine(string line)
        {
            if (line != parsedString)
            {
                match = leRegex.Match(line);
            }

            Raw = line;
        }

        public override void BuildHtml(StringBuilder builder)
        {
            var headerLevel = match.Groups[1].Length;
            builder.Append("<h" + headerLevel + ">");
            if (match.Groups.Count > 2)
            {
                var content = StripTrailingHashes(match.Groups[2].Value.Trim());
                var inline = new Inline(content);
                inline.BuildHtml(builder);
            }
            builder.Append("</h" + headerLevel + ">");
        }

        private string StripTrailingHashes(string p)
        {
            for (int i = p.Length - 1; i > 0; i--)
            {
                if (p[i] == '#')
                {
                    continue;
                }

                if (p[i] == '\\'
                    && i < p.Length - 1)
                {
                    return p.Substring(0, i + 2).Trim();
                }

                return p.Substring(0, i + 1).Trim();
            }

            return "";
        }

        protected override Regex Regex()
        {
            return leRegex;
        }
    }
}
