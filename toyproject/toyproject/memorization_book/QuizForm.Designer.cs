using System;
using System.Drawing;
using System.Windows.Forms;

namespace memorization_book
{
    partial class QuizForm
    {
        private void InitializeComponent()
        {
            this.Text = "🎯 퀴즈 모드";
            this.BackColor = Color.FromArgb(245, 245, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ClientSize = new Size(500, 330);
            this.Font = new Font("맑은 고딕", 10);
            this.KeyPreview = true;
            this.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    btnCheck_Click(s, e);
                    e.SuppressKeyPress = true;
                }
            };

            // 퀴즈 모드 그룹박스
            grpMode = new GroupBox()
            {
                Text = "퀴즈 모드",
                Location = new Point(30, 15),
                Size = new Size(440, 60),
                Font = new Font("맑은 고딕", 9)
            };

            rdoWordToMeaning = new RadioButton()
            {
                Text = "단어 → 뜻",
                Location = new Point(50, 25),
                Checked = true,
                AutoSize = true
            };

            rdoMeaningToWord = new RadioButton()
            {
                Text = "뜻 → 단어",
                Location = new Point(280, 25),
                Checked = false,
                AutoSize = true
            };

            rdoWordToMeaning.CheckedChanged += (s, e) => {
                if (rdoWordToMeaning.Checked)
                {
                    isWordToMeaning = true;
                    LoadNextQuestion();
                }
            };

            rdoMeaningToWord.CheckedChanged += (s, e) => {
                if (rdoMeaningToWord.Checked)
                {
                    isWordToMeaning = false;
                    LoadNextQuestion();
                }
            };

            grpMode.Controls.Add(rdoWordToMeaning);
            grpMode.Controls.Add(rdoMeaningToWord);

            // 문제 라벨
            lblQuestion = new Label()
            {
                Location = new Point(30, 85),
                Size = new Size(440, 40),
                Font = new Font("맑은 고딕", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "문제가 여기에 표시됩니다.",
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // 입력 박스
            txtAnswer = new TextBox()
            {
                Location = new Point(30, 135),
                Size = new Size(440, 30),
                Font = new Font("맑은 고딕", 11),
                TextAlign = HorizontalAlignment.Center
            };

            // 정답 확인 버튼
            btnCheck = new Button()
            {
                Text = "정답 확인 ✓",
                Location = new Point(190, 175),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("맑은 고딕", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            btnCheck.Click += btnCheck_Click;

            // 예문 보기 체크박스
            chkShowExample = new CheckBox()
            {
                Text = "예문 보기",
                Location = new Point(30, 175),
                AutoSize = true,
                Font = new Font("맑은 고딕", 9)
            };

            chkShowExample.CheckedChanged += (s, e) => {
                if (chkShowExample.Checked && !string.IsNullOrEmpty(currentExample))
                {
                    lblExample.Visible = true;
                    lblExample.Text = $"예문: {currentExample}";
                }
                else
                {
                    lblExample.Visible = false;
                }
            };

            // 피드백 라벨
            lblFeedback = new Label()
            {
                Location = new Point(30, 220),
                Size = new Size(440, 30),
                Font = new Font("맑은 고딕", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = ""
            };

            // 예문 라벨
            lblExample = new Label()
            {
                Location = new Point(30, 255),
                Size = new Size(440, 30),
                Font = new Font("맑은 고딕", 9, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "",
                Visible = false
            };

            // 통계 라벨
            lblStats = new Label()
            {
                Location = new Point(30, 290),
                Size = new Size(440, 30),
                Font = new Font("맑은 고딕", 9),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "정답률: 0% (0/0)"
            };

            Controls.Add(grpMode);
            Controls.Add(lblQuestion);
            Controls.Add(txtAnswer);
            Controls.Add(btnCheck);
            Controls.Add(chkShowExample);
            Controls.Add(lblFeedback);
            Controls.Add(lblExample);
            Controls.Add(lblStats);
        }

        private GroupBox grpMode;
        private RadioButton rdoWordToMeaning;
        private RadioButton rdoMeaningToWord;
        private Label lblQuestion;
        private TextBox txtAnswer;
        private Button btnCheck;
        private CheckBox chkShowExample;
        private Label lblFeedback;
        private Label lblExample;
        private Label lblStats;
    }
}