using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiBridge
{
    public class Neuron : INeuron
    {
        /// <summary>
        /// Inputs of neuron
        /// </summary>
        public List<Dendrite> Dendrites { get; protected set; }

        /// <summary>
        /// Output of the neuron
        /// </summary>
        public IPulse Axon { get; protected set; }

        public Neuron()
        {
            Dendrites = new List<Dendrite>();
            Axon = new Pulse();
        }

        public Neuron(int dendriteCount, double initialWeight)
        {
            Dendrites = new List<Dendrite>();
            for (int i = 0; i < dendriteCount; i++)
            {
                Dendrites.Add(new Dendrite(initialWeight));
            }
            Axon = new Pulse();
        }

        public virtual void Compute()
        {
            var sum = Dendrites.Sum(dendrite => dendrite.Value * dendrite.Weight);
            Axon.Value = Activation(sum);
        }

        public virtual double Activation(double value)
        {
            double threshold = 1;
            return (value <= threshold) ? 0 : threshold;
        }

        public virtual void AdjustWeight(double learningRate, double delta)
        {
            foreach (var dendrite in Dendrites)
            {
                dendrite.AdjustWeight(learningRate, delta);
            }
        }

        public virtual void AddDendrite(Dendrite dendrite)
        {
            Dendrites.Add(dendrite);
        }

        public virtual void AddDendrites(List<Dendrite> dendrites)
        {
            Dendrites.AddRange(dendrites);
        }


    }
}
