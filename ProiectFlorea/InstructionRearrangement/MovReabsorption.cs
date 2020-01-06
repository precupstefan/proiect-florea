using System.Collections.Generic;
using ProiectFlorea.Entities;

namespace ProiectFlorea.InstructionRearrangement
{
    public class MovReabsorption : AbstractRearrangement
    {
        public MovReabsorption(List<string> assemblyLines, List<Trace> originalTracesLines) 
            : base(assemblyLines, originalTracesLines)
        {

        }
    }
}