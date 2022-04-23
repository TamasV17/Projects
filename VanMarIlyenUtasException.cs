using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    class VanMarIlyenUtasException:Exception
    {
        public override string Message { get; }
        public VanMarIlyenUtasException(string e)
        {
            Message = $"[HIBA] Nem lehet mégegyszer hozzáadni ezt az utast! Utas neve: "+e;
        }
    }
}
