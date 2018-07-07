using System;
using System.Collections.Generic;
using System.Text;
using VRTX.AI.Genetix.Options;

namespace VRTX.AI.Genetix
{
    public class GenetixSimulation
    {
        public SimulationOptions SimulationOptions { get; set;}
        public int Generation { get; set; }
        public Solution[] Population { get; set; }

        private Random random;

        public GenetixSimulation()
        {
            SimulationOptions = new SimulationOptions();

            random = new Random(100);
        }

        public void RunNext()
        {
            if (Generation == 0) InitializePopulation();

            SelectionAndCrossover();
            Mutation();
            Evaluation();

            Generation++;
        }

        private void InitializePopulation()
        {
            Population = new Solution[SimulationOptions.Population.Size];

            for (int i = 0; i < Population.Length; i++)
            {
                Population[i] = new Solution(SimulationOptions.Population.ChromosomeLength);

                for (int j = 0; j < Population[i].Chromosome.Length; j++)
                {
                    Population[i].Chromosome[j] = random.Next(0, 2) == 0 ? true : false;
                }
            }

            Evaluation();
        }

        private void Evaluation()
        {
            for (int i = 0; i < Population.Length; i++)
            {
                Population[i].Fitness = SimulationOptions.Evaluation.FitnessFunction(Population[i]);
            }

            Array.Sort(Population);
        }

        private void SelectionAndCrossover()
        {
            int individualA = 0;
            int individualB = 1;
            int start = (int)(Population.Length * SimulationOptions.Selection.Percentage);

            for (int i = start; i < Population.Length; i += 2)
            {
                Solution[] offspring = Population[individualA].Crossover(Population[individualB]);

                Population[i] = offspring[0];
                Population[i + 1] = offspring[1];

                if (++individualB >= start)
                {
                    individualA++;
                    individualB = individualA + 1;
                }
            }
        }

        private void Mutation()
        {
            for (int i = 0; i < Population.Length; i ++)
            {
                if (random.Next(0, SimulationOptions.Mutation.Probability) == 0) Population[i].Mutate(random);
            }
        }
    }
}
