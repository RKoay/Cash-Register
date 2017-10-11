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


namespace Cash_Register
{
    public partial class mainDisplay : Form
    {
        public mainDisplay()
        {
            InitializeComponent();
        }

        //global variables
        const double BURGERCOST = 2.49;
        const double FRIESCOST = 1.89;
        const double DRINKSCOST = 0.99;
        const double TAXRATIO = 0.13;

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

        private void clickO_Click(object sender, EventArgs e)
        {
            burgerAmount = Convert.ToInt16(textboxO.Text);
            friesAmount = Convert.ToInt16(textboxT.Text);
            drinksAmount = Convert.ToInt16(textboxTh.Text);
            totalBurgerCost = burgerAmount * BURGERCOST;
            totalBurgerCost.ToString("C");
            totalFriesCost = friesAmount * FRIESCOST;
            totalFriesCost.ToString("C");
            totalDrinksCost = drinksAmount * DRINKSCOST;
            totalDrinksCost.ToString("C");
            subTotal = totalBurgerCost + totalFriesCost + totalDrinksCost;
            blankDisplayO.Text = subTotal.ToString("C");

            taxes = TAXRATIO * subTotal;
            blankDisplayT.Text = taxes.ToString("C");

            grandTotal = taxes + subTotal;
            grandTotal.ToString("C");
            blankDisplayTh.Text = grandTotal.ToString("C");
        }

        private void clickT_Click(object sender, EventArgs e)
        {
            givenAmount = Convert.ToInt16(textboxSe.Text);
            givenAmount.ToString("0.00");
            change = givenAmount - grandTotal;
            change.ToString("C");
            blankDisplayF.Text = change.ToString("C");

        }

        private void clickTh_Click(object sender, EventArgs e)
        {

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

            Graphics receiptDisplay = this.CreateGraphics();
            Font font = new Font("consolas", 12, FontStyle.Underline);
            SolidBrush colour = new SolidBrush(Color.Black);
            receiptDisplay.DrawString(lineOne, font, colour, 370, 20);
            Thread.Sleep(500);
            font = new Font("consolas", 12);
            receiptDisplay.DrawString(lineTwo + " x" + burgerAmount + lineTen + " $" + BURGERCOST + lineEleven, font, colour, 350, 40);
            receiptDisplay.DrawString("$" + totalBurgerCost, font, colour, 600, 40);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineThree + " x" + friesAmount + lineTen + " $" + FRIESCOST + lineEleven, font, colour, 350, 60);
            receiptDisplay.DrawString("$" + totalFriesCost, font, colour, 600, 60);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineFour + " x" + drinksAmount + lineTen + " $" + DRINKSCOST + lineEleven, font, colour, 350, 80);
            receiptDisplay.DrawString("$" + totalDrinksCost, font, colour, 600, 80);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineFive, font, colour, 350, 100);
            receiptDisplay.DrawString("$" + subTotal, font, colour, 600, 100);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineSix, font, colour, 350, 120);
            receiptDisplay.DrawString("$" + taxes, font, colour, 600, 120);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineSeven, font, colour, 350, 180);
            receiptDisplay.DrawString("$" + grandTotal, font, colour, 600, 180);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineEight, font, colour, 350, 200);
            receiptDisplay.DrawString("$" + givenAmount, font, colour, 600, 200);
            Thread.Sleep(500);
            receiptDisplay.DrawString(lineNine, font, colour, 350, 240);
            receiptDisplay.DrawString("$" + change, font, colour, 600, 240);


        }
    }
}
