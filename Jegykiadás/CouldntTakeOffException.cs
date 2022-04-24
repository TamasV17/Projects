using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    class CouldntTakeOffException:Exception
    {
        public CouldntTakeOffException(Passenger passenger) : base($"[ERROR] passenger {passenger.Name} couldn't take-off to the train!")
        {

        }
    }
}
