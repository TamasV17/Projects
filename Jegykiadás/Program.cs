using System;

namespace Jegykiadás
{
    class Program
    {
        static Random RND = new Random();
        static void Main(string[] args)
        {
            LinkedList passengers = new LinkedList();
            Train[] trains = new Train[5];
            
            passengers.Ticket_Buy += Buying;
            passengers.Delete_Passenger += Delete;
            Passenger psngr1 = PassengerCreator();
            Passenger DoesNotFit = PassengerCreator();
            DoesNotFit.Space = 999999;
            DoesNotFit.Name = "DoesNotFit";
            Train train1 = TrainCreator();
            Train train2 = TrainCreator();
            Train train3 = TrainCreator();
            Train train4 = TrainCreator();
            Train train5 = TrainCreator();
            trains[0] = train1; 
            trains[1] = train2; 
            trains[2] = train3;
            trains[3] = train4;
            trains[4] = train5;
            TrainSort(trains);

            passengers.Insert(psngr1);
            passengers.Delete(psngr1);
            //passengers.Insert(DoesNotFit);
            passengers.Insert(PassengerCreator());
            passengers.Insert(PassengerCreator());
            passengers.Insert(PassengerCreator());
            passengers.Insert(PassengerCreator());
            passengers.Insert(PassengerCreator());
            passengers.Insert(PassengerCreator());
            passengers.Insert(PassengerCreator());
            passengers.Insert(PassengerCreator());
            passengers.Insert(PassengerCreator());
            Passenger[] passengersArray = passengers.ToArray();
            PassengerSort(passengersArray);
            Transportage(passengersArray, trains);
            Sy_CouldntTakeOff(passengersArray);

        }
        static void Buying(Passenger passenger)
        {
            Console.WriteLine($"[INFO] Vonatjegyvásárlás történt! Név: {passenger.Name}, {passenger.Type} osztályú.");
        }
        static void Delete(Passenger passenger)
        {
            Console.WriteLine($"[INFO] Utastörlés történt! Név: {passenger.Name}, {passenger.Type} osztályú.");
        }
        static void TakeOff(Passenger passenger, Train vonat)
        {
            Console.WriteLine($"[INFO] Felszállt a nevű: {passenger.Name},passenger az alábbi vonatra: {vonat.Name}");
        }
        public static TicketType GenerateTicketType()
        {
            switch (RND.Next(0,3))
            {
                case 0: return TicketType.secondClass;
                case 1: return TicketType.firstClass;
                default: return TicketType.businessClass;                 
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
        public static string GenerateDestination()
        {
            string[] dDestination = new string[10] {"Budapest", "Pécs", "Miskolc","Gyöngyös", "Zamárdi", "Nyíregyháza", "Debrecen", "Veszprém", "Gyula", "Sopron"};
            return dDestination[RND.Next(0, dDestination.Length)];
        }
        public static Passenger PassengerCreator()
        {
            Passenger passenger = null;
            TicketType temp = GenerateTicketType();
                passenger = new Passenger(GenerateDestination(), GenerateName(), (int)temp, temp);            
            return passenger;
        }
        public static Train TrainCreator()
        {
            string[] tNames = new string[5] {"Baranya IC", "Tenkes IC", "Balaton IC", "Heves IC", "Békés IC"};
            return new Train(tNames[RND.Next(0, tNames.Length)], RND.Next(30,101), TakeOff);
        }

        public static void TrainSort(Train[] trains)
        {
            Array.Sort(trains); 
        }
        public static void PassengerSort(Passenger[] passengers)
        {
            Array.Sort(passengers);
        }
        public static void Transportage(Passenger[] passengers, Train[] trains)
        {
            for (int i = 0; i < passengers.Length; i++)
            {
                bool stoodup = false;
                int j = 0;
                while (j<trains.Length && !stoodup)
                {
                    if (trains[j].Space>= passengers[i].Space)
                    {
                        trains[j].Felszallit(passengers[i]);
                        passengers[i] = null;
                        stoodup = true;
                    }
                    j++;
                }
                TrainSort(trains);
            }
        }
        public static void Sy_CouldntTakeOff(Passenger[] passengers) 
        {
            //A tömbbe, ahoz az i-edik érték NEM NULL ott az adott passenger nem tudott felszállni, így rá kivételt kellene dobni!
            for (int i = 0; i < passengers.Length; i++)
            {
                if (passengers[i] is not null)
                {
                    throw new CouldntTakeOffException(passengers[i]);
                }
            }
        }
    }
}
