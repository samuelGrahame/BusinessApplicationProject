using BusinessApplicationProject.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BusinessApplicationProject.Defaults.Targets
{
    public class CompileTargetHTML : ICompileTarget
    {
        public string DefaultContainerClass { get; set; } = "container";
       
        public bool UseBoostrap { get; set; } = true;

        public void CompileStage(CompileSettings compileSettings, Stage stage, Project project)
        {
            if (stage == null)
                throw new ArgumentNullException(nameof(stage));
            if (project == null)
                throw new ArgumentNullException(nameof(project));
            if (compileSettings == null)
                throw new ArgumentNullException(nameof(compileSettings));

            var builder = new StringBuilder();

            builder.AppendLine("<html>");
            builder.AppendLine("<head>");

            builder.AppendLine($"<meta charset=\"utf-8\">");
            
            if(UseBoostrap)
            {
                builder.AppendLine($"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">");
                builder.AppendLine($"<link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css\" integrity=\"sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z\" crossorigin=\"anonymous\">");
            }

            builder.AppendLine($"<title>{stage.Name}</title>");

            builder.AppendLine("</head>");

            builder.AppendLine("<body>");

            if (UseBoostrap)
            {
                builder.AppendLine($"<div class=\"container-fluid\">");

                builder.AppendLine("<nav class=\"navbar navbar-light bg-light\">");
                builder.AppendLine($"<a class=\"navbar-brand\" href=\"#\">{stage.Name}</a>");
                builder.AppendLine("</nav>");
                builder.AppendLine("</div>");
            }

            if (!string.IsNullOrWhiteSpace(DefaultContainerClass))
            {
                builder.AppendLine($"<div class=\"{DefaultContainerClass}\" style=\"margin-top:14px\">");
            }

            builder.AppendLine("<form>");

            var properties = stage.GetType().GetProperties();
            
            foreach (var item in properties)
            {
                string type = "";
                string namePrefix = "";
                if (item.PropertyType == typeof(string))
                {
                    //builder.AppendLine("\t}");
                    type = "Input";
                    namePrefix = "txt";
                    var inputClass = "";

                    if (UseBoostrap)
                    {
                        inputClass = $" class=\"form-control\"";

                        builder.AppendLine("<div class=\"form-group\">");
                        //<div class="form-group">
                    }

                    builder.AppendLine($"<{type}{inputClass} placeholder='{item.Name}' type='text' name='{namePrefix}{item.Name}'/>");
                    if (!UseBoostrap)
                    {
                        builder.AppendLine("</br>");
                    }                        
                    else
                    {
                        builder.AppendLine("</div>");
                    }
                }

                if (string.IsNullOrWhiteSpace(type))
                {
                    throw new Exception($"Type not supported: {item.PropertyType.ToString()}");
                }              
            }

            foreach (var item in stage.Actions)
            {
                var buttonName = $"btn{item.Key}";
                var buttonClass = "";

                if(UseBoostrap)
                {
                    buttonClass = $" class=\"btn btn-primary btn-block\"";
                }

                builder.AppendLine($"<button{buttonClass} name='{buttonName}'>{item.Key}</button>");
                if(!UseBoostrap)
                    builder.AppendLine("</br>");
            }
            
            if (!string.IsNullOrWhiteSpace(DefaultContainerClass))
            {
                builder.AppendLine($"</div>");
            }

            builder.AppendLine("</form>");

            builder.AppendLine("</body>");



            builder.AppendLine("</html>");

            if (!Directory.Exists(compileSettings.Path))
                Directory.CreateDirectory(compileSettings.Path);

            File.WriteAllText(Path.Combine(compileSettings.Path, $"html{stage.Name}.html"), builder.ToString());
        }
    }
}
