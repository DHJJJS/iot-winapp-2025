using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MusicApp
{
    internal class Program
    {
        private static readonly string apiKey = "AIzaSyCYHrK7lqVCdUFWf3M4n9ZIA4hBlkGm9eY";  // 구글 API에서 발급받은 API 키를 여기에 입력하세요
        private static readonly string baseUrl = "https://www.googleapis.com/youtube/v3/search";

        static async Task Main(string[] args)
        {
            Console.WriteLine("검색할 키워드를 입력하세요: ");
            string query = Console.ReadLine();  // 사용자로부터 검색 키워드 입력 받기

            try
            {
                await SearchYouTube(query);  // 유튜브 API 검색 호출
            }
            catch (Exception ex)
            {
                Console.WriteLine("API 호출 중 오류가 발생했습니다: " + ex.Message);
            }
        }

        public static async Task SearchYouTube(string query)
        {
            using (var client = new HttpClient())
            {
                var url = $"{baseUrl}?part=snippet&q={query}&key={apiKey}";
                var response = await client.GetStringAsync(url);  // 응답을 문자열로 받기

                var data = JsonConvert.DeserializeObject<YouTubeResponse>(response);

                if (data?.Items == null || data.Items.Length == 0)
                {
                    Console.WriteLine("검색된 동영상이 없습니다.");
                    return;
                }

                foreach (var item in data.Items)
                {
                    Console.WriteLine($"제목: {item.Snippet.Title}");
                    Console.WriteLine($"URL: https://www.youtube.com/watch?v={item.Id.VideoId}");
                    Console.WriteLine("-----");
                }
            }
        }

        public class YouTubeResponse
        {
            public Item[] Items { get; set; }
        }

        public class Item
        {
            public Snippet Snippet { get; set; }
            public Id Id { get; set; }
        }

        public class Snippet
        {
            public string Title { get; set; }
        }

        public class Id
        {
            public string VideoId { get; set; }
        }
    }
}
