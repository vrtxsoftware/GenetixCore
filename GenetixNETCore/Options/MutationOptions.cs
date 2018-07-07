using System;
using System.Collections.Generic;
using System.Text;

namespace VRTX.AI.Genetix.Options
{
    public class MutationOptions
    {
        /// <summary>
        /// The chance of 1 in x that a mutation happens, where x is the value for Probability.
        /// </summary>
        public int Probability { get; set; }
    }
}
