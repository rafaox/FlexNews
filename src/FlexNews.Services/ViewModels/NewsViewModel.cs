using System.Text.Json.Serialization;

namespace FlexNews.Services.ViewModels
{
    public class NewsViewModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }
    }
}