using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace SyntaxWinApp02
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            // 실제로 DB에서 데이터로드 후 아래의 작업들을 수행
            // 배열 생성
            string[] fruits = { "사과", "바나나", "딸기", "망고", "블루베리" };
            CboArray.Items.AddRange(fruits); // 배열을 콤보박스에 할당
            /// CboArray.SelectedIndex = 0;

            // 리스트 생성 - 둘중 어느방법이든 사용가능
            List<string> lFruits = ["용과", "망고스틴", "애플망고", "자몽", "두리안"];
            //List<string> lFruits = new List<string>();
            //lFruits.Add("사과");
            //lFruits.Add("바나나");
            //lFruits.Add("딸기");
            //lFruits.Add("망고");
            //lFruits.Add("블루베리");
            CboList.DataSource = lFruits;

            // 딕셔너리생성 - DB 핸들링 시 가장 많이 사용되는 방식
            Dictionary<string, string> dCountry = new Dictionary<string, string>()
            {
                { "KR", "대한민국" },
                { "US", "미국" },
                { "JP", "일본" },
                { "CH", "중국" },
                { "IN", "인도" },
                { "PH", "필리핀" },
            };
            CboDictionary.DataSource = new BindingSource(dCountry, null);
            CboDictionary.DisplayMember = "Value"; // 사용자에게 보이는 이름
            CboDictionary.ValueMember = "Key";  // 내부적으로 선택되는 값

            // fpreach로 반복처리
            string result = "";
            foreach (var item in dCountry)
            {
                Console.WriteLine(item);
            }
        }
        private void CboArray_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SelectedItem은 object?
            string selected = CboArray.SelectedItem.ToString();
            MessageBox.Show($"선택한 과일은 {selected}입니다", "좋아하는과일", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = CboList.SelectedItem.ToString();
            MessageBox.Show(selected, "선택된과일", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CboDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kvp = (KeyValuePair<string, string>)CboDictionary.SelectedItem;
            string key = kvp.Key;
            string value = kvp.Value;
            MessageBox.Show($"선택한 키는 {key}, 값은 {value}", "선택된국가", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
