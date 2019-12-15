namespace ProiectFlorea
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.OriginalLinesListBox = new System.Windows.Forms.ListBox();
            this.MovMergingButton = new System.Windows.Forms.Button();
            this.MovReabsorptionButton = new System.Windows.Forms.Button();
            this.ImmediateMergingButton = new System.Windows.Forms.Button();
            this.MemoryAntiAliasButton = new System.Windows.Forms.Button();
            this.CreateMegaBlockButton = new System.Windows.Forms.Button();
            this.OriginalTracesListBox = new System.Windows.Forms.ListBox();
            this.MegaBlockListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(58, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Load a file";
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Location = new System.Drawing.Point(136, 3);
            this.LoadFileButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(64, 23);
            this.LoadFileButton.TabIndex = 2;
            this.LoadFileButton.Text = "Browse";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(394, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Fix issues";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(610, 7);
            this.ExportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(198, 45);
            this.ExportButton.TabIndex = 4;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            // 
            // OriginalLinesListBox
            // 
            this.OriginalLinesListBox.FormattingEnabled = true;
            this.OriginalLinesListBox.ItemHeight = 15;
            this.OriginalLinesListBox.Location = new System.Drawing.Point(50, 104);
            this.OriginalLinesListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OriginalLinesListBox.Name = "OriginalLinesListBox";
            this.OriginalLinesListBox.Size = new System.Drawing.Size(205, 364);
            this.OriginalLinesListBox.TabIndex = 5;
            // 
            // MovMergingButton
            // 
            this.MovMergingButton.Location = new System.Drawing.Point(50, 62);
            this.MovMergingButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MovMergingButton.Name = "MovMergingButton";
            this.MovMergingButton.Size = new System.Drawing.Size(98, 36);
            this.MovMergingButton.TabIndex = 6;
            this.MovMergingButton.Text = "MOV Merging";
            this.MovMergingButton.UseVisualStyleBackColor = true;
            this.MovMergingButton.Click += new System.EventHandler(this.MovMergingButton_Click);
            // 
            // MovReabsorptionButton
            // 
            this.MovReabsorptionButton.Location = new System.Drawing.Point(154, 62);
            this.MovReabsorptionButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MovReabsorptionButton.Name = "MovReabsorptionButton";
            this.MovReabsorptionButton.Size = new System.Drawing.Size(130, 36);
            this.MovReabsorptionButton.TabIndex = 7;
            this.MovReabsorptionButton.Text = "MOV Reabsorption";
            this.MovReabsorptionButton.UseVisualStyleBackColor = true;
            this.MovReabsorptionButton.Click += new System.EventHandler(this.MovReabsorptionButton_Click);
            // 
            // ImmediateMergingButton
            // 
            this.ImmediateMergingButton.Location = new System.Drawing.Point(289, 62);
            this.ImmediateMergingButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ImmediateMergingButton.Name = "ImmediateMergingButton";
            this.ImmediateMergingButton.Size = new System.Drawing.Size(130, 36);
            this.ImmediateMergingButton.TabIndex = 8;
            this.ImmediateMergingButton.Text = "Immediate Merging";
            this.ImmediateMergingButton.UseVisualStyleBackColor = true;
            this.ImmediateMergingButton.Click += new System.EventHandler(this.ImmediateMergingButton_Click);
            // 
            // MemoryAntiAliasButton
            // 
            this.MemoryAntiAliasButton.Location = new System.Drawing.Point(424, 62);
            this.MemoryAntiAliasButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MemoryAntiAliasButton.Name = "MemoryAntiAliasButton";
            this.MemoryAntiAliasButton.Size = new System.Drawing.Size(130, 36);
            this.MemoryAntiAliasButton.TabIndex = 9;
            this.MemoryAntiAliasButton.Text = "MemoryAntiAlias";
            this.MemoryAntiAliasButton.UseVisualStyleBackColor = true;
            this.MemoryAntiAliasButton.Click += new System.EventHandler(this.MemoryAntiAliasButton_Click);
            // 
            // CreateMegaBlockButton
            // 
            this.CreateMegaBlockButton.Location = new System.Drawing.Point(250, 13);
            this.CreateMegaBlockButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CreateMegaBlockButton.Name = "CreateMegaBlockButton";
            this.CreateMegaBlockButton.Size = new System.Drawing.Size(124, 33);
            this.CreateMegaBlockButton.TabIndex = 10;
            this.CreateMegaBlockButton.Text = "Create Mega Block";
            this.CreateMegaBlockButton.UseVisualStyleBackColor = true;
            this.CreateMegaBlockButton.Click += new System.EventHandler(this.CreateMegaBlockButton_Click);
            // 
            // OriginalTracesListBox
            // 
            this.OriginalTracesListBox.FormattingEnabled = true;
            this.OriginalTracesListBox.ItemHeight = 15;
            this.OriginalTracesListBox.Location = new System.Drawing.Point(261, 104);
            this.OriginalTracesListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OriginalTracesListBox.Name = "OriginalTracesListBox";
            this.OriginalTracesListBox.Size = new System.Drawing.Size(205, 364);
            this.OriginalTracesListBox.TabIndex = 11;
            // 
            // MegaBlockListBox
            // 
            this.MegaBlockListBox.FormattingEnabled = true;
            this.MegaBlockListBox.ItemHeight = 15;
            this.MegaBlockListBox.Location = new System.Drawing.Point(474, 104);
            this.MegaBlockListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MegaBlockListBox.Name = "MegaBlockListBox";
            this.MegaBlockListBox.Size = new System.Drawing.Size(300, 364);
            this.MegaBlockListBox.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1272, 764);
            this.Controls.Add(this.MegaBlockListBox);
            this.Controls.Add(this.OriginalTracesListBox);
            this.Controls.Add(this.CreateMegaBlockButton);
            this.Controls.Add(this.MemoryAntiAliasButton);
            this.Controls.Add(this.ImmediateMergingButton);
            this.Controls.Add(this.MovReabsorptionButton);
            this.Controls.Add(this.MovMergingButton);
            this.Controls.Add(this.OriginalLinesListBox);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LoadFileButton);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.ListBox OriginalLinesListBox;
        private System.Windows.Forms.Button MemoryAntiAliasButton;
        private System.Windows.Forms.Button ImmediateMergingButton;
        private System.Windows.Forms.Button MovReabsorptionButton;
        private System.Windows.Forms.Button MovMergingButton;
        private System.Windows.Forms.Button CreateMegaBlockButton;
        private System.Windows.Forms.ListBox OriginalTracesListBox;
        private System.Windows.Forms.ListBox MegaBlockListBox;
    }
}

