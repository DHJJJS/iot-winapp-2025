namespace SyntaxWinApp04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnMsg_Click(object sender, EventArgs e)
        {
            if (TxtName.Text == "" || TxtAge.Text == "")
            {
                MessageBox.Show("���� ä���ּ���.");
                return; // �޼��� Ż��
            } else
            {
                // ���� ������ ������ ����...
                LblResult.Text = "ó����� : ";
                TxtResult.Text = "���� ó���� ����";
            }
        }
    }
}
