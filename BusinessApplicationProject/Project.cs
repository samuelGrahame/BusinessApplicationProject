using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApplicationProject
{
    public class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        
        public Stage LoginStage { get; set; }
        public List<Stage> Stages { get; set; }

        public void Build(params CompileSettings[] compileSettings)
        {

        }
    }
}
