using System.Collections.Generic;
using Entities;

namespace InstructionRearrangement
{
    public class MemoryAntiAlias: AbstractRearrangement
    {


        public MemoryAntiAlias(List<string> assemblyLines, List<Trace> originalTracesLines) : base(assemblyLines, originalTracesLines)
        {
        }
    }
}