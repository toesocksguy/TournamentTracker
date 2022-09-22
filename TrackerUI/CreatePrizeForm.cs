using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text, 
                    placeNumberValue.Text, 
                    prizeAmountValue.Text, 
                    prizePercentageValue.Text);

                GlobalConfig.Connection.CreatePrize(model);
             
                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeAmountValue.Text = "0";
                prizePercentageValue.Text = "0";
            }
        }

        /// <summary>
        /// Method to validate PrizeForm inputs.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            // Validate Place Number
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);

            if (placeNumberValidNumber == false)
            {
                output = false;
                MessageBox.Show("Place Number must be a number.");
            }

            if (placeNumber < 1)
            {
                output = false;
                MessageBox.Show("Place Number must be at least one.");
            }

            if (placeNameValue.Text.Length == 0)
            {
                output = false;
                MessageBox.Show("Place Name cannot be empty");
            }

            // Validate Prize Amount or Prize Percentage
            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);

            if (prizeAmountValid == false)
            {
                output = false;
                MessageBox.Show("Prize amount must be a number.");
            }

            if (prizePercentageValid == false)
            {
                output = false;
                MessageBox.Show("Prize percentage must be a number.");
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
                MessageBox.Show("Prize amount and percentage must be greater than zero.");
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
                MessageBox.Show("Prize percentage cannot be less than zero or greater than 100.");
            }

            return output;
        }
    }
}
