using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageBasic_2m3
{
    public partial class Form1 : Form
    {
        private bool isOperationAdded;
        private string operation;
        private double result = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOne_Click(object sender, EventArgs e)
        {

            if (lblResult.Text.Equals("0") || isOperationAdded)
            {
                lblResult.Text = "";
            }
            isOperationAdded = false;
            Button btn = (Button)sender;
            if (btn.Text.Equals(".", StringComparison.CurrentCultureIgnoreCase))
            {
                if (lblResult.Text.Contains("."))
                {
                    return;
                }
            }
            lblResult.Text += btn.Text;
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (result == 0)
            {
                result = double.Parse(lblResult.Text);
                lblOperation.Text = lblResult.Text + " " + btn.Text;
                operation = btn.Text;
                isOperationAdded = true;
            }
            else
            {
             
                operation = btn.Text;
              isOperationAdded = true;
                PerformOperation(operation);
                lblOperation.Text = lblResult.Text + " " + btn.Text;
            }
            
        }

         private void PerformOperation(string operation)
        {
            
            switch (operation)
            {
                case "+":
                    result = result += double.Parse(lblResult.Text);
                break;
                case "-":
                    result = result -= double.Parse(lblResult.Text);
                break;
                case "X":
                    result = result *= double.Parse(lblResult.Text);
                break;
                case "/":
                    double temp = double.Parse(lblResult.Text);
                    if (result == 0 && temp == 0)
                    {
                        lblResult.Text = "Undefined";
                    }
                    else if (temp == 0)
                    {
                        lblResult.Text = "Error";

                    }
                    else {
                        result /= temp;
                    }
                    break;
                default:
                    break;

            }
            lblResult.Text = result.ToString();
            operation = " ";
            
     }
    }
}
