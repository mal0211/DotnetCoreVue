using System;
using System.Collections.Generic;

namespace DotnetCoreVue.DB.EFModels
{
    public partial class Userinfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
