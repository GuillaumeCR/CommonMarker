using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text;

namespace CommonMarker.Blocks
{
    class HorizontalRuleBlock : SingleLineBlock
    {
        private readonly Regex dasRegex = new Regex(@"^ {0,3}((\*\s*){3,}|(-\s*){3,}|(_\s*){3,})$");
        protected override Regex Regex()
        {
            return dasRegex;
        }
        
        public override void BuildHtml(StringBuilder builder)
        {
            builder.Append("<hr />");
        }
    }
}
