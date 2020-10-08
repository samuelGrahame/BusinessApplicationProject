using BusinessApplicationProject.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BusinessApplicationProject.Defaults.Targets
{
    public class CompileTargetWinForms : ICompileTarget
    {        
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
            var list = new List<string>();

            foreach (var item in properties)
            {
                string type = "";
                string namePrefix = "";
                if(item.PropertyType == typeof(string))
                {
                    //builder.AppendLine("\t}");
                    type = "TextBox";
                    namePrefix = "txt";
                }

                if (string.IsNullOrWhiteSpace(type))
                {
                    throw new Exception($"Type not supported: {item.PropertyType.ToString()}");
                }
                var controlName = $"{namePrefix}{item.Name}";

                builder.AppendLine($"\t\t{type} {controlName} = new {type}();");
                builder.AppendLine();

                list.Add(controlName);
            }

            foreach (var item in stage.Actions)
            {
                var buttonName = $"btn{item.Key}";
                builder.AppendLine($"\t\tButton {buttonName} = new Button();");
                builder.AppendLine($"\t\t{buttonName}.Text = \"{item.Key}\";");
                builder.AppendLine();

                list.Add(buttonName);
            }

            for (int i = list.Count - 1; i >= 0; i--)
            {
                var name = list[i];
                builder.AppendLine($"\t\t{name}.Dock = DockStyle.Top;");

                builder.AppendLine($"\t\tthis.Controls.Add({name});");
            }
            
            builder.AppendLine("\t}");

            builder.AppendLine("}");

            if (!Directory.Exists(compileSettings.Path))
                Directory.CreateDirectory(compileSettings.Path);

            File.WriteAllText(Path.Combine(compileSettings.Path, $"frm{stage.Name}.cs"), builder.ToString());
        }
    }
}
