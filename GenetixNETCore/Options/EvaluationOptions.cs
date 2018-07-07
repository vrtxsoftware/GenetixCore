using System;
using System.Collections.Generic;
using System.Text;

namespace VRTX.AI.Genetix.Options
{
    public class EvaluationOptions
    {
        public enum FitnessOrder
        {
            HigherIsBetter,
            LowerIsBetter
        }

        public Func<Solution, float> FitnessFunction { get; set; }
        public FitnessOrder Order { get; set; }
    }
}
