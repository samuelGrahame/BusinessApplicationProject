using BusinessApplicationProject;
using BusinessApplicationProject.Defaults;
using BusinessApplicationProject.Defaults.Targets;
using System;
using System.Windows.Forms;

namespace BusinessApplicationProjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            var project = new Project();
            var loginStage = new MyLoginStage();

            project.Stages.Add(loginStage);

            project.LoginStage = loginStage;

            project.Build(new CompileSettings()
            {
                Path = "../../../",
                Target = new CompileTargetWinForms()
            });

            var login = new frmLogin();

            Application.EnableVisualStyles();
            Application.Run(login);
        }

        public class MyLoginStage : StageDefaultLogin
        {
            public override void Login()
            {
                if(this.Username != "admin" || this.Password != "admin")
                {
                    throw new Exception("Invalid username or password");
                }
            }
        }
    }
}
