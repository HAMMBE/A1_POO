using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2;
using TP2.VaisseauEnfant;

namespace TP2
{
    class SpaceInvaders
    {
        public Joueur joueur1;
        public Armurerie armurerie;
        public List<Vaisseau> ennemies;

        public SpaceInvaders()
        {
            Init();
        }

        private void Init()
        {
            //Creation des joueurs
            this.joueur1 = new Joueur("Benjamin", "Hamm", "ESAqua");

            //Creation des ennemies
            ennemies = new List<Vaisseau>();
            ennemies.Add(new B_Wings());
            ennemies.Add(new Dart());
            ennemies.Add(new F_18());
            ennemies.Add(new Rocinante());
            ennemies.Add(new Tardis());

        }

        public void Tour()
        {

        }


        static void Main(string[] args)
        {
            SpaceInvaders jeu = new SpaceInvaders();
            Console.WriteLine(jeu.joueur1.ToString());

            foreach (var j in jeu.ennemies)
            {
                Console.WriteLine(j.ToString());
            }

            while(jeu.ennemies.Count() != 0 && jeu.joueur1.vaisseau.EstDetruit() == false)
            {
                Random alea = new Random();
                int indice = 1;
                bool ajouer = false;
                if (indice >= alea.Next(indice, jeu.ennemies.Count()))
                {
                    jeu.joueur1.vaisseau.Attaque(jeu.ennemies[alea.Next(1, jeu.ennemies.Count())]);
                    ajouer = true;
                }
                    foreach (Vaisseau v in jeu.ennemies)
                    {

                        v.Attaque(jeu.joueur1.vaisseau);
                        Console.WriteLine(jeu.joueur1.vaisseau.ToString());
                    if (jeu.joueur1.vaisseau.EstDetruit())
                    {
                        break;
                    }

                    }
                if (!ajouer && jeu.joueur1.vaisseau.EstDetruit() == false)
                {
                    jeu.joueur1.vaisseau.Attaque(jeu.ennemies[alea.Next(1, jeu.ennemies.Count())]);
                }
            }
        }
    }
}
