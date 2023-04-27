using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lord_of_the_Rings
{
    internal class Erstes_Abenteuer
    {
    public event EventHandler<EventArgs> eins;
        private Random random = new Random();
        public Zweites_Abenteuer ab2 { get; set; }
        public int Punkte { get; set; }
        public string NameA { get; set; } = "Bloß raus aus Hobbingen!";
        private Hobbit hobbit;

        public void Start(Hobbit h)
        {
            hobbit = h;
            while (Punkte < 10)
            {
            Console.WriteLine("Willkommen in Hobbingen! Dein Weg aus dem Auenland wird nicht leicht. ");
            Console.Write("Du hast die Wahl. Links [L] Rechts [R] : ");
            string ant=Console.ReadLine().ToLower();
            int weg = random.Next(1,3);
                if (ant == "l" && weg == 1)
                {
                    Punkte++;
                    Console.WriteLine($"Du hast den Richtigen Weg gewählt! Es sind noch {10-Punkte} Km zu gehen. ");
                }
                else if (ant == "r" && weg == 2)
                {
                    Console.WriteLine($"Du hast den Richtigen Weg gewählt!Es sind noch {10-Punkte} Km zu gehen. ");
                    Punkte++;
                }
                else
                {
                    Console.WriteLine("Leider Falsch.");
                }
               
            }
            Console.WriteLine("Du hast den Weg aus dem Auenland gefunden! Weiter gehts!");
            eins(this , EventArgs.Empty);
        }
        public void OnErstesAbenteuer(object quelle, EventArgs e)
        {
            if (quelle != null)
            {
               ab2.Start2(hobbit);
            }
        }
    }
}
