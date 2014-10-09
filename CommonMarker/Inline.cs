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
        private int i;
        public Inline(string raw)
        {
            _raw = raw;
        }

        private StringBuilder _sb;
        public void BuildHtml(StringBuilder resultBuilder)
        {
            _sb = resultBuilder;

            //Consume string one char at a time.
            //Each method returns true if it was able to process the next char.
            //Methods can increment i if needed.
            for (i = 0; i < _raw.Length; i++)
            {
                if (EscapedPunctuation()) continue;
                if (Emphasis()) continue;
                _sb.Append(_raw[i]);
            }
        }

        private bool emphasis = false;
        private bool Emphasis()
        {
            if (_raw[i] != '*')
            {
                return false;
            }

            if (_raw.Replace(" ", "").All(x => x == '*'))
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
            if (_raw[i] == '\\'
                       && i < _raw.Length - 1
                       && char.IsPunctuation(_raw[i + 1]))
            {
                _sb.Append(_raw[i + 1]);
                i++;
                return true;
            }
            return false;
        }
    }
}
