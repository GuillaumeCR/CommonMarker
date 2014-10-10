using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker.Blocks
{
    class UnorderedListBlock : MultiLineBlock
    {
        private readonly HorizontalRuleBlock hrBlock = new HorizontalRuleBlock();

        public override bool AcceptsLine(string line)
        {
            return line.Length > 1
                && !hrBlock.AcceptsLine(line)
                && (line.Substring(0, 2) == "- "
                    || line.Substring(0, 2) == "* ");
        }

        public override void BuildHtml(StringBuilder builder)
        {
            builder.AppendLine("<ul>");
            foreach (var line in RawLines)
            {
                builder.Append("<li>");
                if (line.Length > 2)
                {
                    if (hrBlock.AcceptsLine(line.Substring(2)))
                    {
                        hrBlock.BuildHtml(builder);
                    }
                    else
                    {
                        builder.Append(line.Substring(2));
                    }
                }
                builder.AppendLine("</li>");
            }
            builder.Append("</ul>");
        }
    }
}
