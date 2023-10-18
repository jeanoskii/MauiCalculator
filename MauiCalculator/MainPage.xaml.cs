using System.Reflection.Emit;

namespace MauiCalculator;

public partial class MainPage : ContentPage
{
    //int count = 0; Unnecessary
    bool hasDecimal = false;
    bool isFreshInput = true;
    enum Operator
    {
        Addition,
        Multiplication,
        Division,
        Subtraction,
        Exponent,
        None
    }

    Operator selectedOp = Operator.None;

	public MainPage()
	{
		InitializeComponent();
	}

    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;
    //} Unnecessary

    private Operator calculate(float[] operands, Operator op, bool isCalculatedByEqual) {
        float result = 0;
        char symbol = ' ';

        switch (op)
        {
            case Operator.Addition:
                symbol = '+';
                result = operands[0] + operands[1];
                break;
            case Operator.Multiplication:   
                symbol = '*';
                result = operands[0] * operands[1];
                break;
            case Operator.Division:
                symbol = '/';
                result = operands[0] / operands[1];
                break;
            case Operator.Subtraction:
                symbol = '-';
                result = operands[0] - operands[1];
                break;
            case Operator.Exponent:
                symbol = '^';
                Math.Pow(operands[0], operands[1]);
                break;
        }

        lblInput.Text = (!isCalculatedByEqual) 
            ? result.ToString() + " " + symbol 
            : $"{operands[0]} {symbol} {operands[1]} = {result}";

        setOutput(result);
        return selectedOp;
    }

    private void setOutput(float result)
    {
        lblInputOutput.Text = result.ToString();
    }

    private void btnBackSpace_Clicked(object sender, EventArgs e)
    {
        hasDecimal = false;
		lblInputOutput.Text = "0";
    }

    private void addInputOutputText(char input)
    {
        if (input=='.')
        {
            lblInputOutput.Text = (!hasDecimal) ? lblInputOutput.Text += input : lblInputOutput.Text;
            hasDecimal = lblInputOutput.Text.Contains('.');
            isFreshInput = false;
            return;
        }
        lblInputOutput.Text = (lblInputOutput.Text == "0" || isFreshInput) ? input.ToString() : lblInputOutput.Text += input;
        isFreshInput = false;
    }
    
    private void dcm_Clicked(object sender, EventArgs e)
    {
        addInputOutputText('.');
    }

    private void btn_add_Clicked(object sender, EventArgs e)
    {
        selectedOp = (selectedOp == Operator.None || isFreshInput) ? Operator.Addition : calculate(new float[] { float.Parse(lblInput.Text.Split(' ')[0]), float.Parse(lblInputOutput.Text) }, selectedOp, false);
        if (lblInputOutput.Text.EndsWith('.'))
        {
            lblInputOutput.Text = lblInputOutput.Text.Substring(0, lblInputOutput.Text.Length - 1);
        }
        lblInput.Text = lblInputOutput.Text + " +";
        resetBools();
    }

    private void btn_mltply_Clicked(object sender, EventArgs e)
    {
        selectedOp = (selectedOp == Operator.None || isFreshInput) ? Operator.Multiplication : calculate(new float[] { float.Parse(lblInput.Text.Split(' ')[0]), float.Parse(lblInputOutput.Text) }, selectedOp, false);
        if (lblInputOutput.Text.EndsWith('.'))
        {
            lblInputOutput.Text = lblInputOutput.Text.Substring(0, lblInputOutput.Text.Length - 1);
        }
        lblInput.Text = lblInputOutput.Text + " x";
        resetBools();
    }

    private void btn_dvde_Clicked(object sender, EventArgs e)
    {
        operationMethodBody(Operator.Division, '/');
    }

    private void operationMethodBody(Operator op, char symb)
    {
        selectedOp = (selectedOp == Operator.None || isFreshInput) ? op : calculate(new float[] { float.Parse(lblInput.Text.Split(' ')[0]), float.Parse(lblInputOutput.Text) }, selectedOp, false);
        if (lblInputOutput.Text.EndsWith('.'))
        {
            lblInputOutput.Text = lblInputOutput.Text.Substring(0, lblInputOutput.Text.Length - 1);
        }
        lblInput.Text = lblInputOutput.Text + $" {symb}";
        resetBools();
    }

    private void resetBools()
    {
        isFreshInput = true;
        hasDecimal = false;
    }

    private void btn_eql_Clicked(object sender, EventArgs e)
    {
        Operator invert = (!lblInput.Text.Contains('='))
            ? calculate(new float[] { float.Parse(lblInput.Text.Split(' ')[0]), float.Parse(lblInputOutput.Text) }, selectedOp, true)
            : calculate(new float[] { float.Parse(lblInputOutput.Text), float.Parse(lblInput.Text.Split(' ')[2]) }, selectedOp, true);
        resetBools();
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

