//Cash Register created by Rie Koay on October 16 2017
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;


namespace Cash_Register
{
    public partial class mainDisplay : Form
    {
        public mainDisplay()
        {
            InitializeComponent();
        }

        //global variables

        //Variables that won't change
        const double BURGERCOST = 2.49;
        const double FRIESCOST = 1.89;
        const double DRINKSCOST = 0.99;
        const double TAXRATIO = 0.13;

        //Variables that will change
        int burgerAmount = 0;
        int friesAmount = 0;
        int drinksAmount = 0;
        double givenAmount = 0;

        double subTotal = 0;
        double taxes = 0;
        double grandTotal = 0;
        double change = 0;
        double totalBurgerCost = 0;
        double totalFriesCost = 0;
        double totalDrinksCost = 0;

        string name;

        Graphics receiptDisplay;

        private void clickO_Click(object sender, EventArgs e)
        {
            //Applying try and catch so that the program will not crash when errors occur
            try
            {
                burgerAmount = Convert.ToInt16(textboxO.Text);
            }
            catch 
            {
                textboxO.Text = "";
             }

            try
            {
                friesAmount = Convert.ToInt16(textboxT.Text);
            }
            catch 
            {
                textboxT.Text = "";
            }

            try
            {
                drinksAmount = Convert.ToInt16(textboxTh.Text);
            }
            catch
            {
                textboxTh.Text = "";
                return;
            }
                name = textboxSix.Text;
           
            //Calculation 
            totalBurgerCost = burgerAmount * BURGERCOST;
            totalBurgerCost.ToString("C");//Formatting Number
            totalFriesCost = friesAmount * FRIESCOST;
            totalFriesCost.ToString("C");//Formatting Number
            totalDrinksCost = drinksAmount * DRINKSCOST;
            totalDrinksCost.ToString("C");//Formatting Number
            //How much the total actually is without the tax annd such
            subTotal = totalBurgerCost + totalFriesCost + totalDrinksCost;
            blankDisplayO.Text = subTotal.ToString("C");//Formatting Number

            taxes = TAXRATIO * subTotal;
            blankDisplayT.Text = taxes.ToString("C");//Formatting Number

            grandTotal = taxes + subTotal;
            blankDisplayTh.Text = grandTotal.ToString("C");//Formatting Number
        }

        private void clickT_Click(object sender, EventArgs e)
        {
            //Applying try and catch so that the program will not crash when errors occur
            try
            {
                givenAmount = Convert.ToDouble(textboxSe.Text);
            }
            catch
            {
                textboxSe.Text = "";
                return;
            }
            //Calculation
            change = givenAmount - grandTotal;
            //Formatting Numbers
            blankDisplayF.Text = change.ToString("C");

        }

        private void clickTh_Click(object sender, EventArgs e)
        {
            Pen drawPen = new Pen(Color.Black, 5);
            SolidBrush colour = new SolidBrush(Color.White);
            receiptDisplay = this.CreateGraphics();
            receiptDisplay.DrawRectangle(drawPen, 320, 10, 620, 320);
            receiptDisplay.FillRectangle(colour, 320, 10, 620, 320);


            //Giving names
            string lineOne = "Great Burger Company";
            string lineTwo = "Hamburger";
            string lineThree = "Fries";
            string lineFour = "Drinks";
            string lineFive = "Subtotal";
            string lineSix = "Taxes";
            string lineSeven = "Grand Total";
            string lineEight = "Amount Given";
            string lineNine = "Change";
            string lineTen = "@";
            string lineEleven = "each";

            //Using drawstrings to create the receipt
            Font font = new Font("consolas", 12, FontStyle.Underline);
            colour = new SolidBrush(Color.Black);

            //Playing the sound
            SoundPlayer player = new SoundPlayer(Properties.Resources.Dot_Matrix_Printer_SoundBible_com_790333844__1_);
            player.Play();

            receiptDisplay.DrawString(lineOne, font, colour, 370, 20);
            Thread.Sleep(500);
            font = new Font("consolas", 12);
            receiptDisplay.DrawString(lineTwo + " x" + burgerAmount + lineTen + " $" + BURGERCOST + lineEleven, font, colour, 350, 40);
            receiptDisplay.DrawString("$" + totalBurgerCost, font, colour, 600, 40);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineThree + "     x" + friesAmount + lineTen + " $" + FRIESCOST + lineEleven, font, colour, 350, 60);
            receiptDisplay.DrawString("$" + totalFriesCost, font, colour, 600, 60);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineFour + "    x" + drinksAmount + lineTen + " $" + DRINKSCOST + lineEleven, font, colour, 350, 80);
            receiptDisplay.DrawString("$" + totalDrinksCost, font, colour, 600, 80);
            Thread.Sleep(500);

