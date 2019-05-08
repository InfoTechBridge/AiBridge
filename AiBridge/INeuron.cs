using System;
using System.Collections.Generic;
using System.Text;

namespace AiBridge
{
    public interface INeuron
    {
        /// <summary>
        /// Inputs of neuron
        /// </summary>
        List<Dendrite> Dendrites { get; }

        /// <summary>
        /// Output of the neuron
        /// </summary>
        IPulse Axon { get; }

        /// <summary>
        /// Computes Axson value based on Dendrites values and Activation function
        /// </summary>
        void Compute();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        double Activation(double value);
        void AdjustWeight(double learningRate, double delta);
        void AddDendrite(Dendrite dendrite);
        void AddDendrites(List<Dendrite> dendrites);
    }
}
