namespace Lord_of_the_Rings
{


    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialisierung
            Hobbit hobbit = new Hobbit();
            string ant;
            Erstes_Abenteuer a1 = new Erstes_Abenteuer();
            a1.eins += a1.OnErstesAbenteuer;
            Zweites_Abenteuer a2 = new Zweites_Abenteuer();
            a2.zwei += a2.OnStart3;
            a1.ab2 = a2;
            Drittes_Abenteuer a3 = new Drittes_Abenteuer();
            a2.ab3 = a3;
            a3.schlechtesEnde += a3.SchlechtesEnde;
            a3.gutesEnde += a3.GutesEnde;
            //Ende


            //Beginn des Abenteuers
            Console.WriteLine("Hello, Abenteurer!");
            Console.Write("Willst Du den Ring ins Feuer werfen? [Y][N]: ");
            ant = Console.ReadLine().ToLower();
            if (ant == "y")
            {
                Console.WriteLine("Und so beginnt es also... ");
                a1.Start(hobbit);
            }
            else
            {
                Console.WriteLine("Ok dann nicht. Cya!");
            }
        }
    }
}