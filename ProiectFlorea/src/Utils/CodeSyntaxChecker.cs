using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProiectFlorea.instructions;
using ProiectFlorea.instructions.validators;

namespace ProiectFlorea.Utils
{
    /*
     * Checks the syntax of instruction codes
     */
    public static class CodeSyntaxChecker
    {
        public static (bool, IEnumerable<Line> invalidInstructions) IsValid(string code)
        {
            // TODO: Find a better name
            var splittedCode = code.Split(separator: Environment.NewLine);
            var lines = splittedCode.Select((instruction, index) => new Line
            {
                Instruction = instruction,
                LineNumber = index + 1
            });
            return IsValid(lines);
        }

        public static (bool, IEnumerable<Line> invalidInstructions) IsValid(IEnumerable<Line> lines)
        {
            var invalidInstructions = lines.Where(IsInvalidInstruction);
            var instructions = invalidInstructions as Line[] ?? invalidInstructions.ToArray();
            return (instructions.Any(), instructions);
        }

        private static bool IsInvalidInstruction(Line line)
        {
            if (!line.HasContent)
            {
                return false;
            }

            var operation = line.Operator;
            var instructionType = Type.GetType($"ProiectFlorea.instructions.validators.{operation}");
            if (instructionType == null)
            {
                return true;
            }

            var instruction = (InstructionValidator) Activator.CreateInstance(instructionType);
            return !instruction.IsValid(line.Instruction);
        }
    }
}