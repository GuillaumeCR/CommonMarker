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
        private readonly Regex leRegex = new Regex(@"^ {0,3}#{1,6}( .*)?$");

        public override void BuildHtml(StringBuilder builder)
        {
            var headerLevel = 0;
            var trimmed = Raw.Trim();
            int i;
            for (i = 0; i < trimmed.Length; i++)
            {
                if (trimmed[i] != '#')
                {
                    break;
                }
                headerLevel += 1;
            }

            var content = trimmed.Substring(i).Trim();
            builder.Append("<h" + headerLevel + ">" + content + "</h" + headerLevel + ">");
        }

        protected override Regex Regex()
        {
            return leRegex;
        }
    }
}
