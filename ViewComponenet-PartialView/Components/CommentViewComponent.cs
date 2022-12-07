using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ViewComponenet_PartialView.Models;

namespace ViewComponenet_PartialView.Components
{
    public class CommentViewComponent : ViewComponent
    {
        Uri baseAddress;
        IConfiguration _configuration;
        HttpClient client;

        public CommentViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
            baseAddress = new Uri(_configuration["ApiAddress"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public IViewComponentResult Invoke(int postId)
        {
            IEnumerable<CommentViewModel> comments = new List<CommentViewModel>();
            var res = client.GetAsync(client.BaseAddress + "posts/" + postId + "/comments").Result;
            if(res.IsSuccessStatusCode)
            {
                string Data = res.Content.ReadAsStringAsync().Result;
                comments = JsonSerializer.Deserialize<IEnumerable<CommentViewModel>>(Data);
            }
            return View("~/Views/Components/_Comments.cshtml", comments);

        }
    }
}
