using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker
{
    class Document
    {
        public List<Block> Blocks { get; private set; }

        public Document()
        {
            Blocks = new List<Block>();
        }

        public string ToHtml()
        {
            var builder = new StringBuilder();
            foreach (var block in Blocks)
            {
                if (builder.Length > 0)
                {
                    builder.AppendLine();
                }
                block.BuildHtml(builder);
            }
            return builder.ToString();
        }
    }
}
