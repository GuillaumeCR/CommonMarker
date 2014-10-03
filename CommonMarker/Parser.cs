using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMarker.Blocks;

namespace CommonMarker
{
    class Parser
    {
        private readonly BlockFactory blockFactory = new BlockFactory();

        public Document Parse(string markdown)
        {
            Block currentBlock = null;
            var doc = new Document();

            foreach (var line in markdown.Split(new [] {"\r\n", "\n"}, StringSplitOptions.None))
            {
                var preprocced = PreProcess(line);

                if (currentBlock == null
                    || !currentBlock.AcceptsLine(preprocced))
                {
                    //Blank line creates a new block.
                    if (string.IsNullOrWhiteSpace(preprocced))
                    {
                        currentBlock = null;
                    }
                    else
                    {
                        currentBlock = blockFactory.CreateBlock(preprocced);
                        doc.Blocks.Add(currentBlock);                        
                    }
                }
                else
                {
                    currentBlock.AddLine(preprocced);
                }
            }

            return doc;
        }

        private string PreProcess(string line)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '\t')
                {
                    builder.Append(' ', 4 - (builder.Length % 4));
                }
                else
                {
                    builder.Append(line[i]);
                }
            }

            return builder.ToString();
        }
    }
}
