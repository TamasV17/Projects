using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    enum JegyTipus{masodosztaly, elsoosztaly, biznisz}
    interface IJegy
    {
        public JegyTipus Tipus { get; set; }
        int Hely { get; set; }
        int Ar { get; set; }
    }
}
