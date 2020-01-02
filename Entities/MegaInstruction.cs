using System;

namespace Entities
{
    public class MegaInstruction
    {
        public Int32 Line { get; }
        public Instruction Instruction { get; }
        public Trace Trace { get; }

        public MegaInstruction(int line, string instruction, string trace)
        {
            Line = line;
            Instruction = new Instruction(instruction);
            Trace = new Trace(trace);
        }

        public MegaInstruction(int line, string instruction, Trace trace)
        {
            Instruction = new Instruction(instruction);
            Trace = trace;
            Line = line;
        }

        public override string ToString()
        {
            return $"{Line}: {Trace.ToString()} - {Instruction.ToString()}";
        }
    }
}