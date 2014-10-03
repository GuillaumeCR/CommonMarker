using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker.Blocks
{
    class ParagraphBlock : MultiLineBlock
    {
        public override bool AcceptsLine(string line)
        {
            return !string.IsNullOrWhiteSpace(line);
        }

        public override void BuildHtml(StringBuilder builder)
        {
            builder.Append("<p>");
            builder.Append(string.Join(Environment.NewLine, RawLines));
            builder.Append("</p>");
        }
    }
}
