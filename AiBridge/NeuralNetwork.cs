using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiBridge
{
    public class NeuralNetwork
    {
        public double Accuracy { get; private set; }
        public List<NeuralLayer> Layers { get; set; }

        public NeuralNetwork()
        {
            Layers = new List<NeuralLayer>();
        }

        public void AddLayer(NeuralLayer layer)
        {
            Layers.Add(layer);
            //int dendriteCount = 1;

            //if (Layers.Count > 0)
            //{
            //    dendriteCount = Layers.Last().Neurons.Count;
            //}

            //foreach (var element in layer.Neurons)
            //{
            //    for (int i = 0; i < dendriteCount; i++)
            //    {
            //        element.Dendrites.Add(new Dendrite());
            //    }
            //}
        }


        public void SetInputs(params double[] values)
        {
            SetInputs(values.ToList());
        }

        public void SetInputs(IList<double> values)
        {
            int i = 0;
            foreach (var neuron in Layers.First().Neurons)
            {
                if (i < values.Count)
                {
                    foreach (var dendrites in neuron.Dendrites)
                    {
                        if (i < values.Count)
                            dendrites.Value = values[i++];
                    }
                }
            }
        }
                
        /// <summary>
        /// Calculate output of the neural network.
        /// </summary>
        /// <returns></returns>
        public List<IPulse> GetOutputs()
        {
            var values = new List<IPulse>();

            Layers.Last().Neurons.ForEach(neuron =>
            {
                values.Add(neuron.Axon);
            });

            return values;
        }

        public void Compute()
        {
            for (int index = 0; index < Layers.Count; index++)
            {
                var currentLayer = Layers[index];

                currentLayer.Compute();
                
                //Transfer values to next layer
                if (index < Layers.Count - 1)
                {
                    var nextLayer = Layers[index + 1];
                    foreach (var neuron in nextLayer.Neurons)
                    {
                        int j = 0;
                        foreach(var dendrite in neuron.Dendrites)
                        {
                            dendrite.Value = currentLayer.Neurons[j++].Axon.Value;
                        }
                    }
                }
            }
        }

        public double CalculateError(params double[] expectedValues)
        {
            return CalculateError(expectedValues.ToList());
        }

        public double CalculateError(IList<double> expectedValues)
        {
            double totalError = 0;

            int i = 0;
            GetOutputs().ForEach(output =>
            {
                var error = Math.Pow(output.Value - expectedValues[i++], 2);
                totalError += error;
            });

            return totalError;
        }

        public double CalculateAccuracy(IList<double> expectedValues)
        {
            double accuracy = 0;

            int i = 0;
            GetOutputs().ForEach(output =>
            {
                if (output.Value == expectedValues[i++])
                    accuracy++;
            });

            return (accuracy / i); //* 100 ;
        }

        private void AdjustWeight(double learningRate, double delta)
        {
            foreach (var layer in Layers)
            {
                layer.AdjustWeight(learningRate, delta);
            }
        }

        private void OptimizeWeights(double accuracy, double learningRate, double delta)
        {
            //Skip if the accuracy reached 100%
            if (accuracy == 1)
                return;
            
            if (accuracy > 1)
                learningRate = -learningRate;

            //Update the weights for all the layers
            AdjustWeight(learningRate, delta);
        }
        public void Train(List<List<double>> inputValues, List<List<double>> expectedValues, double learningRate, int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                List<double> errors = new List<double>();
                List<double> accuracies = new List<double>();
                for (int j = 0; j < inputValues.Count; j++)
                {
                    this.SetInputs(inputValues[j]);
                    this.Compute();
                    var error = this.CalculateError(expectedValues[j]);
                    var accuracy = this.CalculateAccuracy(expectedValues[j]);
                    
                    errors.Add(error);
                    accuracies.Add(accuracy);

                    //Console.WriteLine($"Iteration: {i}, test: {j}, error: {error}, accuracy: {accuracy}");
                }
                               
                var avgError = errors.Average();
                var avgAccuracy = accuracies.Average();
                
                this.Accuracy = avgAccuracy;
                this.OptimizeWeights(this.Accuracy, learningRate, 1);

                Console.WriteLine($"Iteration: {i,3}, error: {avgError,4}, accuracy: {avgAccuracy,4}");
                Console.WriteLine();
            }
        }
    }
}
