using System.Collections.Generic;
using ProiectFlorea.Entities;

namespace ProiectFlorea.InstructionRearrangement
{
    public class MovMerging : AbstractRearrangement
    {
        public MovMerging(List<string> assemblyLines, List<Trace> originalTracesLines) 
            : base(assemblyLines, originalTracesLines)
        {

        }
    }
}