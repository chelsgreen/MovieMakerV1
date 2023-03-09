using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMakerV1
{
    class Program
    {
        static void Main(string[] args)
        {

        //stores the index of the snack that has been ordered
         List<int> snackOrder = new List<int>();
         List<int> snackQuantity = new List<int>();
        // stores the index of the drinks that have been ordered
         List<int> drinkOrder = new List<int>();
         List<int> drinkQuantity = new List<int>();

        List<string> availableSnacks = new List<string>() { "Popcorn", "Chips", "Chocolate" };
            List<float> snackPrices = new List<float>() { 2.5f, 1.5f, 2f  };
            List<string> availableDrinks =new List<string>() { "Fanta", "L&P    " };
            List<float> snackDrinks =new List<float>() { 2.5f, 1.5f  };
            List<float> drinkPrices = new List<float>() { 2.5f, 1.5f };
            
            float tPrice = 5f;
            Console.WriteLine("------------------ Ticket Holder Testing -----------------\n\n");
            TicketHolder testTH = new TicketHolder("Charlie", 18, 3);

            List<int> s = new List<int>() { 0 , 2 };
            List<int> sq = new List<int>() { 2, 1 };
            testTH.AddSnack(s, sq);

            List<int> d = new List<int>() {1};
            List<int> dq = new List<int>() { 2 };

            testTH.AddDrink(d, dq);

            testTH.SetAge(18);

            testTH.SetCredit(true);
            
            Console.WriteLine(testTH.GenerateRecipet(tPrice, availableSnacks, snackPrices , availableDrinks, drinkPrices));
            Console.WriteLine("----------------- Ticket Manager Testing -----------------\n\n");

            TicketManger tm = new TicketManger();

            string name = "Charlie";
            int age = 12;
            int tickets = 150;

            if (tm.CheckAge(age, 0))
            {
                if (tm.CheckAvailableSeats(tickets))
                {
                    tm.AddTicketHolder(new TicketHolder(name, age, tickets));
                }
                else
                {
                    Console.WriteLine($"There are only {tm.CalculateAvailableSeats()} ticket available");
                }
            }
            else 
            {
                Console.WriteLine("You are too young to watch this movie");
            }

            tm.AddSnacksDrinkOrder(s, sq,d, dq);

            Console.WriteLine($"Total Seats sold: {tm.GetSeatLimit() - tm.CalculateAvailableSeats()}");


            Console.ReadLine();
        }
    }
}
