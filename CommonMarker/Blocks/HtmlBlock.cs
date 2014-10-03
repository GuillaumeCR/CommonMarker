using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CommonMarker.Blocks
{
    class HtmlBlock : MultiLineBlock
    {
        private readonly string[] htmlTags = "article, header, aside, hgroup, blockquote, hr, iframe, body, li, map, button, object, canvas, ol, caption, output, col, p, colgroup, pre, dd, progress, div, section, dl, table, td, dt, tbody, embed, textarea, fieldset, tfoot, figcaption, th, figure, thead, footer, footer, tr, form, ul, h1, h2, h3, h4, h5, h6, video, script, style"
            .Split(new [] {", "}, StringSplitOptions.None);

        public override bool AcceptsLine(string line)
        {
            if (!_open)
            {
                return false;
            }

            if (RawLines.Count == 0)
            {
                return AcceptsFirstLine(line);
            }

            return !string.IsNullOrWhiteSpace(line);
        }

        public override void AddLine(string line)
        {
            base.AddLine(line);

            _open = !IsClosingTag(line);
        }

        private bool IsClosingTag(string line)
        {
            var openingTag = GetTag(RawLines.First().Trim(), 0);
            var tag = GetTag(line.Trim(), 0);
            return string.Compare("/" + openingTag, 0, tag, 0, tag.Length) == 0;
        }

        private bool AcceptsFirstLine(string line)
        {
            if (line.Length < 5)
            {
                return false;
            }

            //Skip up to 3 blank chars.
            var index = 0;
            while (index < 4 && line[index] == ' ')
            {
                index++;
            }

            if (line.Substring(index, 4) != "&lt;")
            {
                return false;
            }

            var tag = GetTag(line, index);

            return htmlTags.Contains(tag);
        }

        private static string GetTag(string line, int index)
        {
            if (line.Length < index + 4)
            {
                return "";
            }

            return line.Substring(index + 4)
                .Split(new[] { " ", "&gt;" }, StringSplitOptions.None)
                .FirstOrDefault();
        }

        public override void BuildHtml(StringBuilder builder)
        {
            builder.AppendLine(string.Join(Environment.NewLine,
                RawLines.Select(
                    x => WebUtility.HtmlDecode(x))));
        }

        private bool _open = true;
    }
}
