using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestThread
{
    class Program
    {
        static void Main(string[] args)
        {
            //Il faut créer un objet ParameterizedThreadStart dans le constructeur du thread afin de passer un paramètre.
            Thread th = new Thread(new ParameterizedThreadStart(Afficher));
            Thread th2 = new Thread(new ParameterizedThreadStart(Afficher));

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //Lorsqu'on exécute le thread, on lui donne son paramètre de type Object.
            //th.Start("A");
            //th2.Start("B");
            th.Start(10);
            th2.Start(30);
                        
            sw.Stop(); 
            Console.WriteLine("Le temps passé avec Thread : " + sw.ElapsedMilliseconds);

            Console.WriteLine("");
            Console.WriteLine(""); Console.WriteLine("");
            sw.Start();
            Afficher2(10);
            Afficher2(30);

            sw.Stop();
            Console.WriteLine("Le temps passé sans Thread : " + sw.ElapsedMilliseconds);
            Console.ReadKey();
        }

        //La méthode prend en paramètre un et un seul paramètre de type Object.
        static void Afficher(object texte)
        {
            int somme;
            int val = (int)texte;
            for (int i = 0; i < 10; i++)
            {
                somme = val + i;
                Console.Write(somme);
            }
            Console.WriteLine("");
            Console.WriteLine("<------------Thread {0} terminé----------->", (int)texte);
            
        }

        static void Afficher2(int val)
        {
            int somme;
            for (int i = 0; i < 10; i++)
            {   somme = val + i;
                Console.Write(somme);
            }
            Console.WriteLine("");
            Console.WriteLine("<------------Calcul {0} terminé----------->", val.ToString());

        }
    }
}