namespace SyntaxWinApp03
{
    partial class FrmMain
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnLord = new Button();
            BtnSave = new Button();
            RtbNote = new RichTextBox();
            BtnRed = new Button();
            BtnBold = new Button();
            DlgOpen = new OpenFileDialog();
            DlgSave = new SaveFileDialog();
            DlgColor = new ColorDialog();
            SuspendLayout();
            // 
            // BtnLord
            // 
            BtnLord.Location = new Point(472, 269);
            BtnLord.Name = "BtnLord";
            BtnLord.Size = new Size(100, 30);
            BtnLord.TabIndex = 0;
            BtnLord.Text = "읽기";
            BtnLord.UseVisualStyleBackColor = true;
            BtnLord.Click += BtnLord_Click;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(366, 269);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(100, 30);
            BtnSave.TabIndex = 0;
            BtnSave.Text = "저장";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // RtbNote
            // 
            RtbNote.Font = new Font("나눔고딕", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 129);
            RtbNote.Location = new Point(12, 12);
            RtbNote.Name = "RtbNote";
            RtbNote.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            RtbNote.Size = new Size(560, 251);
            RtbNote.TabIndex = 1;
            RtbNote.Text = "";
            RtbNote.WordWrap = false;
            // 
            // BtnRed
            // 
            BtnRed.BackColor = SystemColors.ControlLight;
            BtnRed.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            BtnRed.ForeColor = Color.Red;
            BtnRed.Location = new Point(294, 269);
            BtnRed.Name = "BtnRed";
            BtnRed.Size = new Size(30, 30);
            BtnRed.TabIndex = 2;
            BtnRed.Tag = "";
            BtnRed.Text = "R";
            BtnRed.UseVisualStyleBackColor = false;
            BtnRed.Click += BtnRed_Click;
            // 
            // BtnBold
            // 
            BtnBold.BackColor = SystemColors.ControlLight;
            BtnBold.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            BtnBold.ForeColor = Color.Black;
            BtnBold.Location = new Point(330, 269);
            BtnBold.Name = "BtnBold";
            BtnBold.Size = new Size(30, 30);
            BtnBold.TabIndex = 2;
            BtnBold.Text = "B";
            BtnBold.UseVisualStyleBackColor = false;
            BtnBold.Click += BtnBold_Click;
            // 
            // DlgOpen
            // 
            DlgOpen.FileName = "DlgOpen";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 311);
            Controls.Add(BtnBold);
            Controls.Add(BtnRed);
            Controls.Add(RtbNote);
            Controls.Add(BtnSave);
            Controls.Add(BtnLord);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "파일IO 윈앱";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnLord;
        private Button BtnSave;
        private RichTextBox RtbNote;
        private Button BtnRed;
        private Button BtnBold;
        private OpenFileDialog DlgOpen;
        private SaveFileDialog DlgSave;
        private ColorDialog DlgColor;
    }
}
