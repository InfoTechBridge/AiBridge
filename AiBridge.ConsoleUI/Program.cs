using System;
using System.Collections.Generic;
using System.Linq;

namespace AiBridge.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            NeuralNetwork net = new NeuralNetwork();

            NeuralLayer LI = new NeuralLayer("LI");
            //LI.AddNeuron(new StepNeuron(1, 1));
            //LI.AddNeuron(new StepNeuron(1, 1));
            LI.AddNeuron(new InputNeuron());
            LI.AddNeuron(new InputNeuron());
            net.AddLayer(LI);

            NeuralLayer H0 = new NeuralLayer("H0");
            H0.AddNeuron(new StepNeuron(2, 0.1));
            H0.AddNeuron(new StepNeuron(2, 0.1));
            net.AddLayer(H0);

            NeuralLayer H1 = new NeuralLayer("H1");
            H1.AddNeuron(new StepNeuron(2, 0.1));
            H1.AddNeuron(new StepNeuron(2, 0.1));
            net.AddLayer(H1);

            //NeuralLayer H2 = new NeuralLayer("H1");
            //H2.AddNeuron(new StepNeuron(2, 0.2));
            //H2.AddNeuron(new StepNeuron(2, 0.2));
            //net.AddLayer(H2);

            NeuralLayer LO = new NeuralLayer("LO");
            LO.AddNeuron(new StepNeuron(2, 0.1));
            net.AddLayer(LO);


            //NeuralLayer LI = new NeuralLayer("LI");
            //LI.AddNeuron(new StepNeuron(2, 0.1));
            //net.AddLayer(LI);

            //for (int i = 0; i < 10; i++)
            //{
            //    net.SetInputs(0, 0);
            //    net.Compute();
            //    Console.WriteLine($"output: {net.GetOutputs().First().Value} error: {net.CalculateTotalError(0)}");

            //    net.SetInputs(0, 1);
            //    net.Compute();
            //    Console.WriteLine($"output: {net.GetOutputs().First().Value} error: {net.CalculateTotalError(0)}");

            //    net.SetInputs(1, 0);
            //    net.Compute();
            //    Console.WriteLine($"output: {net.GetOutputs().First().Value} error: {net.CalculateTotalError(0)}");

            //    net.SetInputs(1, 1);
            //    net.Compute();
            //    Console.WriteLine($"output: {net.GetOutputs().First().Value} error: {net.CalculateTotalError(1)}");

            //    Console.WriteLine("-------------");

            //    net.AdjustWeight(.1, 1);
            //}

            var inputs = new List<List<double>>() {
                new List<double> {0, 0},
                new List<double> {0, 1},
                new List<double> {1, 0},
                new List<double> {1, 1},
            };
            var expectedValues = new List<List<double>>() {
                new List<double> {0},
                new List<double> {0},
                new List<double> {0},
                new List<double> {1},
            };

            net.Train(inputs, expectedValues, 0.1, 10);

            foreach (var layer in net.Layers)
            {
                Console.Write($"{layer.LayerName} {layer.Neurons.Count}");
                foreach (var neuron in layer.Neurons)
                {
                    foreach (var dendrite in neuron.Dendrites)
                    {
                        Console.Write($", {dendrite.Weight}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
