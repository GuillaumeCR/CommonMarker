using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker.Blocks
{
    class ParagraphBlock : MultiLineBlock
    {
        private readonly HorizontalRuleBlock hrBlock = new HorizontalRuleBlock();
        private readonly AtxHeaderBlock atxBlock = new AtxHeaderBlock();

        public override bool AcceptsLine(string line)
        {
            return !string.IsNullOrWhiteSpace(line)
                && !hrBlock.AcceptsLine(line)
                && !atxBlock.AcceptsLine(line);
        }

        public override void BuildHtml(StringBuilder builder)
        {
            builder.Append("<p>");
            for (int i = 0; i < RawLines.Count; i++)
            {
                var inline = new Inline(RawLines[i].Trim());
                inline.BuildHtml(builder);
                if (i < RawLines.Count - 1)
                {
                    builder.Append(Environment.NewLine);
                }
            }
            builder.Append("</p>");
        }
    }
}
