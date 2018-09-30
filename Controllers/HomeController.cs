
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
                    com =c.Com
                })
            });
            return Json(routes);
            #region old Test ,just save a moment
            // StringBuilder routes=new StringBuilder();
            // foreach(Node item in nodes)
            // {
                 
            //     List<Node> childList=db.Node.Where(c =>c.Pid==item.Id).ToList();
            //     if(childList.Count==0)
            //     {
            //         if(!string.IsNullOrEmpty(routes.ToString()))
            //         {
            //             routes.Append(",");
            //         }
            //         routes.Append("{name:'"+item.Name+"',path:'"+item.Path+"',component(resolve){require(['../components/"+item.Com+"'],resolve)}}");
                   
            //     }
            //     else
            //     {
            //         if(!string.IsNullOrEmpty(routes.ToString()))
            //         {
            //             routes.Append(",");
            //         }
            //         StringBuilder strChildren=new StringBuilder();
            //         foreach(Node child in childList)
            //         {
                        
            //             strChildren.Append("{name:'"+child.Name+"',path:'"+child.Path+"',component(resolve){require(['../components/"+child.Com+"'],resolve)}}");
            //         }
                    
            //          routes.Append("{name:'"+item.Name+"',path:'"+item.Path+"',component(resolve){require(['../components/"+item.Com+"'],resolve)},children:["+strChildren+"]}");
            //     }
            //     childList=null;
            // }
            // routes.Insert(0,"[").Append("]");//在前后分别补加[ 和 ]，包装成js数组的样子。
            // return Json(routes);
            #endregion
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
