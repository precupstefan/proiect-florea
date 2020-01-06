using System;
using System.Text;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace ProiectFlorea.Utils
{
    public class DiffGenerator
    {
        private string oldText;
        private string newText;

        public DiffGenerator(string oldText, string newText)
        {
            this.oldText = oldText ?? throw new ArgumentNullException(nameof(oldText));
            this.newText = newText ?? throw new ArgumentNullException(nameof(newText));
        }

        public string GetDiffedFile()
        {
            var stringBuilder = new StringBuilder();
            var differ = new Differ();
            var inlineDiffBuilder = new InlineDiffBuilder(differ);
            var result = inlineDiffBuilder.BuildDiffModel(oldText, newText);

            foreach (var line in result.Lines)
            {
                if (line.Type == ChangeType.Inserted)
                {
                    stringBuilder.Append("+ ");
                }
                else if (line.Type == ChangeType.Deleted)
                {
                    stringBuilder.Append("- ");
                }
                else if (line.Type == ChangeType.Modified)
                {
                    stringBuilder.Append("* ");
                }
                else if (line.Type == ChangeType.Imaginary)
                {
                    stringBuilder.Append("? ");
                }
                else if (line.Type == ChangeType.Unchanged)
                {
                    stringBuilder.Append("  ");
                }

                stringBuilder.Append(line.Text + "\r\n");
            }

            return stringBuilder.ToString();
        }
    }
}