using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApplicationProject.Defaults
{
    public class StageDefaultLogin : Stage
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public StageDefaultLogin() : base()
        {
            base.Description = "Default Login Stage";
            base.IsPublic = true;
            base.Name = "Login";

            Actions.Add("Login", Login);
        }

        public virtual void Login()
        {
            
        }
    }
}
