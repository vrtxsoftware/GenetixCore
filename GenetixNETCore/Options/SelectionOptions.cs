using System;
using System.Collections.Generic;
using System.Text;

namespace VRTX.AI.Genetix.Options
{
    public class SelectionOptions
    {
        /// <summary>
        /// Value from 0 - 1 that determines how much of the best solutions in the population is kept during selection.
        /// A value of 0.1 would mean that the top 10% is kept.
        /// </summary>
        public float Percentage { get; set; }
    }
}
