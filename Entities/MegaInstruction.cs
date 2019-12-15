using System;

namespace Entities
{
    public class MegaInstruction
    {
        public Instruction Instruction { get; }
        private Trace Trace { get; }

        public MegaInstruction(string instruction, string trace)
        {
            Instruction = new Instruction(instruction);
            Trace = new Trace(trace);
        }

        public MegaInstruction(string instruction, Trace trace)
        {
            Instruction = new Instruction(instruction);
            Trace = trace;
        }

        public override string ToString()
        {
            return $"{Trace.ToString()} - {Instruction.ToString()}";
        }
    }
}