using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    class NemTudottFelszallniException:Exception
    {
        public NemTudottFelszallniException(Utas utas) : base($"[HIBA] {utas.Neve} nevű utas már nem tudott felszállni!")
        {

        }
    }
}
