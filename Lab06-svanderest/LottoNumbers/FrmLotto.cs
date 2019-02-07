using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// Done By: Sebastian van der Est
// Description: A program that will generate 2 sets of random numbers and compares
//              the 2 sets to determine how many match.
namespace LottoNumbers
{
    public partial class FrmLotto : Form
    {
        List<int> selectedNums = new List<int>(7);
        List<int> winningNums = new List<int>(6);
        public FrmLotto()
        {
            InitializeComponent();
        }

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            GenerateRandomNumbers(selectedNums);
            lblPlayerNumber.Text = BuildDisplayString(selectedNums);
        }

        private void btnComputer_Click(object sender, EventArgs e)
        {            
            GenerateRandomNumbers(winningNums);
            lblComputerNumber.Text = BuildDisplayString(winningNums);
            lblMatching.Text = CompareTwoArrays(selectedNums, winningNums).ToString();
        }

        private void GenerateRandomNumbers(List<int> numberList)
        {
            for(int i = 0; i<numberList.Capacity; i++)
            {
                int number;
                do
                {
                    Random random = new Random();
                    number = random.Next(1, 50);

                } while (numberList.Contains(number));               
                if (numberList.Count == numberList.Capacity)
                    numberList[i] = number;
                else
                    numberList.Add(number);
            }
        }

        private string BuildDisplayString(List<int> numberList)
        {
            StringBuilder display = new StringBuilder("");
            foreach (int number in numberList)            
                display.Append(number.ToString() + " ");                            
            return display.ToString().Trim();
        }

        private int CompareTwoArrays(List<int> list1, List<int> list2)
        {
            int count = 0;
            foreach(int number in list1)
            {
                if (list2.Contains(number))
                    count++;
            }
            return count;
        }
        
    }
}