using System;
using System.Collections.Generic;
using Entities;

namespace Utils
{
    public class MegaBlockBuilder
    {
        private int index = 0;
        private int? PC = 0;
        private Stack<int> IndexQueue = new Stack<int>();
        private Dictionary<int, String> pcDict = new Dictionary<int, String>();


        public List<MegaInstruction> Build(List<string> assemblyLines, List<Trace> traceLines)
        {
            if (assemblyLines.Count == 0)
            {
                throw new ArgumentException("Empty assemblyLines");
            }

            if (traceLines.Count == 0)
            {
                throw new ArgumentException("Empty traceLines");
            }

            var list = new List<MegaInstruction>();
            var tracesHandled = 0;
            traceLines.ForEach(
                trace =>
                {
                    tracesHandled++;
                    var goToNextTrace = false;
                    while (!goToNextTrace)
                    {
                        var instruction = assemblyLines[index];
                        if (instruction.Contains("trap"))
                        {
                            var x = 1 == 1;
                        }

                        if (InstructionUtil.IsLabelCommentOrEmptyString(instruction))
                        {
                            index++;
                            continue;
                        }

                        if (!pcDict.ContainsKey((int) PC) ||
                            !pcDict[(int) PC].Equals(instruction))
                        {
                            pcDict.Add((int) PC, instruction);
                        }

                        var instructionType = InstructionUtil.TypeOf(instruction);
                        if (instructionType == InstructionType.Arithmetic)
                        {
                            var arithmeticTrace = new Trace($"A {PC} XXXX");
                            var megaInstruction = new MegaInstruction(index + 1, instruction, arithmeticTrace);
                            list.Add(megaInstruction);
                            index++;
                        }
                        else
                        {
                            goToNextTrace = true;
                            if (instructionType == InstructionType.Load || instructionType == InstructionType.Store)
                            {
                                var megaInstruction = new MegaInstruction(index + 1, instruction, trace);
                                list.Add(megaInstruction);
                                index++;
                            }

                            if (instructionType == InstructionType.Branch)
                            {
                                var desiredTrace = trace;
                                var shouldSkip = false;
                                if (
//                                    !trace.IsOfType(TraceType.Branch)|| 
                                    trace.CURRENT_ADDRESS != PC)
                                {
                                    desiredTrace = new Trace($"A {PC} XXXX");
                                    shouldSkip = true;
                                }

                                var megaInstruction = new MegaInstruction(index + 1, instruction, desiredTrace);
                                list.Add(megaInstruction);
                                if (shouldSkip)
                                {
                                    PC++;
                                    index++;
                                    goToNextTrace = false;
                                    continue;
                                }


                                index = DetermineIndex(assemblyLines, instruction);
                            }
                        }

                        PC = instructionType != InstructionType.Branch ? PC + 1 : trace.DESTINATION_ADDRESS;
                    }
                });
            return list;
        }

        private int DetermineIndex(List<string> assemblyLines, string instruction)
        {
            var isBranchInstructionWithLabel = InstructionUtil.IsBranchInstructionWithLabel(instruction);
            if (isBranchInstructionWithLabel && !instruction.Contains("printf"))
            {
                var label = InstructionUtil.GetLabelFromBranchInstruction(instruction);

                var indexOfLabel = assemblyLines.FindIndex(s => s.Contains(label + ":"));

                if (indexOfLabel == -1)
                {
                    return index++;
                }

                if (InstructionUtil.IsBsrBranch(instruction))
                {
                    IndexQueue.Push(index + 1);
                }

                return indexOfLabel + 1;
            }

            var isMovBranch = InstructionUtil.IsMovBranchInstruction(instruction);
            if (isMovBranch || instruction.Contains("printf"))
            {
                return IndexQueue.Pop();
            }

            if (InstructionUtil.IsTrap(instruction))
            {
                return -1;
            }

            throw new Exception($"Unknown Branch instruction, {instruction}");
        }
    }
}