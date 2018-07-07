using System;
using System.Collections.Generic;
using System.Text;

namespace VRTX.AI.Genetix.Options
{
    public class SimulationOptions
    {
        public PopulationOptions Population { get; set; }
        public SelectionOptions Selection { get; set; }
        public CrossoverOptions Crossover { get; set; }
        public MutationOptions Mutation { get; set; }
        public EvaluationOptions Evaluation { get; set; }

        public SimulationOptions()
        {
            Population = new PopulationOptions();
            Selection = new SelectionOptions();
            Crossover = new CrossoverOptions();
            Mutation = new MutationOptions();
            Evaluation = new EvaluationOptions();
        }
    }
}
