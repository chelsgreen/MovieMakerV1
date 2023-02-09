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
        private int numberTickets;
        private bool credit;
        private List<string> snakcOrder = new List<string>();
        private List<int> snakcQuantity = new List<int>();
        private List<string> drinkOrder = new List<string>();
        private List<int> drinkQuantity = new List<int>();

        //constructor - constructs an object of this class
        public TicketHolder()
        { 
            
        }

        //return the value in the private age varilable 
        public int GetAge()
        {
            return 0;
        }
        //Sets the valuce of the private age varilable
        public void SetAge(int newAge)
        { 
        
        }

        //returns the total cost for the ticket holder
        public float CalculateTotalCost()
        {
            return 0.0f;
        }

        //Returns a string displaying the reciept for the purchasing items
        public string GenerateRecipet()
        {
            return "";
        }

        //returns a sting collang all the values stored in the private varilabes
        public override string ToString()
        {

        
            return "";
        }

    }
}
