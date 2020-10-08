using System.Windows.Forms;

public class frmTest : Form
{
	public frmTest()
	{
		this.Text = "Test";

		var __flowLayoutPanel = new BusinessApplicationProjectDemo.StackPanel();
		__flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
		__flowLayoutPanel.Dock = DockStyle.Fill;

		TextBox txtFirstName = new TextBox();

		Button btnTest = new Button();
		btnTest.Text = "Test";

		txtFirstName.TabIndex = 0;
		__flowLayoutPanel.Controls.Add(txtFirstName);

		btnTest.TabIndex = 1;
		__flowLayoutPanel.Controls.Add(btnTest);

		this.Controls.Add(__flowLayoutPanel);
	}
}
