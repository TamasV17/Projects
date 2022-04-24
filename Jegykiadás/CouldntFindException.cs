using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    class CouldntFindException:Exception
    {
        public override string Message { get; }
        public CouldntFindException()
        {
            Message = $"[ERROR] Couldn't find a passenger with this name!";
        }
    }
}
