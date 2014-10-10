using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CommonMarker.Blocks
{
    class SetextHeaderBlock : Block
    {
        private readonly HorizontalRuleBlock hrBlock = new HorizontalRuleBlock();

        public bool AcceptsLine(string line)
        {
            throw new BlockConstructionException("SetextHeaderBlock cannot know if it accepts a line without looking at the next one.");
        }

        private readonly List<string> lines = new List<string>();
        public void AddLine(string line)
        {
            lines.Add(line);
        }

        public void BuildHtml(StringBuilder builder)
        {
            if (lines.Count != 2)
            {
                throw new HtmlBuildingException("Could not create html for a setext header block that has less than 2 lines");
            }

            var headerLevel = 1;
            if (lines[1].Contains('-'))
            {
                headerLevel = 2;
            }

            var inline = new Inline(lines[0]);
            builder.Append("<h" + headerLevel + ">");
            inline.BuildHtml(builder);
            builder.Append("</h" + headerLevel + ">");
        }

        private readonly Regex underlineRegex = new Regex(@"^ {0,3}(-+|=+)\s*$");
        internal bool AcceptsLine(string currentLine, string nextLine)
        {
            return !string.IsNullOrWhiteSpace(currentLine)
                && !hrBlock.AcceptsLine(currentLine)
                && underlineRegex.IsMatch(nextLine);
        }
    }
}
