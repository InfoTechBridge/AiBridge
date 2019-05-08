using System;
using System.Collections.Generic;
using System.Text;

namespace AiBridge
{
    public class NeuralLayer
    {
        public string LayerName { get; set; }
        public List<INeuron> Neurons { get; set; }

        public NeuralLayer(string name = "")
        {
            Neurons = new List<INeuron>();
            LayerName = name;
        }
                
        public void Compute()
        {
            foreach (var neuron in Neurons)
            {
                neuron.Compute();
            }
        }

        public void AdjustWeight(double learningRate, double delta)
        {
            foreach (var neuron in Neurons)
            {
                neuron.AdjustWeight(learningRate, delta);
            }
        }

        public virtual void AddNeuron(INeuron neuron)
        {
            Neurons.Add(neuron);
        }

        public virtual void AddNeurons(List<INeuron> neurons)
        {
            Neurons.AddRange(neurons);
        }
    }
}
