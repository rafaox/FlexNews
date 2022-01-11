using Microsoft.AspNetCore.Mvc;
using FlexNews.Services.Contracts;
using FlexNews.Services.ViewModels;
using FlexNews.Api.Controllers;
using FlexNews.Api.Base;

namespace LibraryApi.Controllers
{
    [ApiController]
    public class NewsController : BaseController
    {
        private INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpPost]
        public async Task<BaseResponse<string>> Create([FromBody] RegisterNewsViewModel viewModel)
        {
            await _newsRepository.CreateNews(viewModel);
            return BaseResponse<string>.Created("Registration successful");
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<NewsViewModel>>> GetAll([FromQuery] string? filter)
        {
            IEnumerable<NewsViewModel> news = await _newsRepository.GetAllNews(filter);
            return BaseResponse<IEnumerable<NewsViewModel>>.Ok(news);
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<NewsViewModel>> GetById(string id)
        {
            NewsViewModel news = await _newsRepository.GetNewsById(id);
            return BaseResponse<NewsViewModel>.Ok(news);
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<string>> Update(string id, [FromBody] UpdateNewsViewModel viewModel)
        {
            await _newsRepository.UpdateNews(id, viewModel);
            return BaseResponse<string>.Ok("News updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> Delete(string id)
        {
            await _newsRepository.DeleteNews(id);
            return BaseResponse<string>.Ok("News deleted successfully");
        }
    }
}