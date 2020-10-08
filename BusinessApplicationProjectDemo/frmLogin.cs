using System.Windows.Forms;

public class frmLogin : Form
{
	public frmLogin()
	{
		this.Text = "Login";

		var __flowLayoutPanel = new BusinessApplicationProjectDemo.StackPanel();
		__flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
		__flowLayoutPanel.Dock = DockStyle.Fill;

		TextBox txtUsername = new TextBox();

		TextBox txtPassword = new TextBox();

		Button btnLogin = new Button();
		btnLogin.Text = "Login";

		txtUsername.TabIndex = 0;
		__flowLayoutPanel.Controls.Add(txtUsername);

		txtPassword.TabIndex = 1;
		__flowLayoutPanel.Controls.Add(txtPassword);

		btnLogin.TabIndex = 2;
		__flowLayoutPanel.Controls.Add(btnLogin);

		this.Controls.Add(__flowLayoutPanel);
	}
}
