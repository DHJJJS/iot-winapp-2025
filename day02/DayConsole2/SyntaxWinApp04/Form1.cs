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

                string name = TxtName.Text.Trim(); // �յ� ������ ����
                // �Ľ� -> �м��ؼ� �� ��ȯ
                DateTime birthday = DateTime.Parse(TxtAge.Text.Trim());
                int age = DateTime.Now.Year - birthday.Year;
                // 3�׽� �б�
                string gender = RdoMale.Checked ? "��" : "��";

                // ���� ��� ���ڿ� ������
                TxtResult.Text = "���� " + name + "�̰�, " + birthday + "�� �¾ " + age + "�� " + gender + "���Դϴ�.";
                // �ֽ� ��� ���ڿ� ������
                TxtResult.Text = $"���� {name}�̰�, {birthday:yyyy-mm-dd}�Ͽ� �¾ {age:.2f}�� {gender}���Դϴ�!!";
            }
        }
    }
}
