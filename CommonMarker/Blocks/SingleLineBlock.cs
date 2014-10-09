using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CommonMarker.Blocks
{
    abstract class SingleLineBlock : Block
    {
        protected string Raw;

        protected abstract Regex Regex();

        public virtual bool AcceptsLine(string line)
        {
            return string.IsNullOrWhiteSpace(Raw) && Regex().IsMatch(line);
        }

        public virtual void AddLine(string line)
        {
            if (!string.IsNullOrWhiteSpace(Raw))
            {
                throw new BlockConstructionException("Cannot add line " + line + " to SingleLineBlock because it already contains line " + Raw);
            }

            Raw = line;
        }

        public abstract void BuildHtml(StringBuilder builder);
    }
}
