using System.Linq;
using DotnetCoreVue.DB.EFModels;
using Microsoft.AspNetCore.Mvc;

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
            var nodes = db.Node.ToList();
            foreach(Node item in nodes)
            {
                
            }
            return Json(nodes);
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
                code="2",
                username,
                password
            });
        }
    }
}
