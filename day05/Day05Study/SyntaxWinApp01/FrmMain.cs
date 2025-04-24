namespace SyntaxWinApp01
{
    public partial class FrmMain : Form
    {
        // �븮��(delegate) ����
        delegate void MyDelegate(string msg);
        // �̺�Ʈ�ڵ鷯 �븮�� ����
        delegate void MyEventHandler(object sender, EventArgs e);
        // �̺�Ʈ ����
        public event EventHandler SomethingHappened;

        // �븮�ڿ��� ȣ���� �޼��� - �븮�ڿ� �Ķ���Ͱ� ��ġ

        void SayHello(String msg)
        {
            MessageBox.Show($"�ȳ�, {msg}", "�޽���", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void SayGoodbye(String msg)
        {
            MessageBox.Show($"���� ��~, {msg}", "�޽���", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public FrmMain()
        {
            InitializeComponent();
            TxtLog.Text += ("1. �� ������ ����\r\n");
        }

        public void FrmMain_Load(object sender, EventArgs e)
        {
            TxtLog.Text +=("2. �� �ε� �̺�Ʈ ����\r\n");
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            TxtLog.Text +=("4. ���� �̺�Ʈ ����\r\n");
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            TxtLog.Text +=("3. �� ��Ƽ����Ʈ �̺�Ʈ ����\r\n");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            TxtLog.Text +=("5. �� Ŭ��¡ �̺�Ʈ ����\r\n");
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            TxtLog.Text +=("6. �� Ŭ����� �̺�Ʈ ����\r\n");
        }

        public void BtnCheck_Click(object sender, EventArgs e)
        {
            // 1. ���� ȣ��
            SayHello("Hugo");
            SayGoodbye("Hugo");

            // 2. �븮��(delegate) ȣ�� (���� ���� �ٽ�!!)
            MyDelegate del = SayHello; // �븮�ڿ� ȣ���� �޼��带 ������
            del += SayGoodbye;  // �߰��� ���� (�븮�� ü�� �߰�)
            del("Ashely"); // (�븮�� ü�� ����)

            // 3. ��ȯ�� ���� �븮�� - Action (���⸸ �ϼ���)
            Action<string> act = SayHello;
            act("Chris");

            // 4. ��ȯ�� �ִ� �븮�� - Func (���⸸ �ϼ���)
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
