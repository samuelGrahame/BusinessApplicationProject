using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApplicationProject
{
    public class Stage
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public Dictionary<string, Action> Actions { get; set; } = new Dictionary<string, Action>();
    }
}

