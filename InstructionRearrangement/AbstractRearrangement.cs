using System.Collections.Generic;

namespace InstructionRearrangement
{
    public abstract class AbstractRearrangement
    {
        protected List<string> instructions;

        public abstract List<string> ImproveCode();
    }
}