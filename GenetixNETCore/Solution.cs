using System;
using System.Collections.Generic;
using System.Text;
using VRTX.AI.Genetix.Options;

namespace VRTX.AI.Genetix
{
    public class Solution : IComparable<Solution>
    {
        public bool[] Chromosome { get; set; }
        public float Fitness { get; set; }

        public Solution(int chromosomeLength)
        {
            Chromosome = new bool[chromosomeLength];
        }

        public Solution[] Crossover(Solution other)
        {
            Solution[] offspring = new Solution[2];
            offspring[0] = new Solution(Chromosome.Length);
            offspring[1] = new Solution(Chromosome.Length);

            Array.Copy(Chromosome, 0, offspring[0].Chromosome, 0, Chromosome.Length / 2);
            Array.Copy(other.Chromosome, Chromosome.Length / 2, offspring[0].Chromosome, Chromosome.Length / 2, Chromosome.Length / 2);

            Array.Copy(other.Chromosome, 0, offspring[1].Chromosome, 0, Chromosome.Length / 2);
            Array.Copy(Chromosome, Chromosome.Length / 2, offspring[1].Chromosome, Chromosome.Length / 2, Chromosome.Length / 2);

            return offspring;
        }

        public void Mutate(Random random)
        {
            /*for (int i = 0; i < Chromosome.Length; i++)
            {
                Console.Write(Chromosome[i] + ", ");
            }
            Console.WriteLine();
            */

            int randomIndex = random.Next(0, Chromosome.Length);

            Chromosome[randomIndex] = !Chromosome[randomIndex];

            /*for (int i = 0; i < Chromosome.Length; i++)
            {
                Console.Write(Chromosome[i] + ", ");
            }
            Console.WriteLine();*/
        }

        public int CompareTo(Solution other)
        {
            return Fitness.CompareTo(other.Fitness);
        }
    }
}
