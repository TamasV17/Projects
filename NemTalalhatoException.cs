using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    class NemTalalhatoException:Exception
    {
        public override string Message { get; }
        public NemTalalhatoException()
        {
            Message = $"[HIBA] Nem található ez a nevű utas!";
        }
    }
}
