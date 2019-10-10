﻿using System;
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
            var sb = new StringBuilder();
            var d = new Differ();
            var builder = new InlineDiffBuilder(d);
            var result = builder.BuildDiffModel(oldText, newText);


            foreach (var line in result.Lines)
            {
                if (line.Type == ChangeType.Inserted)
                {
                    sb.Append("+ ");
                }
                else if (line.Type == ChangeType.Deleted)
                {
                    sb.Append("- ");
                }
                else if (line.Type == ChangeType.Modified)
                {
                    sb.Append("* ");
                }
                else if (line.Type == ChangeType.Imaginary)
                {
                    sb.Append("? ");
                }
                else if (line.Type == ChangeType.Unchanged)
                {
                    sb.Append("  ");
                }

                sb.Append(line.Text + "\r\n");
            }

            return sb.ToString();
        }
    }
}