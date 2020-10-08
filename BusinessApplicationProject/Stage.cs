using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApplicationProject
{
    public class Stage
    {
        public string Name;
        public string Description;

        public bool IsPublic;

        public Dictionary<string, Action> Actions = new Dictionary<string, Action>();
    }
}

