using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    delegate void FelszallasKezelo(Utas current, Vonat currenttrain);
    class Vonat:IComparable
    {
        public event FelszallasKezelo Felszall;
        public Vonat(string nev, int ferohely, FelszallasKezelo FelszalloUzenet)
        {
            Nev = nev;
            Ferohely = ferohely;
            utasok = new LancoltLista();
            Felszall = FelszalloUzenet;
        }
        
        public string Nev { get; set; }
        public int Ferohely { get; set; }
        public override int GetHashCode()
        {
            return Nev.GetHashCode() ^ Ferohely.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if ((obj as Vonat).Nev == this.Nev && (obj as Vonat).Ferohely == this.Ferohely)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            if (this.Ferohely<(obj as Vonat).Ferohely)
            {
                return -1;
            }
            else if (this.Ferohely > (obj as Vonat).Ferohely)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public LancoltLista utasok { get; set; }
        public void Felszallit(Utas utas)
        {
            Felszall?.Invoke(utas,this);
            utasok.Beszuras(utas);
            this.Ferohely = Ferohely - utas.Hely;
        }
    }
}
