namespace SyntaxWinApp03
{
    public partial class FrmMain : Form
    {
        private string filePath = "sample.rtf"; // Rich Text Format(msWord 유사)

        public FrmMain()
        {
            InitializeComponent();
        }
        private void BtnLord_Click(object sender, EventArgs e)
        {
            // string filePath = "sample.txt"; // 파일 저장
            // 3. SaveFileDialog 사용
            DlgOpen.FileName = string.Empty; // == "";
            DlgOpen.Filter = "RTF파일 (*.rtf)|*rtf|워드파일(*.docx)|*.docx";
            DlgOpen.Title = "문서파일 저장";

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
                    MessageBox.Show($"파일 저장 중 오류가 발생했습니다.\n\n오류 내용: {ex.Message}", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            // 다이얼로그창 열기(DialogResult.OK), 취소(DialogResult.Cancel)
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
                    MessageBox.Show($"읽기 실패 : {ex.Message}", "파일읽기",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }

        //    try
        //    { 
        //        if (File.Exists(filePath))
        //        {
        //            // 일반 텍스트 로드
        //            //string content = File.ReadAllText(filePath);
        //            //RtbNote.Text = content;

                //            // Rich Text Format 로드
                //            RtbNote.LoadFile(filePath, RichTextBoxStreamType.RichText);
                //        }
                //        else
                //        {
                //            MessageBox.Show("파일이 존재하지않습니다.", "파일읽기", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show($"읽기 실패 : {ex.Message}", "파일 읽기", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // string filePath = "sample.txt"; // 파일 저장
             
            try
            {
                // File 파일 관련된 메서드가 포함된 클래스
                // 일반 Txt파일 저장
                //File.WriteAllText(filePath, RtbNote.Text);

                // Rich Text Format으로 저장
                RtbNote.SaveFile(filePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("파일이 저장되었습니다.", "파일저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"저장 실패: {ex.Message}", "파일 저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 저장 버튼 클릭 시 실행할 코드
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
                newStyle = currFont.Style & ~FontStyle.Bold; // Bold 제거
            }
            else
            {
                newStyle = currFont.Style | FontStyle.Bold; // Bold 추가
            }

            RtbNote.SelectionFont = new Font(currFont, newStyle);
        }
    }
}
