using System.Linq;
using Entities;

namespace Utils
{
    public class InstructionUtil
    {
        public static InstructionType TypeOf(string instruction)
        {
            var mnemonic = instruction.Split(" ")[0];
            if (mnemonic.Contains("LD"))
            {
                return InstructionType.Load;
            }

            if (mnemonic.Contains("ST"))
            {
                return InstructionType.Store;
            }

            // TODO ADD MOV PC
            var bramches = new string[]
            {
                "BT", "BF", "BSR", "TRAP"
            };
            if (bramches.Any(branch => branch.Contains(mnemonic)))
            {
                return InstructionType.Branch;
            }

            if (instruction.Contains("MOV PC"))
            {
                return InstructionType.Branch;
            }

            return InstructionType.Arithmetic;
        }

        public static bool IsBranchInstructionWithLabel(string instruction)
        {
            var branchMnemonics = new string[]
            {
                "BT", "BF", "BSR"
            };
            return branchMnemonics.Any(instruction.Contains);
        }

        public static bool IsTrap(string instruction) => instruction.Contains("TRAP");
        public static bool IsBsrBranch(string instruction) => instruction.Contains("BSR");

        public static bool IsMovBranchInstruction(string instruction)
        {
            return instruction.Contains("MOV PC");
        }

        public static string GetLabelFromBranchInstruction(string instruction)
        {
            var splitInstruction = instruction.Split(" ");
            return splitInstruction[2];
        }

        public static bool IsLabelCommentOrEmptyString(string instruction)
        {
            if (instruction.Contains("/*"))
            {
                return true;
            }

            if (instruction.Contains(":"))
            {
                return true;
            }

            if (instruction.Length == 0)
            {
                return true;
            }

            return false;
        }
    }
}