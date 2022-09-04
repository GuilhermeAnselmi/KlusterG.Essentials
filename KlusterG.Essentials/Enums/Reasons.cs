using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlusterG.Essentials.Enums
{
    public enum Reasons
    {
        None = 0,
        IsNull = 1,
        Invalid = 2,
        BelowTheMinimum = 3,
        AboveTheMaximum = 4,
        InvalidNumberOfDigits = 5,
    }
}
