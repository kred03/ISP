using System;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class CalculatorPage : ContentPage
    {
        private string currentInput = "";
        private string currentOperator = "";
        private double firstNumber = 0;

        public CalculatorPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                currentInput += button.Text;
                Display.Text = currentInput;
            }
        }
        private void OnClearClicked(object sender, EventArgs e)
        {
            currentInput = "";
            firstNumber = 0;
            currentOperator = "";
            Display.Text = "";
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double secondNumber))
            {
                switch (currentOperator)
                {
                    case "+":
                        firstNumber += secondNumber;
                        break;
                    case "-":
                        firstNumber -= secondNumber;
                        break;
                    case "*":
                        firstNumber *= secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                            firstNumber /= secondNumber;
                        break;
                }
            }

            currentInput = firstNumber.ToString();
            Display.Text = currentInput;
            currentOperator = "";
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (double.TryParse(currentInput, out double number))
                {
                    firstNumber = number;
                    currentInput = "";
                    currentOperator = button.Text;
                }
            }
        }

        private void OnExpClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double x))
            {
                firstNumber = Math.Exp(x);
                Display.Text = firstNumber.ToString();
                currentInput = firstNumber.ToString();
            }
        }
    }
}
