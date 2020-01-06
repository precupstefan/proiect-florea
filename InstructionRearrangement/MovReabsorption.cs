using System.Collections.Generic;
using Entities;

namespace InstructionRearrangement
{
    public class MovReabsorption : AbstractRearrangement
    {
        public MovReabsorption(List<string> assemblyLines, List<Trace> originalTracesLines) 
            : base(assemblyLines, originalTracesLines)
        {

        }
    }
}