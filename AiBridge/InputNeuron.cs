using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiBridge
{
    public class InputNeuron : Neuron
    {

        public InputNeuron()
            : base(1, 1)
        {
            
        }

        //public override void Compute()
        //{
        //    var sum = Dendrites.Sum(dendrite => dendrite.Value * dendrite.Weight);
        //    Axon.Value = Activation(sum);
        //}

        public override double Activation(double value)
        {
            return value;
        }
        public override void AdjustWeight(double learningRate, double delta)
        {
            //throw new InvalidOperationException("It is not allowed to call this method on Input Neuron");
        }

        public override void AddDendrite(Dendrite dendrite)
        {
            throw new InvalidOperationException("It is not allowed to call this method on Input Neuron");
        }

        public override void AddDendrites(List<Dendrite> dendrites)
        {
            throw new InvalidOperationException("It is not allowed to call this method on Input Neuron");
        }

    }
}
