using System;
using System.Collections.Generic;
using System.Text;

namespace AiBridge
{
    public class Pulse : IPulse
    {
        public double Value { get; set; }

        public Pulse()
        {
            Value = 0;
        }

        public Pulse(double value)
        {
            Value = value;
        }
    }
}
