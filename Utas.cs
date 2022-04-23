using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    class Utas : IJegy, IComparable
    {
        public Utas(string uticel,string neve, int hely, JegyTipus jegytipus)
        {
            Uticel = uticel;
            this.Neve = neve;
            Hely = hely;
            int lenght = Uticel.Length;
            Ar = lenght*Hely;
            switch (jegytipus)
            {
                case JegyTipus.masodosztaly: 
                    Hely = 1;
                    break;
                case JegyTipus.elsoosztaly:
                    Hely = 3;
                    break;
                case JegyTipus.biznisz:
                    Hely = 6;
                    break;
            }
        }

        public int Hely { get ; set ; }
        public int Ar { get ; set ; }
        public string Uticel { get; set; }
        public string Neve { get; set; }
        public JegyTipus Tipus { get ; set ; }


        public int CompareTo(object obj)
        {
            if (this.Hely < (obj as Utas).Hely)
            {
                return 1;
            }
            else if (this.Hely > (obj as Utas).Hely)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
