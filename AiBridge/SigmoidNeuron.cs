using System;
using System.Collections.Generic;
using System.Text;

namespace AiBridge
{
    public class SigmoidNeuron : Neuron
    {
        public double Coeficient { get; private set; }

        public SigmoidNeuron(double coeficient = 1)
        {
            Coeficient = coeficient;
        }

        public SigmoidNeuron(int dendriteCount, double initialWeight, double coeficient = 1)
           : base(dendriteCount, initialWeight)
        {
            Coeficient = coeficient;
        }

        public override double Activation(double value)
        {
            return (1 / (1 + Math.Exp(-value * Coeficient)));
        }
    }
}
