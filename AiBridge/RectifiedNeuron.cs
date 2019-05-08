using System;
using System.Collections.Generic;
using System.Text;

namespace AiBridge
{
    public class RectifiedNeuron : Neuron
    {
        public RectifiedNeuron(int dendriteCount, double initialWeight)
           : base(dendriteCount, initialWeight)
        {
        }

        public override double Activation(double value)
        {
            return Math.Max(0, value);
        }
    }
}
