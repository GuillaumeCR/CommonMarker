using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMarker
{
    class HtmlBuildingException : Exception
    {
        public HtmlBuildingException(string message)
            : base(message)
        {

        }
    }
}
