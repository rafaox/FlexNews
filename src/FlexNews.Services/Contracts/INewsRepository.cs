using FlexNews.Services.ViewModels;

namespace FlexNews.Services.Contracts
{
    public interface INewsRepository
    {
        Task<IEnumerable<NewsViewModel>> GetAllNews(string? filter);
        Task<NewsViewModel> GetNewsById(string id);
        Task CreateNews(RegisterNewsViewModel viewModel);
        Task UpdateNews(string id, UpdateNewsViewModel viewModel);
        Task DeleteNews(string id);
    }
}