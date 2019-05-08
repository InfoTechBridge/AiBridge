using System;
using System.Collections.Generic;
using System.Text;

namespace AiBridge
{
    public class Dendrite
    {
        /// <summary>
        /// Input value (Pulse) 
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Synaptic Weight
        /// </summary>
        public double Weight { get; private set; }

        //public bool Learnable { get; set; } = true;

        public Dendrite()
        {
            Weight = 0;
            Value = 0;
        }

        public Dendrite(double weight, double value = 0)
        {
            Weight = weight;
            Value = value;
        }

        public void AdjustWeight(double learningRate, double delta)
        {
            Weight += learningRate * delta;
        }
    }
}
