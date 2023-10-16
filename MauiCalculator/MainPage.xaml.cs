namespace MauiCalculator;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

	}

    private void btnBackSpace_Clicked(object sender, EventArgs e)
    {
		lblOutput.Text = "";
    }

    private void btn1_Clicked(object sender, EventArgs e)
    {
		lblOutput.Text = lblOutput.Text + "1";
    }

    private void btn2_Clicked(object sender, EventArgs e)
    {
		lblOutput.Text = lblOutput.Text + "2";
    }

    private void btn3_Clicked(object sender, EventArgs e)
    {
        lblOutput.Text = lblOutput.Text + "3";
    }

    private void btn4_Clicked(object sender, EventArgs e)
    {
        lblOutput.Text = lblOutput.Text + "4";
    }

    private void btn5_Clicked(object sender, EventArgs e)
    {
        lblOutput.Text = lblOutput.Text + "5";
    }

    private void btn6_Clicked(object sender, EventArgs e)
    {
        lblOutput.Text = lblOutput.Text + "6";
    }

    private void btn7_Clicked(object sender, EventArgs e)
    {
        lblOutput.Text = lblOutput.Text + "7";
    }

    private void btn8_Clicked(object sender, EventArgs e)
    {
        lblOutput.Text = lblOutput.Text + "8";
    }

    private void btn9_Clicked(object sender, EventArgs e)
    {
        lblOutput.Text = lblOutput.Text + "9";
    }
}

