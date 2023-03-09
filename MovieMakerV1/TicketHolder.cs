using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMakerV1
{
    class TicketHolder
    {
        //attributes or fields
        private string name;
        private int age;
        private int numberTickets;
        private bool credit;
        //stores the index of the snack that has been ordered
        private List<int> snackOrder = new List<int>();
        private List<int> snackQuantity = new List<int>();
        // stores the index of the drinks that have been ordered
        private List<int> drinkOrder = new List<int>();
        private List<int> drinkQuantity = new List<int>();
      


        //constructor - constructs an object of this class
        public TicketHolder(string name, int age, int nTickets)
        {
            this.name = name;
            this.age = age;
            numberTickets = nTickets;
        }


        //returns the value in the private age variable
        public int GetAge()
        {
            return this.age;
        }
        //Sets the value of the private age variable
        public void SetAge(int newAge)
        {
            this.age = newAge;
        }
        public int GetTickets()
        {
            return numberTickets;
        }
        //get the snack order
        public List<int> GetSnackOrder()
        {
            return snackOrder;
        }
        public List<int> GetSnackQuantity()
        {
            return snackQuantity;
        }
        public List<int> GetDrinkOrder()
        {
            return snackOrder;
        }
        public List<int> GetDrinkQuantity()
        {
            return snackQuantity;
        }
        public void SetCredit(bool newPaymentType)
        {
            credit = newPaymentType;

        }
        //add snacks and quantites to the snackOrder lsit and snackQuantity List 

        public void AddSnack(List<int> snacks, List<int> quantities)
        {
            snackOrder = snacks;
            snackQuantity = quantities;
        }

        //add snacks and quantites to the snackOrder lsit and snackQuantity List 

        public void AddDrink(List<int> snacks, List<int> quantities)
        {
            drinkOrder = snacks;
            drinkQuantity = quantities;
        }
        //returns string stating if the tickewt holder is paying cash or credit

        private string PaymentType()
        {
            string paymentType = "Card";
            if (credit == false)
            {
                paymentType = "Cash";
            }

            return paymentType;
        }

        //returns the total cost for the ticket holder
        public float CalculateTotalCost(List<float> sPrice, List<float> dPrice, float ticketPrice)
        {
            float totalCost = 0f;

            //Loops  through snack order and calculate the cost for each snack
            for (int snackIndex = 0; snackIndex < snackOrder.Count; snackIndex++)
            {
                float snackPrice = sPrice[snackOrder[snackIndex]];
                //add the cost of each snack to totalCost
                totalCost += snackPrice * snackQuantity[snackIndex];
            }




            //Loops  through drink order and calculate the cost for each drink 
            for (int drinkIndex = 0; drinkIndex < drinkOrder.Count; drinkIndex++)
            {
                float drinkPrice = dPrice[drinkOrder[drinkIndex]];
                //add the cost of each snack to totalCost
                totalCost += drinkPrice * drinkQuantity[drinkIndex];
            }

            totalCost += CalculateTicketCost(ticketPrice);

            return totalCost;
        }
        //Calculate ticket cost

        public float CalculateTicketCost(float ticketPrice)
        {
            return numberTickets * ticketPrice;

        }

        //Return a sumary of the drinks and snack order
        private string SnackDrinkSummary(List<string> sList, List<float> sPrices, List<string> dList, List<float> dPrices)
        {
            string summary = "Snacks and Drinks\n";

            //loops through snack order and adds quantity, snack, total item cost to summary
            for (int snackIndex = 0; snackIndex < snackOrder.Count; snackIndex++)
            {
                summary += snackQuantity[snackIndex] + "x" + sList[snackOrder[snackIndex]] + "\t$" + (snackQuantity)[snackIndex] * sPrices[snackOrder[snackIndex]] + "\n";

            }


            for (int drinkIndex = 0; drinkIndex < drinkOrder.Count; drinkIndex++)
            {
                summary += drinkQuantity[drinkIndex] + "x" + dList[drinkOrder[drinkIndex]] + "\t$" + (drinkQuantity)[drinkIndex] * dPrices[drinkOrder[drinkIndex]] + "\n";

            }

            return summary;
        }

        //Check if a surcharge is required
        private bool GetSurecharge()
        {
            return credit;

        }

        //Return string displaying surcharge cost
        private string SurchargeSummary(List<float> sPrice, List<float> dPrice, float ticketPrice)
        {
            string summary = "";

            if (credit)
            {
                summary += "Surcharge\t$" + CalculateSurCharge(sPrice, dPrice, ticketPrice);
            }

            return summary;
        }
        //Return surcharge amount
        private float CalculateSurCharge(List<float> sPrice, List<float> dPrice, float ticketPrice)
        {
            float surcharge = CalculateTotalCost(sPrice, dPrice, ticketPrice) * 0.05f;

            return surcharge;
        }

        //return ticket summary
        private string TicketSummary(float ticketprice)
        {
            return "---------------------\n" + $"{numberTickets} x Tickets \t${CalculateTicketCost(ticketprice)}\n---------------------\n";


        }

        //Calculate the total amount to be payed

        private float CalculateTotalPayment(List<float> sPrice, List<float> dPrice, float ticketPrice)
        {
            float totalPayment = CalculateTotalCost(sPrice, dPrice, ticketPrice);

            if (credit)
            { 
             totalPayment+= CalculateSurCharge(sPrice, dPrice, ticketPrice);

            }

            return totalPayment; 
        }

        //Return a sumary of the total amount to be payed

        private string TotalPaymentSummary(List<float> sPrice, List<float> dPrice, float ticketPrice)
        {
            return "Total\t\t$" + CalculateTotalPayment(sPrice, dPrice, ticketPrice);
        }

        //Returns a string displaying the reciept for the purchasing items
        public string GenerateRecipet(float tPrice, List<string> sList, List<float> sPrices, List<string> dList, List<float> dPrices)
        {


            

            string reciept = $"Name: {name}\nAge: {age}\nPayment Type: {PaymentType()}\n" +
               $"{TicketSummary(tPrice)}\n{SnackDrinkSummary(sList, sPrices, dList, dPrices)}\n" +
               $"{SurchargeSummary(sPrices, dPrices, tPrice)}\n{TotalPaymentSummary(sPrices, dPrices, tPrice)}";



            return reciept;
        }

        //returns a sting collang all the values stored in the private varilabes
        public override string ToString()
        {

        
            return "";
        }

    }
}
