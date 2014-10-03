using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMarker.Blocks
{
    class BlockFactory
    {
        private readonly List<Type> BlockTypes = new List<Type>
        {
            typeof(IndentedCodeBlock),
            typeof(ParagraphBlock)
        };

        internal Block CreateBlock(string line)
        {
            foreach (var blockType in BlockTypes)
            {
                var block = (Block)Activator.CreateInstance(blockType);
                if (block.AcceptsLine(line))
                {
                    block.AddLine(line);
                    return block;
                }
            }

            throw new ParsingException("Could not determine block type for line '" + line + "'");
        }
    }
}
