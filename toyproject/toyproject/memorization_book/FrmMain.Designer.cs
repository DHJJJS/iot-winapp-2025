namespace memorization_book
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.Font = new System.Drawing.Font("맑은 고딕", 10);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 250); // 연한 회색 배경
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.Text = "📘 단어 암기장";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 라벨 스타일 함수
            System.Windows.Forms.Label MakeLabel(string text, int x, int y) => new System.Windows.Forms.Label()
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                AutoSize = true,
                Font = new System.Drawing.Font("맑은 고딕", 10, System.Drawing.FontStyle.Bold)
            };

            // 텍스트박스 스타일 함수
            System.Windows.Forms.TextBox MakeTextBox(int x, int y) => new System.Windows.Forms.TextBox()
            {
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(600, 25),
                Font = new System.Drawing.Font("맑은 고딕", 10),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };

            // 버튼 스타일 함수
            System.Windows.Forms.Button MakeButton(string text, int x, int y, System.Drawing.Color color) => new System.Windows.Forms.Button()
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(100, 30),
                BackColor = color,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new System.Drawing.Font("맑은 고딕", 9, System.Drawing.FontStyle.Bold),
                Cursor = System.Windows.Forms.Cursors.Hand
            };

            // 컨트롤 생성
            System.Windows.Forms.Label labelWord = MakeLabel("단어:", 20, 20);
            Txtword = MakeTextBox(80, 18);

            System.Windows.Forms.Label labelMeaning = MakeLabel("뜻:", 20, 55);
            TxtMeaning = MakeTextBox(80, 53);

            System.Windows.Forms.Label labelExample = MakeLabel("예문:", 20, 90);
            TxtExample = MakeTextBox(80, 88);

            BtnSave = MakeButton("💾 저장", 700, 18, System.Drawing.Color.FromArgb(52, 152, 219));
            BtnRead = MakeButton("📂 열기", 700, 53, System.Drawing.Color.FromArgb(46, 204, 113));
            BtnDelete = MakeButton("🗑️ 삭제", 700, 88, System.Drawing.Color.FromArgb(231, 76, 60));
            BtnQuiz = MakeButton("🎯 퀴즈", 810, 18, System.Drawing.Color.FromArgb(241, 196, 15));
            BtnDarkMode = MakeButton("🌙 다크모드", 810, 53, System.Drawing.Color.FromArgb(75, 101, 132));
            BtnExport = MakeButton("📊 통계", 810, 88, System.Drawing.Color.FromArgb(142, 68, 173));

            System.Windows.Forms.Label labelShortcuts = new System.Windows.Forms.Label()
            {
                Text = "단축키: Ctrl+S(저장), Ctrl+O(열기), Ctrl+D(삭제), Ctrl+Q(퀴즈)",
                Location = new System.Drawing.Point(20, 125),
                Size = new System.Drawing.Size(400, 20),
                Font = new System.Drawing.Font("맑은 고딕", 8),
                ForeColor = System.Drawing.Color.DarkGray
            };

            TxtSearch = new System.Windows.Forms.TextBox()
            {
                Location = new System.Drawing.Point(20, 150),
                Size = new System.Drawing.Size(880, 28),
                Font = new System.Drawing.Font("맑은 고딕", 10),
                PlaceholderText = "🔍 단어, 뜻 또는 예문을 검색하세요...",
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };

            lvWords = new System.Windows.Forms.ListView()
            {
                Location = new System.Drawing.Point(20, 190),
                Size = new System.Drawing.Size(880, 330),
                View = System.Windows.Forms.View.Details,
                GridLines = true,
                FullRowSelect = true,
                Font = new System.Drawing.Font("맑은 고딕", 10),
                BackColor = System.Drawing.Color.White,
                HideSelection = false,
                MultiSelect = false
            };

            단어 = new System.Windows.Forms.ColumnHeader() { Text = "단어", Width = 150 };
            뜻 = new System.Windows.Forms.ColumnHeader() { Text = "뜻", Width = 300 };
            예문 = new System.Windows.Forms.ColumnHeader() { Text = "예문", Width = 400 };
            lvWords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { 단어, 뜻, 예문 });

            // 상태 표시줄
            lblStatus = new System.Windows.Forms.Label()
            {
                Text = "총 0개 단어",
                Location = new System.Drawing.Point(20, 525),
                Size = new System.Drawing.Size(880, 20),
                Font = new System.Drawing.Font("맑은 고딕", 9),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            };

            // 이벤트 연결
            BtnSave.Click += BtnSave_Click;
            BtnRead.Click += BtnRead_Click;
            BtnDelete.Click += BtnDelete_Click;
            BtnQuiz.Click += BtnQuiz_Click;
            BtnDarkMode.Click += BtnDarkMode_Click;
            BtnExport.Click += (s, e) => System.Windows.Forms.MessageBox.Show("단어 학습 통계 기능은 곧 추가될 예정입니다.", "알림");
            TxtSearch.TextChanged += TxtSearch_TextChanged;
            lvWords.ColumnClick += lvWords_ColumnClick;
            lvWords.SelectedIndexChanged += lvWords_SelectedIndexChanged;

            // 툴팁 추가
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(BtnSave, "단어를 저장합니다 (Ctrl+S)");
            toolTip.SetToolTip(BtnRead, "단어장 파일을 불러옵니다 (Ctrl+O)");
            toolTip.SetToolTip(BtnDelete, "선택한 단어를 삭제합니다 (Ctrl+D)");
            toolTip.SetToolTip(BtnQuiz, "퀴즈 모드를 시작합니다 (Ctrl+Q)");
            toolTip.SetToolTip(BtnDarkMode, "다크모드/라이트모드를 전환합니다");
            toolTip.SetToolTip(BtnExport, "단어 학습 통계를 확인합니다");

            // 컨트롤 추가
            Controls.Add(labelWord);
            Controls.Add(Txtword);
            Controls.Add(labelMeaning);
            Controls.Add(TxtMeaning);
            Controls.Add(labelExample);
            Controls.Add(TxtExample);
            Controls.Add(BtnSave);
            Controls.Add(BtnRead);
            Controls.Add(BtnDelete);
            Controls.Add(BtnQuiz);
            Controls.Add(BtnDarkMode);
            Controls.Add(BtnExport);
            Controls.Add(labelShortcuts);
            Controls.Add(TxtSearch);
            Controls.Add(lvWords);
            Controls.Add(lblStatus);
        }

        #endregion

        private System.Windows.Forms.TextBox Txtword;
        private System.Windows.Forms.TextBox TxtMeaning;
        private System.Windows.Forms.TextBox TxtExample;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnQuiz;
        private System.Windows.Forms.Button BtnDarkMode;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.ListView lvWords;
        private System.Windows.Forms.ColumnHeader 단어;
        private System.Windows.Forms.ColumnHeader 뜻;
        private System.Windows.Forms.ColumnHeader 예문;
        private System.Windows.Forms.Label lblStatus;
    }
}