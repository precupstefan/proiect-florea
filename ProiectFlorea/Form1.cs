using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using Entities;
using ProiectFlorea.Utils;
using Utils;

namespace ProiectFlorea
{
    public partial class Form1 : Form
    {
        private List<string> originalAssemblyLines;
        private List<Trace> originalTracesLines;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OriginalLinesListBox.Items.Clear();
            OriginalTracesListBox.Items.Clear();
            originalAssemblyLines = new FileReader()
                .PromptUserForFile("INS (*.ins)|*.ins")
                .ReadLinesFromFile();
            originalAssemblyLines = originalAssemblyLines
                .Select(s => Regex.Replace(s, @"[^0-9a-zA-Z:,-_# /* *()]+", ""))
                .ToList();

            var originaltrLines = new FileReader()
                .PromptUserForFile("TRC (*.trc)|*.trc")
                .ReadLinesFromFile();

            var originalTraces = new List<string>();
            originaltrLines.ForEach(line =>
            {
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                var stuff = regex.Replace(line, " ");
                var smth = stuff.Split(" ");
                for (var i = 0; i < smth.Length - 1; i += 3)
                {
                    originalTraces.Add($"{smth[i]} {smth[i + 1]} {smth[i + 2]}");
                }
            });

            originalAssemblyLines.ForEach((s => OriginalLinesListBox.Items.Add(s)));
            originalTraces.ForEach(s => OriginalTracesListBox.Items.Add(s));
            originalTracesLines = originalTraces.Select(trace => new Trace(trace)).ToList();
        }

        private void MovMergingButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void MovReabsorptionButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ImmediateMergingButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void MemoryAntiAliasButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void CreateMegaBlockButton_Click(object sender, EventArgs e)
        {
            var builder = new MegaBlockBuilder();
            var list = builder.Build(originalAssemblyLines, originalTracesLines);
            list.ForEach(item => MegaBlockListBox.Items.Add(item.ToString()));
        }
    }
}