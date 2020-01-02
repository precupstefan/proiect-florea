﻿using System.Collections.Generic;
using System.Net;
using System.Text;
using Entities;
using Utils;

namespace InstructionRearrangement
{
    public class AbstractRearrangement
    {
        protected readonly List<string> AssemblyLines;
        private readonly List<Trace> originalTracesLines;

        private static int LINE_GAP { get; } = 1;
        private static int MAX_INSTRUCTIONS_IN_PIPELINE { get; } = 4;

        private List<string> handledLines = new List<string>();

        protected AbstractRearrangement(List<string> assemblyLines, List<Trace> originalTracesLines)
        {
            this.AssemblyLines = assemblyLines;
            this.originalTracesLines = originalTracesLines;
        }

        public List<string> Rearrange()
        {
            var instructions = new List<MegaInstruction>(MAX_INSTRUCTIONS_IN_PIPELINE);
            var hasCompleted = false;

            var builder = new MegaBlockBuilder();
            var megaInstructions = builder.Build(AssemblyLines, originalTracesLines);

            for (var index = 0; index < megaInstructions.Count - 1; index++)
            {
                var megaInstructionOne = megaInstructions[index];
                var megaInstructionTwo = megaInstructions[index + 1];

                if (handledLines.Contains(megaInstructionOne.ToString()))
                {
                    continue;
                }

                if (Util.CanApplyImmediateMerging(megaInstructionOne, megaInstructionTwo))
                {
                    ApplyImmediateMerging(megaInstructionOne, megaInstructionTwo);
                    handledLines.Add(megaInstructionOne.ToString());
                }

                if (Util.CanApplyMovMerging(megaInstructionOne, megaInstructionTwo))
                {
                    // TODO: Instructiuni gardate????
                    ApplyMovMerging(megaInstructionOne, megaInstructionTwo);
                    handledLines.Add(megaInstructionOne.ToString());
                }

                if (Util.CanApplyMovReabsorption(megaInstructionOne, megaInstructionTwo))
                {
                    ApplyMovReabsorption(megaInstructionOne, megaInstructionTwo);
                    handledLines.Add(megaInstructionOne.ToString());
                }
                
                if (Util.CanApplyMemoryAntiAlias(megaInstructionOne, megaInstructionTwo))
                {
                    // TODO: Line 95/96 same address referenced what to do?
                    handledLines.Add(megaInstructionOne.ToString());
                }
            }

            return AssemblyLines;
        }

        private void ApplyMovReabsorption(MegaInstruction megaInstructionOne, MegaInstruction megaInstructionTwo)
        {
            var instructionOne = megaInstructionOne.Instruction;
            var instructionTwo = megaInstructionTwo.Instruction;

            var instructionLine = megaInstructionTwo.Line;
            var indexOfLine = instructionLine - 1;
            AssemblyLines.RemoveRange(indexOfLine, 1);
            var mergedInstruction = GenerateNewMovReabsorptionInstruction(instructionTwo, instructionOne);
            AssemblyLines.Insert(indexOfLine, mergedInstruction);
        }

        private string GenerateNewMovReabsorptionInstruction(Instruction instructionTwo, Instruction instructionOne)
        {
            var sb = new StringBuilder();
            sb.Append(instructionTwo.MNEMONIC);
            sb.Append(" ");
            sb.Append(instructionTwo.DESTINATION);
            sb.Append(", ");
            sb.Append(instructionOne.SOURCE1);
            sb.Append(", ");
            sb.Append(instructionOne.SOURCE2);
            var mergedInstruction = sb.ToString();
            return mergedInstruction;
        }

        private void ApplyMovMerging(MegaInstruction megaInstructionOne, MegaInstruction megaInstructionTwo)
        {
            var instructionOne = megaInstructionOne.Instruction;
            var instructionTwo = megaInstructionTwo.Instruction;

            if (instructionTwo.MNEMONIC == "ADD")
            {
                var instructionLine = megaInstructionTwo.Line;
                var indexOfLine = instructionLine - 1;
                AssemblyLines.RemoveRange(indexOfLine, 1);
                var mergedInstruction = GenerateNewMovMergingInstruction(instructionTwo, instructionOne);
                AssemblyLines.Insert(indexOfLine, mergedInstruction);
            }
        }

        private static string GenerateNewMovMergingInstruction(Instruction instructionTwo, Instruction instructionOne)
        {
            var sb = new StringBuilder();
            sb.Append(instructionTwo.MNEMONIC);
            sb.Append(" ");
            sb.Append(instructionTwo.DESTINATION);
            sb.Append(", ");
            if (instructionOne.DESTINATION == instructionTwo.SOURCE1)
            {
                sb.Append(instructionOne.SOURCE1);
            }
            else
            {
                sb.Append(instructionTwo.SOURCE1);
            }

            sb.Append(", ");
            if (instructionOne.DESTINATION == instructionTwo.SOURCE2)
            {
                sb.Append(instructionOne.SOURCE1);
            }
            else
            {
                sb.Append(instructionTwo.SOURCE2);
            }

            var mergedInstruction = sb.ToString();
            return mergedInstruction;
        }


        private void ApplyImmediateMerging(MegaInstruction megaInstructionOne, MegaInstruction megaInstructionTwo)
        {
            var instructionOne = megaInstructionOne.Instruction;
            var instructionTwo = megaInstructionTwo.Instruction;

            var mnemonicInstructionOne = instructionOne.MNEMONIC;
            var mnemonicInstructionTwo = instructionTwo.MNEMONIC;

            if ((mnemonicInstructionOne == "DIV" && mnemonicInstructionTwo == "MULT") ||
                (mnemonicInstructionOne == "MULT" && mnemonicInstructionTwo == "DIV"))
            {
                if (instructionOne.SOURCE2 == instructionTwo.SOURCE2)
                {
                    var instructionLine = megaInstructionOne.Line;
                    var indexOfLine = instructionLine - 1;
                    AssemblyLines.RemoveRange(indexOfLine, 2);
                    var newInstruction = $"MOV {instructionTwo.SOURCE1}, {instructionOne.SOURCE1}";
                    AssemblyLines.Insert(indexOfLine, newInstruction);
                    AssemblyLines.Insert(indexOfLine + 1, "");
                }
            }
        }
    }
}