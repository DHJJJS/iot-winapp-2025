using System;

namespace memorization_book
{
    public class WordItem
    {
        public string Word { get; set; }
        public string Meaning { get; set; }
        public string Example { get; set; }
        public DateTime AddedDate { get; set; }
        public int ReviewCount { get; set; }
        public int CorrectCount { get; set; }

        public WordItem(string word, string meaning, string example)
        {
            Word = word;
            Meaning = meaning;
            Example = example;
            AddedDate = DateTime.Now;
            ReviewCount = 0;
            CorrectCount = 0;
        }

        public WordItem(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 3)
            {
                Word = parts[0];
                Meaning = parts[1];
                Example = parts[2];

                // 추가 정보가 있으면 로드
                AddedDate = parts.Length > 3 && DateTime.TryParse(parts[3], out DateTime date)
                    ? date : DateTime.Now;
                ReviewCount = parts.Length > 4 && int.TryParse(parts[4], out int reviews)
                    ? reviews : 0;
                CorrectCount = parts.Length > 5 && int.TryParse(parts[5], out int correct)
                    ? correct : 0;
            }
        }

        public override string ToString()
        {
            return $"{Word}|{Meaning}|{Example}|{AddedDate}|{ReviewCount}|{CorrectCount}";
        }

        public double CorrectRate => ReviewCount > 0 ? (double)CorrectCount / ReviewCount * 100 : 0;
    }
}