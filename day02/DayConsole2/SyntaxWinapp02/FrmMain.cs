namespace SyntaxWinapp02
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        private void BtnMsg_Click(object sender, EventArgs e)
        {
            // ������ : =, +,-, *, /, %, ^, +=, -=, *=
            // &&, ||, &, |, ^, !
            // C, C++�� ����
            int val = 2 ^ 10;

            int result = 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;

            MessageBox.Show(val.ToString(), "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
