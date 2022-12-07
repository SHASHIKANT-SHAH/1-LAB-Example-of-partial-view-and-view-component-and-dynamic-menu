using Microsoft.AspNetCore.Mvc;

namespace ViewComponenet_PartialView.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            //here we Have to get PostId and CommentId through string url to making fully dynamic
            ViewBag.PostId = 1;
            ViewBag.CommentId = 1;
            return View();
        }
    }
}
