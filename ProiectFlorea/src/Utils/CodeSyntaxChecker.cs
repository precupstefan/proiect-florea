using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ProiectFlorea.instructions;

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

        private static bool IsInvalidInstruction(Line line) => !IsValidInstruction(line);

        private static bool IsValidInstruction(Line line)
        {
            if (!line.HasContent) return false;
            var instructionRegex = GetInstructionFormatRegexFromOperator(line.Operator);
            if (instructionRegex == null) return false;
            var regex = new Regex(instructionRegex);
            return regex.IsMatch(line.Instruction);
        }

        private static string GetInstructionFormatRegexFromOperator(string instructionType)
        {
            var operatorMethod = typeof(RequiredInstructionFormat).GetProperty(instructionType);
            return operatorMethod != null ? (string) operatorMethod.GetValue(null, null) : null;
        }
    }
}