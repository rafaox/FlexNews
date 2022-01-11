using FlexNews.DataAccessLayer.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlexNews.DataAccessLayer.Models
{
    public class News : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string Author { get; private set; }

        public News(string title, string text, string author)
        {
            Title = title;
            Text = text;
            Author = author;
        }

        public News(string id, string title, string text, string author)
        {
            Id = id;
            Title = title;
            Text = text;
            Author = author;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetText(string text)
        {
            Text = text;
        }

        public void SetAuthor(string author)
        {
            Author = author;
        }
    }
}