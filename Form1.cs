using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtNumber.Text = "0";
        }
        Calculate calculate = new Calculate();
        int S1orS2 = 1;
        int operators = -1;
        private void Add_Number(string _number)
        {
            if (txtNumber.Text == "0")
                txtNumber.Text = "";
             txtNumber.Text = txtNumber.Text + _number;
        }

        private void Select_Operator(int _operators)
        {
            if (txtNumber.Text.IndexOf("%") == -1 )
            {
                calculate.firstNumber = Convert.ToSingle(txtNumber.Text);
                S1orS2 += 1;
            }
            txtNumber.Text = "0";
            operators = _operators;
            
        }






        private void btnZero_Click(object sender, EventArgs e)
        {
            Add_Number("0");

        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            Add_Number("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            Add_Number("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            Add_Number("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            Add_Number("4");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            Add_Number("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            Add_Number("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            Add_Number("7");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            Add_Number("8");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            Add_Number("9");
        }





        // 按下選擇「清除」按鍵
        private void btnClear_Click(object sender, EventArgs e)

        {
            txtNumber.Text = "0";
            calculate.Reset();
           
        }

        // 按下選擇「加」按鍵
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Select_Operator(0);

        }

        // 按下選擇「減」按鍵
        private void btnMinus_Click(object sender, EventArgs e)
        {
            Select_Operator(1);
        }

        // 按下選擇「乘」按鍵
        private void btnPlus_Click(object sender, EventArgs e)
        {
            Select_Operator(2);
        }


        // 按下選擇「除」按鍵
        private void btnDivide_Click(object sender, EventArgs e)
        {
            Select_Operator(3);
        }

        // 按下選擇「點」按鍵
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text.IndexOf(".") == -1)
           
            txtNumber.Text = txtNumber.Text + ".";
        }






        // 按下選擇「等於」按鍵
        private void btnEqual_Click(object sender, EventArgs e)
        {

            float finalResults = 0f; //宣告最後計算結果變數
            if (txtNumber.Text.IndexOf("%") == -1)
            {
                calculate.secondNumber = Convert.ToSingle(txtNumber.Text); //將輸入文字框轉換成浮點數，存入第二個數字的全域變數
            }
            //依照四則運算符號的選擇，進行加減乘除
            switch (operators)
            {
                case 0:
                    finalResults = calculate.Add();
                    break;
                case 1:
                    finalResults = calculate.Subtract();
                    break;
                case 2:
                    finalResults = calculate.Multiply();
                    break;
                case 3:
                    finalResults = calculate.Divide();
                    break;
            }

            txtNumber.Text = string.Format("{0:0.##########}", finalResults); //在輸入文字框中，顯示最後計算結果，並且轉換成格式化的字串內容
            calculate.Reset();
           
            //重置所有全域變數
            //firstNumber = 0f;
            //secondNumber = 0f;
            //operators = -1;
        }


        // 按下選擇「百分比」按鍵
        private void button1_Click(object sender, EventArgs e)
        {
           
            switch (S1orS2)
            {
                case 1:
                    calculate.firstNumber = Convert.ToSingle(txtNumber.Text); 
                    txtNumber.Text = string.Format("{0:P2}", calculate.firstNumber);
                    S1orS2 += 1;
                    break;
                case 2:
                    calculate.secondNumber = Convert.ToSingle(txtNumber.Text);
                    txtNumber.Text = string.Format("{0:P2}", calculate.secondNumber);
                    S1orS2 -= 1;
                    break;
            }
        }


        // 按下選擇「刪除」按鍵
        private void button2_Click(object sender, EventArgs e)
        {


            if (txtNumber.Text.Length == 1)
            {
                txtNumber.Text = "0";
            }
            else if (txtNumber.Text.Length == 0)
            {
                txtNumber.Text = " ";
            }
            else
            {
                txtNumber.Text = txtNumber.Text.Substring(0, txtNumber.Text.Length - 1);
            }

        }
    }
}
