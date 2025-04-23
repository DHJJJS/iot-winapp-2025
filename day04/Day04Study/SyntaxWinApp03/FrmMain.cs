namespace SyntaxWinApp03
{
    public partial class FrmMain : Form
    {
        private string filePath = "sample.rtf"; // Rich Text Format(msWord ����)

        public FrmMain()
        {
            InitializeComponent();
        }
        private void BtnLord_Click(object sender, EventArgs e)
        {
            // string filePath = "sample.txt"; // ���� ����
            // 3. SaveFileDialog ���
            DlgOpen.FileName = string.Empty; // == "";
            DlgOpen.Filter = "RTF���� (*.rtf)|*rtf|��������(*.docx)|*.docx";
            DlgOpen.Title = "�������� ����";

            if (DlgSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fullPath = DlgSave.FileName;
                    string ext = Path.GetExtension(fullPath); // .rtf, .txt

                    if (ext == ".rtf")
                        RtbNote.SaveFile(fullPath, RichTextBoxStreamType.RichText);
                    else if (ext == ".txt")
                        RtbNote.SaveFile(fullPath, RichTextBoxStreamType.PlainText);

                    RtbNote.SaveFile(fullPath, RichTextBoxStreamType.RichText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"���� ���� �� ������ �߻��߽��ϴ�.\n\n���� ����: {ex.Message}", "���� ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            // ���̾�α�â ����(DialogResult.OK), ���(DialogResult.Cancel)
            if (DlgOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fullPath = DlgOpen.FileName;
                    string ext = Path.GetExtension(fullPath); // .rtf, .txt

                    if (ext == ".rtf")
                        RtbNote.LoadFile(DlgOpen.FileName, RichTextBoxStreamType.RichText);
                    else if (ext == ".txt")
                        RtbNote.LoadFile(DlgOpen.FileName, RichTextBoxStreamType.PlainText);

                    RtbNote.LoadFile(DlgOpen.FileName, RichTextBoxStreamType.RichText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"�б� ���� : {ex.Message}", "�����б�",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }

        //    try
        //    { 
        //        if (File.Exists(filePath))
        //        {
        //            // �Ϲ� �ؽ�Ʈ �ε�
        //            //string content = File.ReadAllText(filePath);
        //            //RtbNote.Text = content;

                //            // Rich Text Format �ε�
                //            RtbNote.LoadFile(filePath, RichTextBoxStreamType.RichText);
                //        }
                //        else
                //        {
                //            MessageBox.Show("������ ���������ʽ��ϴ�.", "�����б�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show($"�б� ���� : {ex.Message}", "���� �б�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // string filePath = "sample.txt"; // ���� ����
             
            try
            {
                // File ���� ���õ� �޼��尡 ���Ե� Ŭ����
                // �Ϲ� Txt���� ����
                //File.WriteAllText(filePath, RtbNote.Text);

                // Rich Text Format���� ����
                RtbNote.SaveFile(filePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("������ ����Ǿ����ϴ�.", "��������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"���� ����: {ex.Message}", "���� ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // ���� ��ư Ŭ�� �� ������ �ڵ�
        }

        private void BtnRed_Click(object sender, EventArgs e)
        {
            //RtbNote.SelectionColor = Color.Red;
            if (RtbNote.SelectionLength > 0)
            {
                if (DlgColor.ShowDialog() == DialogResult.OK)
                {
                    RtbNote.SelectionColor = DlgColor.Color;
                }
            }
        }
        private void BtnBold_Click(object sender, EventArgs e)
        {
            Font currFont = RtbNote.SelectionFont;
            FontStyle newStyle;

            if (currFont.Bold)
            {
                newStyle = currFont.Style & ~FontStyle.Bold; // Bold ����
            }
            else
            {
                newStyle = currFont.Style | FontStyle.Bold; // Bold �߰�
            }

            RtbNote.SelectionFont = new Font(currFont, newStyle);
        }
    }
}
