using System;

namespace Jegykiadás
{
    class Program
    {
        static Random RND = new Random();
        static void Main(string[] args)
        {
            LancoltLista utasok = new LancoltLista();
            Vonat[] vonatok = new Vonat[3];
            
            utasok.JegyVasarlas += Vasarlas;
            utasok.UtasTorles += Torles;
            Utas utas1 = UtasCreator();
            Utas NemFerSehova = UtasCreator();
            NemFerSehova.Hely = 999999;
            NemFerSehova.Neve = "Nem Fér Sehova Szándékosan";
            Vonat vonat1 = VonatCreator();
            Vonat vonat2 = VonatCreator();
            Vonat vonat3 = VonatCreator();
            vonatok[0] = vonat1; 
            vonatok[1] = vonat2; 
            vonatok[2] = vonat3;
            VonatRendezes(vonatok);

            utasok.Beszuras(utas1);
            utasok.Torles(utas1);
            utasok.Beszuras(NemFerSehova);
            utasok.Beszuras(UtasCreator());
            utasok.Beszuras(UtasCreator());
            utasok.Beszuras(UtasCreator());
            utasok.Beszuras(UtasCreator());
            utasok.Beszuras(UtasCreator());
            utasok.Beszuras(UtasCreator());
            utasok.Beszuras(UtasCreator());
            utasok.Beszuras(UtasCreator());
            utasok.Beszuras(UtasCreator());
            Utas[] utasokTomb = utasok.ToArray();
            UtasRendezes(utasokTomb);
            VonatraSzallitas(utasokTomb, vonatok);
            NemTudtakFelszallni(utasokTomb);

        }
        static void Vasarlas(Utas utas)
        {
            Console.WriteLine($"[INFO] Vonatjegyvásárlás történt! Név: {utas.Neve}, {utas.Tipus} osztályú.");
        }
        static void Torles(Utas utas)
        {
            Console.WriteLine($"[INFO] Utastörlés történt! Név: {utas.Neve}, {utas.Tipus} osztályú.");
        }
        static void Felszallas(Utas utas, Vonat vonat)
        {
            Console.WriteLine($"[INFO] Felszállt a nevű: {utas.Neve},utas az alábbi vonatra: {vonat.Nev}");
        }
        public static JegyTipus GenerateJegyTipus()
        {
            switch (RND.Next(0,3))
            {
                case 0: return JegyTipus.masodosztaly;
                case 1: return JegyTipus.elsoosztaly;
                default: return JegyTipus.biznisz;                 
            }
        }
        public static string GenerateName()
        {
            string FirstName = "";
            string LastName = "";
           
            string[] lastNames = new string[10] { "Kovács", "Varga", "Kolompár", "Rézműves", "Kerekes", "Tóth", "Kosár", "Arany", "Rácz", "Juhász" };
            string[] FfemaleNames = new string[20] { "Dóra", "Virág", "Adél", "Cintia", "Ágnes", "Andrea", "Ilonka", "Irén", "Anna", "Bíborka", "Boglárka", "Evelin", "Margit", "Helga", "Nóra", "Gyopár", "Bianka", "Kamilla", "Napsugár", "Gyöngyvirág" };
            string[] FmaleNames = new string[20] {"János", "Ödön", "István", "Gergely", "Áron","Ákos", "Tamás", "Károly", "Árpád", "Viktor", "Soma", "Bálint", "Tihamér", "Tivadar", "Gyula", "Miklós", "Kevin", "Ferenc", "Jácint", "Géza" };

            if (RND.Next(1, 2) == 1)
            {
                FirstName = FmaleNames[RND.Next(0, FmaleNames.Length - 1)];
                LastName = lastNames[RND.Next(0, lastNames.Length - 1)];
            }
            else
            {
                FirstName = FfemaleNames[RND.Next(0, FfemaleNames.Length - 1)];
                LastName = lastNames[RND.Next(0, lastNames.Length - 1)];
            }
            string compNAME = LastName +" "+ FirstName;
            return compNAME;
        }
        public static string GenerateUticel()
        {
            string[] uticel = new string[10] {"Budapest", "Pécs", "Miskolc","Gyöngyös", "Zamárdi", "Nyíregyháza", "Debrecen", "Veszprém", "Gyula", "Sopron"};
            return uticel[RND.Next(0, uticel.Length)];
        }
        public static Utas UtasCreator()
        {
            Utas utas = null;
            JegyTipus idg = GenerateJegyTipus();
                utas = new Utas(GenerateUticel(), GenerateName(), (int)idg, idg);            
            return utas;
        }
        public static Vonat VonatCreator()
        {
            string[] vNevek = new string[5] {"Baranya IC", "Tenkes IC", "Balaton IC", "Heves IC", "Békés IC"};
            return new Vonat(vNevek[RND.Next(0, vNevek.Length)], RND.Next(30,101), Felszallas);
        }

        public static void VonatRendezes(Vonat[] vonatok)
        {
            Array.Sort(vonatok); 
        }
        public static void UtasRendezes(Utas[] utasok)
        {
            Array.Sort(utasok);
        }
        public static void VonatraSzallitas(Utas[] utasok, Vonat[] vonatok)
        {
            for (int i = 0; i < utasok.Length; i++)
            {
                bool felultetve = false;
                int j = 0;
                while (j<vonatok.Length && !felultetve)
                {
                    if (vonatok[j].Ferohely>= utasok[i].Hely)
                    {
                        vonatok[j].Felszallit(utasok[i]);
                        utasok[i] = null;
                        felultetve = true;
                    }
                    j++;
                }
                VonatRendezes(vonatok);
            }
        }
        public static void NemTudtakFelszallni(Utas[] utasok) 
        {
            //A tömbbe, ahoz az i-edik érték NEM NULL ott az adott utas nem tudott felszállni, így rá kivételt kellene dobni!
            for (int i = 0; i < utasok.Length; i++)
            {
                if (utasok[i] is not null)
                {
                    throw new NemTudottFelszallniException(utasok[i]);
                }
            }
        }
    }
}
