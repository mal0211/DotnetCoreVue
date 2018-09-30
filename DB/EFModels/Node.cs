using System;
using System.Collections.Generic;

namespace DotnetCoreVue.DB.EFModels
{
    public partial class Node
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Com { get; set; }
        public DateTime InsTime { get; set; }
        public string DisplayName { get; set; }
        public string Icon { get; set; }
    }
}
