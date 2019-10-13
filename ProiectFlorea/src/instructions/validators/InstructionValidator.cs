using System;
using System.Text.RegularExpressions;

namespace ProiectFlorea.instructions.validators
{
    public abstract class InstructionValidator
    {
        protected abstract string Format { get; }

        public bool IsValid(string instruction)
        {
            var regex = new Regex(Format);
            return regex.IsMatch(instruction);
        }
    }
}