﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarker
{
    class ParsingException : Exception
    {
        public ParsingException(string message)
            : base(message)
        {

        }
    }
}
