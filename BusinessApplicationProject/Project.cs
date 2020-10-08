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
        public List<Stage> Stages { get; set; } = new List<Stage>();

        public void Build(params CompileSettings[] compileSettings)
        {
            if (compileSettings == null || compileSettings.Length == 0)
                throw new ArgumentNullException(nameof(compileSettings));

            foreach (var item in compileSettings)
            {
                foreach (var stage in Stages)
                {
                    item.Target.CompileStage(item, stage, this);
                }                
            }
        }
    }
}
