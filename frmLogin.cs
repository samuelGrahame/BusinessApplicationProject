public class frmLogin
{
	public frmLogin
	{
		TextBox txtUsername = new TextBox();

		TextBox txtPassword = new TextBox();

		Button btnLogin = new Button();
		btnLogin.Text = "Login";

		btnLogin.Dock = DockStyle.Top;
		this.Controls.Add(btnLogin);
		txtPassword.Dock = DockStyle.Top;
		this.Controls.Add(txtPassword);
		txtUsername.Dock = DockStyle.Top;
		this.Controls.Add(txtUsername);
	}
}
