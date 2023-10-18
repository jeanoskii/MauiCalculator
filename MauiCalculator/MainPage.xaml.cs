namespace MauiCalculator;

public partial class MainPage : ContentPage
{
    //int count = 0; Unnecessary

    enum Operator
    {
        Addition,
        Multiplication,
        Division,
        Subtraction,
        Exponent
    }

	public MainPage()
	{
		InitializeComponent();
	}

    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;
    //} Unnecessary

    private double calculate(double[] operands, Operator op) {
        switch (op)
        {
            case Operator.Addition:
                return operands[0] + operands[2];
        }
        return 0;
    }


    private void btnBackSpace_Clicked(object sender, EventArgs e)
    {
		lblInputOutput.Text = "0";
    }

    private void addInputOutputText(char input)
    {
      lblInputOutput.Text = (lblInputOutput.Text == "0") ? input.ToString() : lblInputOutput.Text += input;
    }

    private void btn0_clicked(object sender, EventArgs e)
    {
        addInputOutputText('0');
    }

    private void btn1_Clicked(object sender, EventArgs e)
    {
        addInputOutputText('1');
    }

    private void btn2_Clicked(object sender, EventArgs e)
    {
        addInputOutputText('2');
    }

    private void btn3_Clicked(object sender, EventArgs e)
    {
        addInputOutputText('3');
    }

    private void btn4_Clicked(object sender, EventArgs e)
    {
        addInputOutputText('4');
    }

    private void btn5_Clicked(object sender, EventArgs e)
    {
        addInputOutputText('5');
    }

    private void btn6_Clicked(object sender, EventArgs e)
    {
        addInputOutputText('6');
    }

    private void btn7_Clicked(object sender, EventArgs e)
    {
        addInputOutputText('7');
    }

    private void btn8_Clicked(object sender, EventArgs e)
    {
        addInputOutputText('8');
    }

    private void btn9_Clicked(object sender, EventArgs e)
    {
        addInputOutputText('9');
    }
}

