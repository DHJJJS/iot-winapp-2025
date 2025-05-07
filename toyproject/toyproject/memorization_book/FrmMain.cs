using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace memorization_book
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Icon = SystemIcons.Information;
            this.StartPosition = FormStartPosition.CenterScreen;

            // 단축키 등록
            this.KeyPreview = true;
            this.KeyDown += FrmMain_KeyDown;
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            // 단축키 처리
            if (e.Control && e.KeyCode == Keys.S)
            {
                BtnSave_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                BtnRead_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                BtnDelete_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Q)
            {
                BtnQuiz_Click(sender, e);
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 마지막으로 사용한 파일 경로 읽기
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "WordMemorizer");

            // 디렉토리가 없으면 생성
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            string lastFilePath = Path.Combine(appDataPath, "lastfile.txt");
            if (File.Exists(lastFilePath))
            {
                currentFilePath = File.ReadAllText(lastFilePath);
                if (File.Exists(currentFilePath))
                {
                    LoadWordsFromFile(currentFilePath);
                    this.Text = $"📘 단어 암기장 - {Path.GetFileName(currentFilePath)}";
                }
            }
        }

        private List<WordItem> allWords = new List<WordItem>();
        private string currentFilePath = "";
        private int lastSortedColumn = -1;
        private bool isAscending = true;

        private void LoadWordsFromFile(string filePath)
        {
            lvWords.Items.Clear();
            allWords.Clear();

            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    WordItem item = new WordItem(line);
                    allWords.Add(item);

                    AddWordToListView(item);
                }
            }

            // 저장 경로 기억
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "WordMemorizer");
            File.WriteAllText(Path.Combine(appDataPath, "lastfile.txt"), filePath);

            UpdateStatusLabel();
        }

        private void AddWordToListView(WordItem item)
        {
            ListViewItem lvItem = new ListViewItem(item.Word);
            lvItem.SubItems.Add(item.Meaning);
            lvItem.SubItems.Add(item.Example);

            // 정답률을 기준으로 색상 조정
            if (item.ReviewCount > 0)
            {
                if (item.CorrectRate < 50)
                {
                    lvItem.BackColor = Color.FromArgb(255, 235, 235); // 연한 빨강 (잘 외우지 못하는 단어)
                }
                else if (item.CorrectRate > 90)
                {
                    lvItem.BackColor = Color.FromArgb(235, 255, 235); // 연한 초록 (잘 외우는 단어)
                }
            }

            lvWords.Items.Add(lvItem);
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*",
                Title = "단어장 파일 열기"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = ofd.FileName;
                LoadWordsFromFile(currentFilePath);
                this.Text = $"📘 단어 암기장 - {Path.GetFileName(currentFilePath)}";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 필수 필드 검증
            if (string.IsNullOrWhiteSpace(Txtword.Text) || string.IsNullOrWhiteSpace(TxtMeaning.Text))
            {
                MessageBox.Show("단어와 뜻은 필수 입력 항목입니다.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 중복 단어 확인
            if (allWords.Any(w => w.Word.Equals(Txtword.Text, StringComparison.OrdinalIgnoreCase)))
            {
                DialogResult result = MessageBox.Show("이미 존재하는 단어입니다. 덮어쓰시겠습니까?",
                    "중복 단어", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 기존 단어 제거
                    int index = allWords.FindIndex(w =>
                        w.Word.Equals(Txtword.Text, StringComparison.OrdinalIgnoreCase));
                    if (index >= 0)
                    {
                        allWords.RemoveAt(index);
                        lvWords.Items.RemoveAt(index);
                    }
                }
                else
                {
                    return;
                }
            }

            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "텍스트 파일 (*.txt)|*.txt",
                    DefaultExt = "txt",
                    AddExtension = true,
                    Title = "단어장 저장"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = sfd.FileName;
                    this.Text = $"📘 단어 암기장 - {Path.GetFileName(currentFilePath)}";
                }
                else
                {
                    return; // 사용자가 취소한 경우
                }
            }

            // 새 단어 추가
            WordItem newWord = new WordItem(Txtword.Text, TxtMeaning.Text, TxtExample.Text);
            allWords.Add(newWord);
            AddWordToListView(newWord);

            // 파일에 저장
            SaveAllToFile();

            // 입력 필드 초기화
            Txtword.Clear();
            TxtMeaning.Clear();
            TxtExample.Clear();
            Txtword.Focus();

            UpdateStatusLabel();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvWords.SelectedItems.Count > 0)
            {
                int index = lvWords.SelectedItems[0].Index;
                string wordToDelete = lvWords.SelectedItems[0].Text;

                DialogResult result = MessageBox.Show($"'{wordToDelete}' 단어를 삭제하시겠습니까?",
                    "단어 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    lvWords.Items.RemoveAt(index);
                    allWords.RemoveAt(index);
                    SaveAllToFile();
                    UpdateStatusLabel();
                }
            }
            else
            {
                MessageBox.Show("삭제할 단어를 먼저 선택해주세요.", "선택 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveAllToFile()
        {
            using (StreamWriter sw = new StreamWriter(currentFilePath, false, Encoding.Default))
            {
                foreach (var word in allWords)
                {
                    sw.WriteLine(word.ToString());
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = TxtSearch.Text.Trim().ToLower();
            lvWords.Items.Clear();

            foreach (var word in allWords)
            {
                if (string.IsNullOrEmpty(keyword) ||
                    word.Word.ToLower().Contains(keyword) ||
                    word.Meaning.ToLower().Contains(keyword) ||
                    word.Example.ToLower().Contains(keyword))
                {
                    AddWordToListView(word);
                }
            }
        }

        private void BtnQuiz_Click(object sender, EventArgs e)
        {
            if (allWords.Count == 0)
            {
                MessageBox.Show("단어를 먼저 불러와 주세요.", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            QuizForm quizForm = new QuizForm(allWords);
            quizForm.QuizCompleted += QuizForm_QuizCompleted; // 퀴즈 결과 받기
            quizForm.ShowDialog();
        }

        private void QuizForm_QuizCompleted(object sender, QuizResultEventArgs e)
        {
            // 퀴즈 결과를 반영
            foreach (var result in e.Results)
            {
                var word = allWords.FirstOrDefault(w => w.Word == result.Word);
                if (word != null)
                {
                    word.ReviewCount += result.Attempts;
                    word.CorrectCount += result.Correct;
                }
            }

            // 파일에 저장
            SaveAllToFile();

            // 리스트뷰 갱신
            UpdateListView();
        }

        private void UpdateListView()
        {
            lvWords.Items.Clear();
            foreach (var word in allWords)
            {
                AddWordToListView(word);
            }
        }

        private void UpdateStatusLabel()
        {
            lblStatus.Text = $"총 {allWords.Count}개 단어";
        }

        private void lvWords_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // 같은 컬럼을 다시 클릭하면 정렬 방향 전환
            if (e.Column == lastSortedColumn)
            {
                isAscending = !isAscending;
            }
            else
            {
                lastSortedColumn = e.Column;
                isAscending = true;
            }

            // 정렬 수행
            if (e.Column == 0) // 단어 기준
            {
                allWords = isAscending
                    ? allWords.OrderBy(w => w.Word).ToList()
                    : allWords.OrderByDescending(w => w.Word).ToList();
            }
            else if (e.Column == 1) // 뜻 기준
            {
                allWords = isAscending
                    ? allWords.OrderBy(w => w.Meaning).ToList()
                    : allWords.OrderByDescending(w => w.Meaning).ToList();
            }

            // 리스트뷰 갱신
            UpdateListView();
        }

        private void lvWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvWords.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvWords.SelectedItems[0];
                Txtword.Text = selectedItem.SubItems[0].Text;
                TxtMeaning.Text = selectedItem.SubItems[1].Text;
                TxtExample.Text = selectedItem.SubItems[2].Text;
            }
        }

        private void BtnDarkMode_Click(object sender, EventArgs e)
        {
            // 다크모드 전환
            if (this.BackColor == Color.FromArgb(245, 245, 250)) // 라이트모드일 경우
            {
                this.BackColor = Color.FromArgb(40, 44, 52);
                this.ForeColor = Color.White;
                lvWords.BackColor = Color.FromArgb(50, 54, 62);
                lvWords.ForeColor = Color.White;
                TxtSearch.BackColor = Color.FromArgb(60, 64, 72);
                TxtSearch.ForeColor = Color.White;
                Txtword.BackColor = Color.FromArgb(60, 64, 72);
                Txtword.ForeColor = Color.White;
                TxtMeaning.BackColor = Color.FromArgb(60, 64, 72);
                TxtMeaning.ForeColor = Color.White;
                TxtExample.BackColor = Color.FromArgb(60, 64, 72);
                TxtExample.ForeColor = Color.White;
                BtnDarkMode.Text = "🌞 라이트모드";
            }
            else // 다크모드일 경우
            {
                this.BackColor = Color.FromArgb(245, 245, 250);
                this.ForeColor = Color.Black;
                lvWords.BackColor = Color.White;
                lvWords.ForeColor = Color.Black;
                TxtSearch.BackColor = Color.White;
                TxtSearch.ForeColor = Color.Black;
                Txtword.BackColor = Color.White;
                Txtword.ForeColor = Color.Black;
                TxtMeaning.BackColor = Color.White;
                TxtMeaning.ForeColor = Color.Black;
                TxtExample.BackColor = Color.White;
                TxtExample.ForeColor = Color.Black;
                BtnDarkMode.Text = "🌙 다크모드";
            }
        }
    }

    public class QuizResultEventArgs : EventArgs
    {
        public List<WordQuizResult> Results { get; set; }

        public QuizResultEventArgs(List<WordQuizResult> results)
        {
            Results = results;
        }
    }

    public class WordQuizResult
    {
        public string Word { get; set; }
        public int Attempts { get; set; }
        public int Correct { get; set; }

        public WordQuizResult(string word, int attempts, int correct)
        {
            Word = word;
            Attempts = attempts;
            Correct = correct;
        }
    }
}