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
            project.Stages.Add(new TestStage());

            project.LoginStage = loginStage;

            project.Build(new CompileSettings()
            {
                Path = "../../../",
                Target = new CompileTargetWinForms()
                {
                    FlowControlName = "BusinessApplicationProjectDemo.StackPanel"
                }           
            },
            new CompileSettings()
            {
                Path = "../../../wwwroot",
                Target = new CompileTargetHTML()
            });
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

        public class TestStage : Stage
        {

            public string FirstName { get; set; }
            
            public TestStage()
            {
                this.Name = "Test";
                this.Actions.Add("Test", TestFunc);
            }


            public void TestFunc()
            {

            }
        }


    }
}
