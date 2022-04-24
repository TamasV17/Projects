using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    delegate void TakeoffAttendant(Passenger current, Train currenttrain);
    class Train:IComparable
    {
        public event TakeoffAttendant Takeoff;
        public Train(string name, int space, TakeoffAttendant TakeoffMessage)
        {
            Name = name;
            Space = space;
            passengers = new LinkedList();
            Takeoff = TakeoffMessage;
        }
        
        public string Name { get; set; }
        public int Space { get; set; }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Space.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if ((obj as Train).Name == this.Name && (obj as Train).Space == this.Space)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            if (this.Space<(obj as Train).Space)
            {
                return -1;
            }
            else if (this.Space > (obj as Train).Space)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public LinkedList passengers { get; set; }
        public void Felszallit(Passenger passenger)
        {
            Takeoff?.Invoke(passenger,this);
            passengers.Insert(passenger);
            this.Space = Space - passenger.Space;
        }
    }
}
