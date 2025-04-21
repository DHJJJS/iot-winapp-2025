using Microsoft.VisualBasic;

namespace SyntaxWinApp01
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
            MessageBox.Show("메시지", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            // 자료형
            sbyte byteVal = 127; // signed byte : -128 ~ 127 수 저장
            System.SByte sbtVal2 = System.SByte.MinValue; // -128 할당
            byte btVal = 255; // byte : 0 ~ 255 수 저장
            System.Byte btVal2 = System.Byte.MaxValue; // 0 할당
            short stVal = 32767; // short : -32768 ~ 32767 수 저장
            System.Int16 stVal2 = System.Byte.MinValue; 
            ushort ustVal = 65535; // unsigned short : 0 ~ 65535 저장 (2 bytes 크기)
            System.UInt16 ustVal2 = System.UInt16.MaxValue; 
            int intValu = 2147483647; // int : - 21억 ~ 21억 (4 bytes 크기)
            System.Int32 intVal2 = System.Int32.MinValue;
            uint uintVal = 4294967295; // unsigned int : 0 ~ 42억 (4 bytes 크기)
            System.UInt32 uintVal2 = System.UInt32.MaxValue;    
            long lngVal = 9000000000000000000; // long : -92경 ~ 92경
            ulong ulngVal = 18000000000000000000; // unsigned long : 1800경(8 bytes 크기)
            System.Int64 longVal02; // (8bytes)
            System.Int128 bigLongVal03; // (16bytes)

            // 실수 자료형
            float fVal = 3.141592f; // float : 4byte 소수점
            System.Single fVal2 = System.Single.MinValue;
            double dVal = 3.141592; // double : 8bytes 소수점
            System.Double dVal2;
            decimal dcVal = 3.141592m; // decimal : 16bytes 소수점
            System.Decimal dcVal2;

            // 문자형 타입
            char ch01 = 'A';
            System.Char ch03 = 'B';
            Console.WriteLine(ch01);
            char ch02 = '\u25b6';
            Console.WriteLine(ch02);

            string str01 = "Hello \n World!"; // \0 : end of line
            System.String str02 = "Hello C#";

            // 불린 타입
            bool bool01 = true;
            System.Boolean bool02 = false;

            // Nullable
            // int int02 = null;   // 기본 타입(정수형, 실수형, 불린 / 문자열제외)은 NULL 할당불가
            int? int03 = null;  // 기본 타입 뒤에 ? 붙여줄

            // 상수 타입
            const int int04 = 15; // const를 만나면 상수. 한 번 할당 후 변경 불가
            // int04 = 26;

            // 동적 타입 // 컴파일 되면서 해당 타입으로 형결정
            var int05 = false;

            //int05 = "string";


            //MessageBox.Show(intVal2.ToString(), "Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show(str01, "Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
