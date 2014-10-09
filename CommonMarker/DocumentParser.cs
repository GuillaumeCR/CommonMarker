using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMarker.Blocks;

namespace CommonMarker
{
    class DocumentParser
    {
        private readonly BlockFactory blockFactory = new BlockFactory();

        public Document Parse(string markdown)
        {
            var doc = new Document();

            var lines = markdown.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            if (lines.Length == 0)
            {
                return doc;
            }

            Block currentBlock = null;
            var setextHeader = new SetextHeaderBlock();
            string currentLine = null;
            string nextLine = null;
            for (int i = 0; i < lines.Length; i++)
            {
                if (nextLine == null)
                {
                    currentLine = PreProcess(lines[i]);
                }
                else
                {
                    //We're usually reading one line ahead to account for Setext.
                    currentLine = nextLine;
                    nextLine = null;
                }

                if (currentBlock != null
                    && currentBlock.AcceptsLine(currentLine))
                {
                    currentBlock.AddLine(currentLine);
                }
                else
                {
                    //Blank line creates a new block.
                    if (string.IsNullOrWhiteSpace(currentLine))
                    {
                        currentBlock = null;
                    }
                    else if (i == lines.Length - 1)
                    {
                        currentBlock = blockFactory.CreateBlock(currentLine);
                        doc.Blocks.Add(currentBlock);
                    }
                    else
                    {
                        nextLine = PreProcess(lines[i + 1]);
                        if (setextHeader.AcceptsLine(currentLine, nextLine))
                        {
                            setextHeader.AddLine(currentLine);
                            setextHeader.AddLine(nextLine);
                            doc.Blocks.Add(setextHeader);
                            setextHeader = new SetextHeaderBlock();
                            i++;
                            nextLine = null;
                        }
                        else
                        {
                            currentBlock = blockFactory.CreateBlock(currentLine);
                            doc.Blocks.Add(currentBlock);
                        }
                    }
                }
            }

            return doc;
        }

        private string PreProcess(string line)
        {
            if (!line.Contains('\t'))
            {
                return line;
            }

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
