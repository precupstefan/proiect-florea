﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entities;
using InstructionRearrangement;
using Utils;
using AbstractRearrangement = ProiectFlorea.InstructionRearrangement.AbstractRearrangement;
using ImmediateMerging = ProiectFlorea.InstructionRearrangement.ImmediateMerging;
using MegaBlockBuilder = ProiectFlorea.Utils.MegaBlockBuilder;
using MegaInstruction = ProiectFlorea.Entities.MegaInstruction;
using Trace = ProiectFlorea.Entities.Trace;

namespace ProiectFlorea
{
    public partial class Form1 : Form
    {
        private List<string> originalAssemblyLines;
        private List<string> modifiableAssemblyLines;
        private List<Trace> originalTracesLines;
        private List<MegaInstruction> megaInstructions;
        private string selectedFile = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OriginalLinesListBox.Items.Clear();
            OriginalTracesListBox.Items.Clear();

            var fileReader = new FileReader();

            originalAssemblyLines = fileReader
                .PromptUserForFile("INS (*.ins)|*.ins")
                .ReadLinesFromFile();
            originalAssemblyLines = originalAssemblyLines
                .Select(s => Regex.Replace(s, @"[^0-9a-zA-Z:,-_# /* *()""]+", ""))
                .ToList();

            selectedFile = fileReader.SelectedFIle;

            modifiableAssemblyLines = originalAssemblyLines.ToList();

            var originalTraceLines = new FileReader()
                .PromptUserForFile("TRC (*.trc)|*.trc")
                .ReadLinesFromFile();

            var regex = new Regex("[ ]{2,}", RegexOptions.None);
            var originalTraces = new List<string>();

            originalTraceLines.ForEach(line =>
            {
                var stuff = regex.Replace(line, " ");
                var smth = stuff.Split(" ");

                for (var i = 0; i < smth.Length - 1; i += 3)
                {
                    originalTraces.Add($"{smth[i]} {smth[i + 1]} {smth[i + 2]}");
                }
            });

            originalAssemblyLines.ForEach(s => OriginalLinesListBox.Items.Add(s));
            originalAssemblyLines.ForEach(s => OriginalLinesTextBox.AppendText(s + Environment.NewLine));
            originalTraces.ForEach(s => OriginalTracesListBox.Items.Add(s));
            originalTracesLines = originalTraces.Select(trace => new Trace(trace)).ToList();
        }

        private void FixIssuesButton_Click(object sender, EventArgs e)
        {
            AbstractRearrangement abstractRearrangement = new ImmediateMerging(modifiableAssemblyLines, originalTracesLines);
            modifiableAssemblyLines = abstractRearrangement.Rearrange();
            modifiableAssemblyLines.ForEach(line => ModifiedLinesListBox.Items.Add(line));
            modifiableAssemblyLines.ForEach(s => ModifiedLinesTextBox.AppendText(s + Environment.NewLine));
        }

        private void CreateMegaBlockButton_Click(object sender, EventArgs e)
        {
            var builder = new MegaBlockBuilder();
            megaInstructions = builder.Build(originalAssemblyLines, originalTracesLines);
            megaInstructions.ForEach(item => MegaBlockListBox.Items.Add(item.ToString()));
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (selectedFile == "")
            {
                MessageBox.Show("NO FILE SELECTED");
                return;
            }

            var path = selectedFile.Insert(selectedFile.Length - 4, "-improved");
            using (var streamWriter = File.CreateText(path))
            {
                modifiableAssemblyLines.ForEach(streamWriter.WriteLine);
            }

            MessageBox.Show("File Saved successfully");
        }
    }
}