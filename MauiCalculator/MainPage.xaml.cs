using System.Reflection.Emit;

namespace MauiCalculator;

public partial class MainPage : ContentPage
{
    //int count = 0; Unnecessary
    bool hasDecimal = false;
    bool isFreshInput = true;
    bool hasError = false;
    bool isPrevPercOp = false;
    float memoizedPercent = 0;
    enum Operator
    {
        Addition,
        Multiplication,
        Division,
        Subtraction,
        Exponent,
        Percent,
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

    private void btn_prcnt_Clicked(object sender, EventArgs e)
    {
        if (lblInput.Text == null || lblInput.Text=="")
        {
            lblInputOutput.Text = "0";
            return;
        }
        else
        {
            operationMethodBody(Operator.Percent, lblInput.Text.Split(' ')[1][0]);
        }
    }

    private Operator calculate(float[] operands, Operator op, bool isCalculatedByEqual, char symbol) {
        float result = 0;

        if (selectedOp != Operator.Percent)
        {
            isPrevPercOp = false;
            memoizedPercent = 0;
        }

        switch (op)
        {
            case Operator.Addition:
                result = operands[0] + operands[1];
                break;
            case Operator.Multiplication:   
                result = operands[0] * operands[1];
                break;
            case Operator.Division:
                try { 
                    result = (operands[1] == 0) ? throw new DivideByZeroException("Cannot divide by zero") : operands[0] / operands[1]; 
                } catch (DivideByZeroException e)
                {
                    hasError = true;
                    lblInputOutput.Text = e.Message;
                    return Operator.None;
                }
                break;
            case Operator.Subtraction:
                result = operands[0] - operands[1];
                break;
            case Operator.Exponent:
                result = (float)Math.Pow(operands[0], operands[1]);
                break;
            case Operator.Percent:
                result = ((symbol == '+' || symbol == '-') && !(lblInput.Text.Contains('=')) && !isPrevPercOp)
                    ? operands[1] * (operands[0]/100)
                    : (!lblInput.Text.Contains('=')) ? (!isPrevPercOp) ? operands[1]/100 : memoizePercentResult(operands) : memoizePercentResult(operands);
                break;
        }

        lblInput.Text = (!isCalculatedByEqual) 
            ? result.ToString() + " " + symbol 
            : $"{operands[0]} {symbol} {operands[1]} = {result}";

        lblInputOutput.Text = result.ToString();
        return selectedOp;
    }

    private float memoizePercentResult(float[] operands)
    {
        if (memoizedPercent == 0)
        {
            memoizedPercent = float.Parse(lblInputOutput.Text) / 100;
            isPrevPercOp = true;
        }
        return memoizedPercent * operands[1];
    }

    private void btn_ce_Clicked(object sender, EventArgs e)
    {
        lblInputOutput.Text = "0";
    }

    private void btn_c_Clicked(object sender, EventArgs e)
    {
        lblInput.Text = "";
        lblInputOutput.Text = "0";
        selectedOp = Operator.None;
        resetBools();
    }


    // Overloaded method so you can programmatically call the clear function
    private void btn_c_Clicked()
    {
        lblInput.Text = "";
        lblInputOutput.Text = "0";
        selectedOp = Operator.None;
        resetBools();
    }

    private void addInputOutputText(char input)
    {
        if (hasError)
        {
            btn_c_Clicked();
        }

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
        operationMethodBody(Operator.Addition, '+');
    }

    private void btn_mltply_Clicked(object sender, EventArgs e)
    {
        operationMethodBody(Operator.Multiplication, '*');
    }

    private void btn_dvde_Clicked(object sender, EventArgs e)
    {
        operationMethodBody(Operator.Division, '/');
    }


    private void btn_sbtrct_Clicked(object sender, EventArgs e)
    {
        operationMethodBody(Operator.Subtraction, '-');
    }

    private void operationMethodBody(Operator op, char symb)
    {
        selectedOp = (op == Operator.Percent)
                    ? calculate(new float[] { float.Parse(lblInput.Text.Split(' ')[0]), float.Parse(lblInputOutput.Text) },op,false,symb)
                    : (selectedOp == Operator.None || isFreshInput)
                        ? op
                        : calculate(new float[] { float.Parse(lblInput.Text.Split(' ')[0]), float.Parse(lblInputOutput.Text) },selectedOp,false,symb);
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
        hasError = false;
    }

    private void btn_exp_Clicked(object sender, EventArgs e)
    {
        operationMethodBody(Operator.Exponent, '^');
    }


    private void btn_eql_Clicked(object sender, EventArgs e)
    {
        if (selectedOp == Operator.None)
        {
            return;
        }
        if (!hasError)
        {
            Operator invert = (!lblInput.Text.Contains('='))
                ? calculate(new float[] { float.Parse(lblInput.Text.Split(' ')[0]), float.Parse(lblInputOutput.Text) }, selectedOp, true, lblInput.Text.Split(' ')[1][0])
                : calculate(new float[] { float.Parse(lblInputOutput.Text), float.Parse(lblInput.Text.Split(' ')[2]) }, selectedOp, true, lblInput.Text.Split(' ')[1][0]);
        } else
        {
            btn_c_Clicked();
        }
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


