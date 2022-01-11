using Microsoft.AspNetCore.Mvc;

namespace FlexNews.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiversion}/[controller]")]
    public class BaseController : Controller
    { }
}