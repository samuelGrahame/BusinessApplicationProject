using System.Windows.Forms;

public class frmLogin : Form
{
	public frmLogin()
	{
		this.Text = "Login";

		var __flowLayoutPanel = new BusinessApplicationProjectDemo.StackPanel();
		__flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
		__flowLayoutPanel.Dock = DockStyle.Fill;

		TextBox txtEmail = new TextBox();

		TextBox txtUsername = new TextBox();

		TextBox txtPassword = new TextBox();

		Button btnLogin = new Button();
		btnLogin.Text = "Login";

		txtEmail.TabIndex = 0;
		__flowLayoutPanel.Controls.Add(txtEmail);

		txtUsername.TabIndex = 1;
		__flowLayoutPanel.Controls.Add(txtUsername);

		txtPassword.TabIndex = 2;
		__flowLayoutPanel.Controls.Add(txtPassword);

		btnLogin.TabIndex = 3;
		__flowLayoutPanel.Controls.Add(btnLogin);

		this.Controls.Add(__flowLayoutPanel);
	}
}
