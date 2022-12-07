using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViewComponenet_PartialView.Models;

namespace ViewComponenet_PartialView.Components
{
    public class MenuViewComponent : ViewComponent
    {
       

        public IViewComponentResult Invoke()
        {
            var menusList = new List<MenuListModel>()
            {
                new MenuListModel() { cnt = "Home", action = "Index", title = "Home"},
                new MenuListModel() { cnt = "Home", action = "Privacy", title = "Privacy"},
                new MenuListModel() { cnt="Post", action= "Index", title = "Post"},
            };
            //var List = from M in menusList
            //           select M;

            return View("~/Views/Components/_TopMenu.cshtml", menusList);
        }
    }
}

//public class MenusList
//{
//    public string cnt;
//    public string action;
//    public string title;
//}
