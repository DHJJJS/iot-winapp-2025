using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memorization_book
{
    public partial class QuizForm : Form
    {
        private List<WordItem> wordList;
        private List<WordQuizResult> quizResults = new List<WordQuizResult>();
        private Dictionary<string, WordQuizResult> sessionResults = new Dictionary<string, WordQuizResult>();

        private string currentWord;
        private string currentMeaning;
        private string currentExample;
        private Random random = new Random();
        private int totalQuestions = 0;
        private int correctAnswers = 0;
        private bool isWordToMeaning = true; // 퀴즈 방향 (단어→뜻 또는 뜻→단어)

        public event EventHandler<QuizResultEventArgs> QuizCompleted;

        public QuizForm(List<WordItem> allWords)
        {
            InitializeComponent();
            wordList = allWords;
            LoadNextQuestion();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // 퀴즈 결과 전달
            if (totalQuestions > 0)
            {
                QuizCompleted?.Invoke(this, new QuizResultEventArgs(sessionResults.Values.ToList()));
            }
        }

        private void LoadNextQuestion()
        {
            if (wordList.Count == 0)
            {
                MessageBox.Show("단어 목록이 비어 있습니다.", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            int index = random.Next(wordList.Count);
            currentWord = wordList[index].Word;
            currentMeaning = wordList[index].Meaning;
            currentExample = wordList[index].Example;

            if (isWordToMeaning)
            {
                lblQuestion.Text = $"이 단어의 뜻은? 👉 {currentWord}";
            }
            else
            {
                lblQuestion.Text = $"이 뜻에 맞는 단어는? 👉 {currentMeaning}";
            }

            txtAnswer.Text = "";
            lblFeedback.Text = "";
            lblExample.Visible = false;
            txtAnswer.Focus();

            // 예문 보기 체크박스 상태에 따라 예문 표시
            if (chkShowExample.Checked && !string.IsNullOrEmpty(currentExample))
            {
                lblExample.Visible = true;
                lblExample.Text = $"예문: {currentExample}";
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                MessageBox.Show("답을 입력해주세요.", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string userAnswer = txtAnswer.Text.Trim();
            string correctAnswer = isWordToMeaning ? currentMeaning : currentWord;
            bool isCorrect = userAnswer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase);

            totalQuestions++;

            // 단어별 결과 추적
            if (!sessionResults.ContainsKey(currentWord))
            {
                sessionResults[currentWord] = new WordQuizResult(currentWord, 0, 0);
            }
            sessionResults[currentWord].Attempts++;

            if (isCorrect)
            {
                lblFeedback.ForeColor = Color.SeaGreen;
                lblFeedback.Text = "✅ 정답입니다!";
                correctAnswers++;
                sessionResults[currentWord].Correct++;
            }
            else
            {
                lblFeedback.ForeColor = Color.Firebrick;
                lblFeedback.Text = $"❌ 오답입니다. 정답: {correctAnswer}";
            }

            // 통계 업데이트
            double accuracy = totalQuestions > 0 ? (double)correctAnswers / totalQuestions * 100 : 0;
            lblStats.Text = $"정답률: {accuracy:F1}% ({correctAnswers}/{totalQuestions})";

            // 1.5초 후 다음 문제 로드
            btnCheck.Enabled = false;
            Task.Delay(1500).ContinueWith(_ =>
            {
                this.Invoke((Action)(() =>
                {
                    LoadNextQuestion();
                    btnCheck.Enabled = true;
                }));
            });
        }
    }
}