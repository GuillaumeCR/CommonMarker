using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMarker.Blocks
{
    class BlockConstructionException : Exception
    {
        public BlockConstructionException(string message)
            : base(message)
        { }
    }
}
