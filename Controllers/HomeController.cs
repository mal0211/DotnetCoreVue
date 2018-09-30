
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotnetCoreVue.DB.EFModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetCoreVue.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(EFContent content) : base(content)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// 获取符合条件的导航栏
        /// </summary>
        /// <returns>The nav.</returns>
        [HttpPost]
        public IActionResult GetNav()
        {
            var nodes = db.Node.Where(item =>item.Pid==0).ToList();
            var routes=nodes.Select(a =>new {
                name=a.Name,
                path =a.Path,
                com =a.Com,
                children=db.Node.Where(b =>b.Pid==a.Id).Select(c =>new {
                    name=c.Name,
                    path =c.Path,
                    com =c.Com,
                    display=c.DisplayName,
                    icon =c.Icon
                })
            });
            return Json(routes);          
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns>The nav.</returns>
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var usermodel=db.Userinfo.FirstOrDefault(a=>a.UserName==username && a.Password==password);
            string code="0";
            if(usermodel!=null)
            {
                code="1";
            }
            return Json(new {
                code,
                username,
                password
            });
        }
    }
}
