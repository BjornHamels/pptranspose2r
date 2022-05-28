using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pptranspose2r
{

    /// <summary>
    /// Represents a combination of the header and the datacell below it.
    /// </summary>
    public record HeaderData(string Header, string Data)
    {

    }

}