            player = new SoundPlayer(Properties.Resources.Dot_Matrix_Printer_SoundBible_com_790333844__1_);
            player.Play();
            receiptDisplay.DrawString(lineFive, font, colour, 350, 100);
            receiptDisplay.DrawString("$" + subTotal, font, colour, 600, 100);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineSix + "       " + lineTen + " " + "13%", font, colour, 350, 120);
            receiptDisplay.DrawString("$" + taxes.ToString("0.00"), font, colour, 600, 120);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineSeven, font, colour, 350, 180);
            receiptDisplay.DrawString("$" + grandTotal.ToString("0.00"), font, colour, 600, 180);
            Thread.Sleep(500);

            player = new SoundPlayer(Properties.Resources.Dot_Matrix_Printer_SoundBible_com_790333844__1_);
            player.Play();
            receiptDisplay.DrawString(lineEight, font, colour, 350, 200);
            receiptDisplay.DrawString("$" + givenAmount, font, colour, 600, 200);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineNine, font, colour, 350, 240);
            receiptDisplay.DrawString("$" + change.ToString("0.00"), font, colour, 600, 240);
            Thread.Sleep(500);
            receiptDisplay.DrawString("Thank You For Stopping By, " + name, font, colour, 350, 280);


        }

        private void clickF_Click(object sender, EventArgs e)
        {
            receiptDisplay.Clear(Color.SandyBrown);

            textboxO.Text = "";
            textboxT.Text = "";
            textboxTh.Text = "";
            textboxSix.Text = "";
            textboxSe.Text = "";
            blankDisplayO.Text = "";
            blankDisplayT.Text = "";
            blankDisplayTh.Text = "";
            blankDisplayF.Text = "";
            

        }

        private void displayTw_Click(object sender, EventArgs e)
        {
            receiptDisplay.Clear(Color.SandyBrown);

            textboxO.Text = "";
            textboxT.Text = "";
            textboxTh.Text = "";
            textboxSix.Text = "";
            textboxSe.Text = "";
            blankDisplayO.Text = "";
            blankDisplayT.Text = "";
            blankDisplayTh.Text = "";
            blankDisplayF.Text = "";

        }

        private void displayEl_Click(object sender, EventArgs e)
        {
            receiptDisplay.Clear(Color.SandyBrown);

            textboxO.Text = "";
            textboxT.Text = "";
            textboxTh.Text = "";
            textboxSix.Text = "";
            textboxSe.Text = "";
            blankDisplayO.Text = "";
            blankDisplayT.Text = "";
            blankDisplayTh.Text = "";
            blankDisplayF.Text = "";

        }

        private void displayTen_Click(object sender, EventArgs e)
        {
            receiptDisplay.Clear(Color.SandyBrown);

            textboxO.Text = "";
            textboxT.Text = "";
            textboxTh.Text = "";
            textboxSix.Text = "";
            textboxSe.Text = "";
            blankDisplayO.Text = "";
            blankDisplayT.Text = "";
            blankDisplayTh.Text = "";
            blankDisplayF.Text = "";

        }
    }
}
