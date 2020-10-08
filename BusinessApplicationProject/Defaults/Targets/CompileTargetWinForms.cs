using BusinessApplicationProject.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BusinessApplicationProject.Defaults.Targets
{
    public class CompileTargetWinForms : ICompileTarget
    {
        public string OutputFolder => "WinForms";

        public void CompileStage(CompileSettings compileSettings, Stage stage, Project project)
        {
            if (stage == null)
                throw new ArgumentNullException(nameof(stage));
            if (project == null)
                throw new ArgumentNullException(nameof(project));
            if (compileSettings == null)
                throw new ArgumentNullException(nameof(compileSettings));

            var builder = new StringBuilder();
            // a stage in winforms is a form.
            // lets create the form code.

            builder.AppendLine($"public class frm{stage.Name}");
            builder.AppendLine("{");

            builder.AppendLine($"\tpublic frm{stage.Name}");
            builder.AppendLine("\t{");

            var properties = stage.GetType().GetProperties();

            foreach (var item in properties)
            {
                string type = "";
                if(item.PropertyType == typeof(string))
                {
                    //builder.AppendLine("\t}");
                    type = "TextBox";
                }

                if (string.IsNullOrWhiteSpace(type))
                {
                    throw new Exception($"Type not supported: {item.PropertyType.ToString()}");
                }

                builder.AppendLine($"\t\t{type} {item.Name} = new {type}();");
            }

            foreach (var item in stage.Actions)
            {
                builder.AppendLine($"\t\tButton btn{item.Key} = new Button();");
                builder.AppendLine($"\t\tbtn{item.Key}.Text = \"{item.Key}\";");
            }

            builder.AppendLine("\t}");

            builder.AppendLine("}");

            File.WriteAllText(Path.Combine(compileSettings.Path, OutputFolder, $"frm{stage.Name}.cs"), builder.ToString());
        }
    }
}
