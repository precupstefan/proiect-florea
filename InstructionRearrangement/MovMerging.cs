using System.Collections.Generic;
using Entities;

namespace InstructionRearrangement
{
    public class MovMerging : AbstractRearrangement
    {

        public MovMerging(List<string> assemblyLines, List<Trace> originalTracesLines) : base(assemblyLines,
            originalTracesLines)
        {
        }
    }
}