using System;
using VRTX.AI.Genetix;
using VRTX.AI.Genetix.Options;

namespace GenetixNETCoreExamples
{
    class Program
    {
        static int BoolArrayToInt(bool[] arr)
        {
            if (arr.Length > 31)
                throw new ApplicationException("too many elements to be converted to a single int");
            int val = 0;
            for (int i = 0; i < arr.Length; ++i)
                if (arr[i]) val |= 1 << i;
            return val;
        }

        static void Main(string[] args)
        {
            GenetixSimulation simulation = new GenetixSimulation();
            simulation.SimulationOptions.Evaluation.Order = EvaluationOptions.FitnessOrder.LowerIsBetter;
            simulation.SimulationOptions.Evaluation.FitnessFunction = (i) =>
            {
                int value = BoolArrayToInt(i.Chromosome);

                return Math.Abs(216 - value);
            };

            simulation.SimulationOptions.Population.Size = 100;
            simulation.SimulationOptions.Population.ChromosomeLength = 8;

            simulation.SimulationOptions.Selection.Percentage = 0.1f;
            simulation.SimulationOptions.Mutation.Probability = 10;

            while (simulation.Generation == 0 || simulation.Population[0].Fitness != 0)
            {
                simulation.RunNext();

                Console.WriteLine(String.Format("Generation {0}, best fitness: {1}", 
                    simulation.Generation, simulation.Population[0].Fitness));
            }

            Console.ReadKey();
        }
    }
}
