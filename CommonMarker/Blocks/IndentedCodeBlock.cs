using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker.Blocks
{
    class IndentedCodeBlock : MultiLineBlock
    {
        private const int IndentSize = 4;

        public override bool AcceptsLine(string line)
        {
            if (line.Length < IndentSize)
            {
                if (line.Any(chr => chr != ' '))
                {
                    return false;
                }

                //newline
                return true;
            }
            return line.Substring(0, IndentSize) == "    ";
        }

        public override void BuildHtml(StringBuilder builder)
        {
            builder.Append("<pre><code>");
            foreach (var line in RawLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    builder.AppendLine(line);
                }
                else
                {
                    builder.AppendLine(line.Substring(IndentSize, line.Length - IndentSize));
                }
            }
            builder.Append("</code></pre>");
        }
    }
}
