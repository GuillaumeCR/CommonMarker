﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker.Blocks
{
    class ParagraphBlock : MultiLineBlock
    {
        private readonly HorizontalRuleBlock hrBlock = new HorizontalRuleBlock();

        public override bool AcceptsLine(string line)
        {
            return !string.IsNullOrWhiteSpace(line)
                && !hrBlock.AcceptsLine(line);
        }

        public override void BuildHtml(StringBuilder builder)
        {
            builder.Append("<p>");
            builder.Append(string.Join(Environment.NewLine, RawLines.Select(x => x.Trim())));
            builder.Append("</p>");
        }
    }
}
