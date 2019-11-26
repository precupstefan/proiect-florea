using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using ProiectFlorea.Utils;

namespace ProiectFlorea
{
    public partial class Form1 : Form
    {
        private List<string> originalText;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OriginalLinesListBox.Items.Clear();
            originalText = new FileReader()
                .PromptUserForFile()
                .ReadLinesFromFile();

            originalText.ForEach((s => OriginalLinesListBox.Items.Add(s)));
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
    }
}