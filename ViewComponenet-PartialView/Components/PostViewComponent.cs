using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ViewComponenet_PartialView.Models;

namespace ViewComponenet_PartialView.Components
{
    public class PostViewComponent : ViewComponent
    {
        Uri baseAddress;
        IConfiguration _configuration;
        HttpClient client;

        public PostViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
            baseAddress = new Uri(_configuration["ApiAddress"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IViewComponentResult Invoke(int id)
        {
            PostViewModel posts = new PostViewModel();
            var res = client.GetAsync(client.BaseAddress + "posts/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                string strdata = res.Content.ReadAsStringAsync().Result;
                posts = JsonSerializer.Deserialize<PostViewModel>(strdata);
            }
            
            return View("~/Views/Components/_Posts.cshtml", posts);
        }

    }
}
