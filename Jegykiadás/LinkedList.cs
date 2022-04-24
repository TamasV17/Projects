using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    delegate void PassengerAttendant(Passenger pngr);
    class LinkedList
    {
        public event PassengerAttendant Ticket_Buy;
        public event PassengerAttendant Delete_Passenger;



        public void TB_Happened(object sender)
        {
            Ticket_Buy?.Invoke(sender as Passenger);
        }
        public void PD_Happened(object sender)
        {
            Delete_Passenger?.Invoke(sender as Passenger);
        }
        private LinkedListElement head;
        #region Insert
        public void Insert(Passenger passengers)
        {
            LinkedListElement a = new LinkedListElement();
            a.Data = passengers;

            LinkedListElement current = head;
            LinkedListElement prev = null;

            while (current != null && a.Data.Name.CompareTo(current.Data.Name) > 0)
            {
                prev = current;
                current = current.Next;
            }
            if (current != null && a.Data.Name.CompareTo(current.Data.Name) == 0)
            {
                throw new PassengerExistsException(passengers.Name);
            }            
            else
            {
                if (prev == null)
                {
                    head = a;
                    a.Next = current;
                }
                else
                {
                    prev.Next = a;
                    a.Next = current;
                }
            }
            TB_Happened(passengers);
        }
        #endregion

        #region Delete
        public void Delete(Passenger name)
        {
            LinkedListElement current = head;
            LinkedListElement t = null;
            while (current != null && !(current.Data.GetHashCode().Equals(name.GetHashCode())))
            {
                t = current;
                current = current.Next;
            }
            if (current != null)
            {
                if (t == null)
                {
                    head = current.Next;
                }
                else
                {
                    t.Next = current.Next;
                }
            }
            else
            {
                throw new CouldntFindException();
            }
            PD_Happened(name);
        }
        #endregion

        #region Filteration
        public LinkedList Filteration(Passenger passenger)
        {
            LinkedListElement current = head;
            LinkedList newList = new LinkedList();
            while (current != null)
            {
                if (current.Data.Space == passenger.Space || current.Data.Price == passenger.Price || current.Data.Destination==passenger.Destination)
                {
                    newList.Insert(current.Data);
                }
                current = current.Next;
            }
            return newList;
        }
        #endregion

        public void Bejaras(ref List<Passenger> list)
        {
            LinkedListElement current = head;
            while (current!=null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
        }
        public Passenger[] ToArray()
        {
            List<Passenger> passList = new List<Passenger>();
            Bejaras(ref passList);
            return passList.ToArray();
        }
    }
}
