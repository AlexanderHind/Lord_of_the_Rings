using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lord_of_the_Rings
{
    internal class Zweites_Abenteuer
    {
        public event EventHandler<EventArgs> zwei;
        public string Krankra { get; set; }
        public Drittes_Abenteuer ab3 { get; set; }
        public int Leben { get; set; } = 100;
        private Random random = new Random();
        public Hobbit Frodo { get; set; }
        public void Start2(Hobbit a)
        {
            Console.WriteLine("Willkommen in deinem zweiten Abenteuer. Du mußt gegen die Spinne Kankra kämpfen");
            Thread.Sleep(1000);
            Kampf(a);
        }

        public void Kampf(Hobbit h)
        {
            Frodo = h;
                Console.WriteLine("Der Kampf tobt!");
            Thread.Sleep(1000);
            while (Frodo.Leben >= 0 && Leben >=0)
            {
                
                int hob, spin;
                hob = random.Next(1, 21);
                spin = random.Next(1, 21);
                Console.WriteLine($"Du hast eine {hob} gewürfelt. Sie eine {spin} ");
                Thread.Sleep(1000);
                if (hob > 13)
                {
                        int sch = random.Next(1,50);
                    Leben -= sch;
                    Console.WriteLine($"Du hast getroffen und {sch} Schaden an Kankra ausgeteilt. Sie hat noch {Leben} Leben");
                    Thread.Sleep(1000);
                }
                else if (spin < 13)
                {
                    int sch = random.Next(1, 6);
                    Frodo.Leben -= sch;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Krankra hat Dich getroffen für {sch} Schaden. Du hast noch {h.Leben} Leben!");
                    Thread.Sleep(1000);
                    Console.ForegroundColor= ConsoleColor.Gray;
                }
            }
            if (h.Leben ==0)
            {
                Console.WriteLine("Dein Abenteuer endet hier .... R.I.P.");
                Thread.Sleep (2000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Du hast das grässliche Biest besiegt! Weiter gehts zum Schicksalsberg!");
                Thread.Sleep(2000);
            zwei(this,EventArgs.Empty);
            }

        }
        public void OnStart3(object quelle, EventArgs e)
        {
            if (quelle != null)
            {
                ab3.Start3(Frodo);
            }
        }
    }
}
