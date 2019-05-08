using System;
using System.Collections.Generic;
using System.Text;

namespace AiBridge
{
    public interface ISynapse
    {
        double Weight { get; set; }
        double Value { get; set; }
    }
}
