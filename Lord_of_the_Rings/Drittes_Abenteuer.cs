namespace Lord_of_the_Rings
{
    internal class Drittes_Abenteuer
    {
        public event EventHandler<EventArgs> schlechtesEnde;
        public event EventHandler<EventArgs> gutesEnde;
        public event EventHandler<EventArgs> kampf;
        public string NameD { get; set; } = "Schicksalsberg";
        public Hobbit Frodo { get; set; }
        private Random random = new Random();
        public Ork Orks { get; set; } = new Ork();
        public int Ring { get; set; } = 0;
        private int i = 0;

        public void Start3(Hobbit h)
        {
            Thread.Sleep(2000);
            Console.Clear();
            Frodo = h;
            Console.WriteLine("Du mußt Dich durch die schier Endlosen Ork und Urukai Horden schleichen!");
            Console.WriteLine("Ziehst Du den einen Ring an sieht man Dich nicht. Trägst Du Ihn länger sieht Dich das Auge!");
            Thread.Sleep(2000);
            Schleichen();
        }

        public void Schleichen()
        {
            int anzo, anzu, anzp;
            anzo = random.Next(0, 51);
            anzu = random.Next(0, 51);
            anzp = anzu + anzo;
            Console.Clear();
            Console.WriteLine($"Deinen Weg blockieren {anzo} Orks und {anzu} Urukai. Insgesamt also {anzp} mal schleichen!");
            Thread.Sleep(1000);
            for (i = 1; i < anzp + 1; i++)
            {
                int w20 = random.Next(1, 21);
                if (w20 < 15)
                {
                    Console.WriteLine($"Du konntest am {i}sten vorbeischleichen. Weiter gehts! Du hast noch {anzp - i} Orks vor Dir");
                }
                else
                {
                    string ant;
                    Console.Write("Sie haben Dich bemerkt! Willst Du kämpfen oder den Ring nutzen? [K] [R]: ");
                    ant = Console.ReadLine().ToLower();
                    if (ant == "k")
                    {

                        Console.WriteLine("Du stellt Dich dem Ork! Der kampf beginnt!");
                        while (Frodo.Leben > 0 && Orks.Leben > 0)
                        {

                            int atkf, atko, paf, pao, fs, os;
                            atkf = random.Next(1, 21);
                            atko = random.Next(1, 21);
                            paf = random.Next(1, 21);
                            pao = random.Next(1, 21);
                            fs = random.Next(1, 7);
                            os = random.Next(1, 5);


                            if (atkf < 15)
                            {
                                Console.WriteLine("Dein Angriff trifft! ");
                                Thread.Sleep(3000);
                                if (pao < 10)
                                {
                                    Console.WriteLine("Der Ork parriert! Keinen Schaden verursacht.");
                                    Thread.Sleep(2000);
                                }
                                else
                                {
                                    Orks.Leben -= fs;
                                    Console.WriteLine($"Der Angriff geht durch. Du verursachst {fs} schaden am Ork. Er hat noch {Orks.Leben}");
                                    Thread.Sleep(3000);
                                }
                            }
                            else if (atko < 10)
                            {
                                Console.WriteLine("Der Ork trifft Dich");
                                Thread.Sleep(3000);
                                if (paf < 10)
                                {
                                    Console.WriteLine("Du parrierst! Keinen Schaden verursacht.");
                                    Thread.Sleep(2000);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Frodo.Leben -= fs;
                                    Console.WriteLine($"Der Angriff geht durch. Der Ork verursacht {fs} schaden an Dir! Du hast noch  {Frodo.Leben}");
                                    Thread.Sleep(3000);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ihr habt Euch verfehlt. Nächste Runde!");
                                Thread.Sleep(2000);
                            }
                            Console.Clear();
                        }
                        if (Frodo.Leben == 0)
                        {
                            schlechtesEnde(this, EventArgs.Empty);
                        }
                        else
                        {
                            Console.WriteLine("Du hast gesiegt. Weiter geht es! ");
                            Thread.Sleep(1000);
                        }


                    }
                    else
                    {
                        Ring += 10;
                        Console.WriteLine("Du ziehst den Ring an und schleichst vorbei!");
                        Thread.Sleep(1000);
                    }

                }
                if (Ring == 50)
                {
                    Console.WriteLine("Das Auge wird aufmerksam. Gib acht!");
                    Thread.Sleep(1000);
                }
                if (Ring > 100)
                {
                    Console.WriteLine("Das alles sehende Auge hat Dich entdeckt. Dein Schicksal ist besiegelt! ");
                    schlechtesEnde(this, EventArgs.Empty);
                    break;
                }

                Thread.Sleep(1000);
                if (i % 5 == 0)
                {
                    Console.Clear();

                }
            }
            if (Ring < 100)
            {
                gutesEnde(this, EventArgs.Empty);

            }
        }


        public void SchlechtesEnde(object quelle, EventArgs e)
        {
            Console.WriteLine("Sauron hat den Ring wieder. Du hast es vermasselt!");
        }

        public void GutesEnde(object quelle, EventArgs e)
        {
            Console.WriteLine("Der Ring ist verbrannt. Das gute hat wiedereinmal gesiegt!");
        }
    }
}


