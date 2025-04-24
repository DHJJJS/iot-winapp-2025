namespace SyntaxWinApp01
{
    public partial class FrmMain : Form
    {
        // 대리자(delegate) 선언
        delegate void MyDelegate(string msg);
        // 이벤트핸들러 대리자 선언
        delegate void MyEventHandler(object sender, EventArgs e);
        // 이벤트 선언
        public event EventHandler SomethingHappened;

        // 대리자에서 호출할 메서드 - 대리자와 파라미터가 일치

        void SayHello(String msg)
        {
            MessageBox.Show($"안녕, {msg}", "메시지", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void SayGoodbye(String msg)
        {
            MessageBox.Show($"내일 봐~, {msg}", "메시지", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public FrmMain()
        {
            InitializeComponent();
            TxtLog.Text += ("1. 폼 생성자 실행\r\n");
        }

        public void FrmMain_Load(object sender, EventArgs e)
        {
            TxtLog.Text +=("2. 폼 로드 이벤트 실행\r\n");
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            TxtLog.Text +=("4. 폼숀 이벤트 실행\r\n");
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            TxtLog.Text +=("3. 폼 액티베이트 이벤트 실행\r\n");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            TxtLog.Text +=("5. 폼 클로징 이벤트 실행\r\n");
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            TxtLog.Text +=("6. 폼 클로즈드 이벤트 실행\r\n");
        }

        public void BtnCheck_Click(object sender, EventArgs e)
        {
            // 1. 직접 호출
            SayHello("Hugo");
            SayGoodbye("Hugo");

            // 2. 대리자(delegate) 호출 (윈앱 개발 핵심!!)
            MyDelegate del = SayHello; // 대리자에 호출할 메서드를 묶어줌
            del += SayGoodbye;  // 추가도 가능 (대리자 체인 추가)
            del("Ashely"); // (대리자 체인 삭제)

            // 3. 반환값 없는 대리자 - Action (보기만 하세요)
            Action<string> act = SayHello;
            act("Chris");

            // 4. 반환값 있는 대리자 - Func (보기만 하세요)
            Func<int, int, int> add = (a, b) => a + b;
            int result = add(7, 8);
            Console.Write(result);

            if (SomethingHappened != null)
            {
                SomethingHappened(this, new EventArgs());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
