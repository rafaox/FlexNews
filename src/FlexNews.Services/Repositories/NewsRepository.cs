using FlexNews.DataAccessLayer.Models;
using FlexNews.DataAccessLayer.MongoDbContext;
using FlexNews.Services.Contracts;
using FlexNews.Services.Errors;
using FlexNews.Services.ViewModels;
using MongoDB.Driver;

namespace FlexNews.Services.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly MongoDbContext _mongo;
        private readonly IMongoCollection<News> _news;

        public NewsRepository(MongoDbContext mongo)
        {
            _mongo = mongo;
            _news = mongo.GetCollection<News>("News");
        }

        public async Task CreateNews(RegisterNewsViewModel viewModel)
        {
            var news = new News(
                viewModel.Title,
                viewModel.Text,
                viewModel.Author
            );

            await _news.InsertOneAsync(news);
        }

        public async Task DeleteNews(string id)
        {
            var news = await _news.Find<News>(_ => _.Id == id).FirstOrDefaultAsync();

            if (news == null)
                throw new AppException("News not found");

            await _news.DeleteOneAsync(_ => _.Id == id);
        }

        public async Task<IEnumerable<NewsViewModel>> GetAllNews(string? filter)
        {
            var news = string.IsNullOrWhiteSpace(filter)
                ? await _news.Find(_ => true).ToListAsync()
                : await _news.Find(_ => _.Title.ToLower().Contains(filter) || _.Text.ToLower().Contains(filter) || _.Author.ToLower().Contains(filter)).ToListAsync();

            var newsViewModels = news is null
                ? Enumerable.Empty<NewsViewModel>()
                : (from n in news
                   select new NewsViewModel
                   {
                       Id = n.Id,
                       Title = n.Title,
                       Text = n.Text,
                       Author = n.Author
                   }).AsEnumerable();

            return newsViewModels;
        }

        public async Task<NewsViewModel> GetNewsById(string id)
        {
            var news = await _news.Find<News>(_ => _.Id == id).FirstOrDefaultAsync();

            if (news is null)
                throw new AppException("News not found");

            return new NewsViewModel
            {
                Id = news.Id,
                Title = news.Title,
                Text = news.Text,
                Author = news.Author
            };
        }

        public async Task UpdateNews(string id, UpdateNewsViewModel viewModel)
        {
            var news = await _news.Find<News>(_ => _.Id == id).FirstOrDefaultAsync();

            if (news is null)
                throw new AppException("News not found");

            if (!string.IsNullOrWhiteSpace(viewModel.Title))
                news.SetTitle(viewModel.Title);

            if (!string.IsNullOrWhiteSpace(viewModel.Text))
                news.SetText(viewModel.Text);

            if (!string.IsNullOrWhiteSpace(viewModel.Author))
                news.SetAuthor(viewModel.Author);

            await _news.ReplaceOneAsync(_ => _.Id == id, news);
        }
    }
}