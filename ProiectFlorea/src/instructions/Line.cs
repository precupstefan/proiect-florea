namespace ProiectFlorea.instructions
{
    public class Line
    {
        public int LineNumber { get; set; }

        public string Instruction { get; set; }

        public string Operator => Instruction.Split(" ")[0];
        public bool HasContent => Instruction.Length != 0;
    }
}