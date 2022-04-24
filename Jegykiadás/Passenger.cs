using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    class Passenger : ITicket, IComparable
    {
        public Passenger(string destination,string name, int space, TicketType tickettype)
        {
            Destination = destination;
            this.Name = name;
            Space = space;
            int lenght = Destination.Length;
            Price = lenght*Space;
            switch (tickettype)
            {
                case TicketType.secondClass: 
                    Space = 1;
                    break;
                case TicketType.firstClass:
                    Space = 3;
                    break;
                case TicketType.businessClass:
                    Space = 6;
                    break;
            }
        }

        public int Space { get ; set ; }
        public int Price { get ; set ; }
        public string Destination { get; set; }
        public string Name { get; set; }
        public TicketType Type { get ; set ; }


        public int CompareTo(object obj)
        {
            if (this.Space < (obj as Passenger).Space)
            {
                return 1;
            }
            else if (this.Space > (obj as Passenger).Space)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
