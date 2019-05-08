using System;
using System.Collections.Generic;
using System.Text;

namespace AiBridge
{
    public class StepNeuron : Neuron
    {
        public double Threshold { get; private set; }

        public StepNeuron(double threshold = 1)
        {
            Threshold = threshold;
        }

        public StepNeuron(int dendriteCount, double initialWeight, double threshold = 1)
            : base(dendriteCount, initialWeight)
        {
            Threshold = threshold;
        }

        public override double Activation(double value)
        {
            return (value >= Threshold) ? Threshold : 0;
            //return value >= Threshold ? 0 : Threshold;
        }
    }
}
