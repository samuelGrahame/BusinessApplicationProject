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
        public string FlowControlName { get; set; }

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
            
            builder.AppendLine($"using System.Windows.Forms;");
            builder.AppendLine();

            builder.AppendLine($"public class frm{stage.Name} : Form");
            builder.AppendLine("{");

            builder.AppendLine($"\tpublic frm{stage.Name}()");
            builder.AppendLine("\t{");

            var properties = stage.GetType().GetProperties();
            var list = new List<string>();

            string flowType = string.IsNullOrWhiteSpace(FlowControlName) ? "FlowLayoutPanel" : FlowControlName;

            builder.AppendLine($"\t\tthis.Text = \"{stage.Name}\";");
            builder.AppendLine();

            builder.AppendLine($"\t\tvar __flowLayoutPanel = new {flowType}();");
            builder.AppendLine("\t\t__flowLayoutPanel.FlowDirection = FlowDirection.TopDown;");
            builder.AppendLine("\t\t__flowLayoutPanel.Dock = DockStyle.Fill;");

            builder.AppendLine();

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
            for (int i = 0; i < list.Count; i++)
            {
                var name = list[i];

                builder.AppendLine($"\t\t{name}.TabIndex = {i};");

                builder.AppendLine($"\t\t__flowLayoutPanel.Controls.Add({name});");
                builder.AppendLine();
            }
            
            builder.AppendLine("\t\tthis.Controls.Add(__flowLayoutPanel);");

            builder.AppendLine("\t}");

            builder.AppendLine("}");

            if (!Directory.Exists(compileSettings.Path))
                Directory.CreateDirectory(compileSettings.Path);

            File.WriteAllText(Path.Combine(compileSettings.Path, $"frm{stage.Name}.cs"), builder.ToString());
        }
    }
}
