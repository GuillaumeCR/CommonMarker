using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker
{
    interface Block
    {
        bool AcceptsLine(string line);
        void AddLine(string line);
        void BuildHtml(StringBuilder builder);
    }
}
