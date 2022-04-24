using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    enum TicketType{secondClass, firstClass, businessClass}
    interface ITicket
    {
        public TicketType Type { get; set; }
        int Space { get; set; }
        int Price { get; set; }
    }
}
