using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    class PassengerExistsException:Exception
    {
        public override string Message { get; }
        public PassengerExistsException(string e)
        {
            Message = $"[ERROR] We can't add on severeal occasions this passenger ! Passengers name: "+e;
        }
    }
}
