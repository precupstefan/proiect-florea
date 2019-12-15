namespace Entities
{
    public class Instruction
    {
        public string FULL { get; }

        public string MNEMONIC { get; }

        public string DESTINATION { get; }

        public string SOURCE1 { get; }

        public string SOURCE2 { get; }

        public Instruction(string instruction)
        {
            FULL = instruction;
            var splitInstruction = instruction.Split(' ');

            var mnemonic = splitInstruction[0].Trim();
            var destination = splitInstruction[1].Replace(",", "").Trim();
            MNEMONIC = mnemonic;
            DESTINATION = destination;

            if (splitInstruction.Length > 2)
            {
                var source1 = splitInstruction[2].Replace(",", "").Trim();
                SOURCE1 = source1;
            }

            if (splitInstruction.Length >= 3)
            {
                var source2 = splitInstruction.Length == 4 ? splitInstruction[3].Trim() : null;
                SOURCE2 = source2;
            }
        }

        public override string ToString()
        {
            return FULL;
        }
    }
}