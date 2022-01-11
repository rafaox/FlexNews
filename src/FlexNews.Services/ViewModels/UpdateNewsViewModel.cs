using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlexNews.Services.ViewModels
{
    public class UpdateNewsViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Text is required.")]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [JsonPropertyName("author")]
        public string Author { get; set; }
    }
}