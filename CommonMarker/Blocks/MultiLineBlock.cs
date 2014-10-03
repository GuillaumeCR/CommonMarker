using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker.Blocks
{
    abstract class MultiLineBlock : Block
    {
        private readonly List<string> _rawLines = new List<string>();
        public List<string> RawLines { get { return _rawLines; } }

        public abstract bool AcceptsLine(string line);
        public void AddLine(string line)
        {
            RawLines.Add(line);
        }
        public abstract void BuildHtml(StringBuilder builder);
    }
}
