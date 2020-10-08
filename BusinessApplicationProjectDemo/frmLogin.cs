using System.Windows.Forms;

public class frmLogin : Form
{
	public frmLogin()
	{
		TextBox txtUsername = new TextBox();

		TextBox txtPassword = new TextBox();

		Button btnLogin = new Button();
		btnLogin.Text = "Login";

		btnLogin.Dock = DockStyle.Top;
		btnLogin.TabIndex = 2;
		this.Controls.Add(btnLogin);

		txtPassword.Dock = DockStyle.Top;
		txtPassword.TabIndex = 1;
		this.Controls.Add(txtPassword);

		txtUsername.Dock = DockStyle.Top;
		txtUsername.TabIndex = 0;
		this.Controls.Add(txtUsername);

	}
}
