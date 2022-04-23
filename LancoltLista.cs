using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegykiadás
{
    delegate void UtasKezelo(Utas current);
    class LancoltLista
    {
        public event UtasKezelo JegyVasarlas;
        public event UtasKezelo UtasTorles;



        public void VasarlasTortent(object sender)
        {
            JegyVasarlas?.Invoke(sender as Utas);
        }
        public void UtasTorlesTortent(object sender)
        {
            UtasTorles?.Invoke(sender as Utas);
        }
        private LancoltListaElem fej;
        #region Beszuras
        public void Beszuras(Utas utasok)
        {
            LancoltListaElem uj = new LancoltListaElem();
            uj.Adatok = utasok;

            LancoltListaElem aktualis = fej;
            LancoltListaElem elozo = null;

            while (aktualis != null && uj.Adatok.Neve.CompareTo(aktualis.Adatok.Neve) > 0)
            {
                elozo = aktualis;
                aktualis = aktualis.Kovetkezo;
            }
            if (aktualis != null && uj.Adatok.Neve.CompareTo(aktualis.Adatok.Neve) == 0)
            {
                throw new VanMarIlyenUtasException(utasok.Neve);
            }            
            else
            {
                if (elozo == null)
                {
                    fej = uj;
                    uj.Kovetkezo = aktualis;
                }
                else
                {
                    elozo.Kovetkezo = uj;
                    uj.Kovetkezo = aktualis;
                }
            }
            VasarlasTortent(utasok);
        }
        #endregion

        #region Torles
        public void Torles(Utas nev)
        {
            LancoltListaElem aktualis = fej;
            LancoltListaElem t = null;
            while (aktualis != null && !(aktualis.Adatok.GetHashCode().Equals(nev.GetHashCode())))
            {
                t = aktualis;
                aktualis = aktualis.Kovetkezo;
            }
            if (aktualis != null)
            {
                if (t == null)
                {
                    fej = aktualis.Kovetkezo;
                }
                else
                {
                    t.Kovetkezo = aktualis.Kovetkezo;
                }
            }
            else
            {
                throw new NemTalalhatoException();
            }
            UtasTorlesTortent(nev);
        }
        #endregion

        #region Szures/Listazas
        public LancoltLista Szures(Utas utas)
        {
            LancoltListaElem aktualis = fej;
            LancoltLista ujLista = new LancoltLista();
            while (aktualis != null)
            {
                if (aktualis.Adatok.Hely == utas.Hely || aktualis.Adatok.Ar == utas.Ar || aktualis.Adatok.Uticel==utas.Uticel)
                {
                    ujLista.Beszuras(aktualis.Adatok);
                }
                aktualis = aktualis.Kovetkezo;
            }
            return ujLista;
        }
        #endregion

        public void Bejaras(ref List<Utas> lista)
        {
            LancoltListaElem aktualis = fej;
            while (aktualis!=null)
            {
                lista.Add(aktualis.Adatok);
                aktualis = aktualis.Kovetkezo;
            }
        }
        public Utas[] ToArray()
        {
            List<Utas> utasLista = new List<Utas>();
            Bejaras(ref utasLista);
            return utasLista.ToArray();
        }
    }
}
