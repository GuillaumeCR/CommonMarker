using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker
{
    class Inline
    {
        private readonly string _raw;
        private string trimmed;
        private int i;
        public Inline(string raw)
        {
            _raw = raw;
        }

        private StringBuilder _sb;
        public void BuildHtml(StringBuilder resultBuilder)
        {
            _sb = resultBuilder;
            trimmed = _raw.Trim();

            //Consume string one char at a time.
            //Each method returns true if it was able to process the next char.
            //Methods can increment i if needed.
            for (i = 0; i < trimmed.Length; i++)
            {
                if (EscapedPunctuation()) continue;
                if (Emphasis()) continue;
                _sb.Append(trimmed[i]);
            }
        }

        private bool emphasis = false;
        private bool Emphasis()
        {
            if (trimmed[i] != '*')
            {
                return false;
            }

            if (trimmed.Replace(" ", "").All(x => x == '*'))
            {
                return false;
            }
            
            if (emphasis)
            {
                _sb.Append("</em>");                
            }
            else
            {
                _sb.Append("<em>");
            }
            emphasis = !emphasis;
            return true;
        }

        private bool EscapedPunctuation()
        {
            if (trimmed[i] == '\\'
                       && i < trimmed.Length - 1
                       && char.IsPunctuation(trimmed[i + 1]))
            {
                _sb.Append(trimmed[i + 1]);
                i++;
                return true;
            }
            return false;
        }
    }
}
