using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApplicationProject.Interfaces
{
    public interface ICompileTarget
    {
        public string OutputFolder { get; }
        void CompileStage(CompileSettings compileSettings, Stage stage, Project project);
    }
}
