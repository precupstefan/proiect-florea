using System.IO;
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

        public FileReader PromptUserForFile()
        {
            var fileDialog = new OpenFileDialog {Filter = ProiectFlorea.Properties.Resources.SupportedFormats};
            var dialogResult = fileDialog.ShowDialog();
            SelectedFIle = dialogResult == DialogResult.OK ? fileDialog.FileName : null;
            return this;
        }
    }
}