using Microsoft.AspNetCore.Mvc;
using DotnetCoreVue.DB.EFModels;
namespace DotnetCoreVue.Controllers
{
    public class BaseController : Controller
    {
       protected EFContent db;
       public BaseController(EFContent content)
       {
           db=content;
       }
    }
}
