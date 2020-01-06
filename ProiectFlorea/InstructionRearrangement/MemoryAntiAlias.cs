using System.Collections.Generic;
using Entities;
using InstructionRearrangement;
using Trace = ProiectFlorea.Entities.Trace;

namespace ProiectFlorea.InstructionRearrangement
{
    public class MemoryAntiAlias: AbstractRearrangement
    {
        public MemoryAntiAlias(List<string> assemblyLines, List<Trace> originalTracesLines) : base(assemblyLines, originalTracesLines)
        {

        }
    }
}