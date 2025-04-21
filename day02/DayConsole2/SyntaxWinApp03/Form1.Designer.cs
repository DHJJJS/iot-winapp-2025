namespace SyntaxWinApp03
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            TxtPain = new TextBox();
            label2 = new Label();
            CboPainPoint = new ComboBox();
            TxtResult = new TextBox();
            BtnDisplay = new Button();
            BtnWhile = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(688, 393);
            button1.Name = "button1";
            button1.Size = new Size(100, 45);
            button1.TabIndex = 4;
            button1.Text = "메시지";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 7;
            label1.Text = "통증여부 -";
            // 
            // TxtPain
            // 
            TxtPain.BackColor = SystemColors.Window;
            TxtPain.Location = new Point(82, 6);
            TxtPain.Name = "TxtPain";
            TxtPain.PlaceholderText = "네 또는 아니오";
            TxtPain.Size = new Size(100, 23);
            TxtPain.TabIndex = 1;
            TxtPain.KeyPress += TxtPain_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 39);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 8;
            label2.Text = "통증부위 -";
            // 
            // CboPainPoint
            // 
            CboPainPoint.FormattingEnabled = true;
            CboPainPoint.Items.AddRange(new object[] { "머리", "눈", "코", "목", "가슴", "배" });
            CboPainPoint.Location = new Point(82, 36);
            CboPainPoint.Name = "CboPainPoint";
            CboPainPoint.Size = new Size(121, 23);
            CboPainPoint.TabIndex = 2;
            CboPainPoint.Text = "부위선택";
            CboPainPoint.SelectedIndexChanged += CboPainPoint_SelectedIndexChanged;
            // 
            // TxtResult
            // 
            TxtResult.Location = new Point(7, 66);
            TxtResult.Multiline = true;
            TxtResult.Name = "TxtResult";
            TxtResult.Size = new Size(787, 310);
            TxtResult.TabIndex = 3;
            // 
            // BtnDisplay
            // 
            BtnDisplay.Location = new Point(582, 393);
            BtnDisplay.Name = "BtnDisplay";
            BtnDisplay.Size = new Size(100, 45);
            BtnDisplay.TabIndex = 5;
            BtnDisplay.Text = "구구단";
            BtnDisplay.UseVisualStyleBackColor = true;
            BtnDisplay.Click += BtnDisplay_Click;
            // 
            // BtnWhile
            // 
            BtnWhile.Location = new Point(476, 393);
            BtnWhile.Name = "BtnWhile";
            BtnWhile.Size = new Size(100, 45);
            BtnWhile.TabIndex = 6;
            BtnWhile.Text = "반복";
            BtnWhile.UseVisualStyleBackColor = true;
            BtnWhile.Click += BtnWhile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnWhile);
            Controls.Add(BtnDisplay);
            Controls.Add(TxtResult);
            Controls.Add(CboPainPoint);
            Controls.Add(label2);
            Controls.Add(TxtPain);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "문법학습 윈앱03";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox TxtPain;
        private Label label2;
        private ComboBox CboPainPoint;
        private TextBox TxtResult;
        private Button BtnDisplay;
        private Button BtnWhile;
    }
}
