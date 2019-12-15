using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProiectFlorea
{
    public class FileReader
    {
        private string SelectedFIle;

        public string ReadFromFile()
        {
            using var fileStream = new StreamReader(SelectedFIle);
            return fileStream.ReadToEnd();
        }

        public FileReader PromptUserForFile(string format)
        {
            var fileDialog = new OpenFileDialog {Filter = format};
            var dialogResult = fileDialog.ShowDialog();
            SelectedFIle = dialogResult == DialogResult.OK ? fileDialog.FileName : null;
            return this;
        }

        public List<string> ReadLinesFromFile()
        {
            return ReadFromFile().Split(separator: "\n").ToList();
        }
    }
}