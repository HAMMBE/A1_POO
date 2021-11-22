using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3;
using TP3.VaisseauEnfant;

namespace TP3
{
    class SpaceInvaders
    {
        public Joueur joueur1;
        public List<Vaisseau> ennemies;
        public Armurerie armurerieGlobal;

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

            //Creation d'une armurerie Global pour le jeu
            armurerieGlobal = new Armurerie();

            ArmeImporteur jsp = new ArmeImporteur(@"D:\Documents HDD\Cours\CNAM\POO\TP\A1_POO\armes.txt", armurerieGlobal);

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

            List<Vaisseau> vaisseaux = new();
            vaisseaux.AddRange(jeu.ennemies);

            //Utilise toutes les capacités spéciales
            foreach (Vaisseau v in jeu.ennemies)
            {
                
                if (v is IApptitude vaisseauApt) {
                    jeu.joueur1.vaisseau.Degats(vaisseauApt.Utilise(vaisseaux));
                }
            }

            jeu.ennemies = vaisseaux;

            // Le jeu continue jusqu'a ce que le joueur perde son vaisseau ou qu'il tue tous les ennemies
            while (jeu.ennemies.Count() != 0 && jeu.joueur1.vaisseau.EstDetruit() == false)
            {
                Random alea = new Random();
                int indice = 1;
                bool ajouer = false;

                //Verifie si le joueur tir en premier
                if (indice >= alea.Next(indice, jeu.ennemies.Count()))
                {
                    int indVaiss = alea.Next(0, jeu.ennemies.Count());
                    jeu.joueur1.vaisseau.Attaque(jeu.ennemies[indVaiss]);

                    Console.WriteLine("____Vaisseau Attaqué par le joueur____ \n");
                    Console.WriteLine(jeu.ennemies[indVaiss].ToString());

                    //Si le vaisseau ennemies est detruit il est supprimer de la liste
                    if (jeu.ennemies[indVaiss].EstDetruit())
                    {
                        jeu.ennemies.RemoveAt(indVaiss);
                    }
                    ajouer = true;

                }
                
                //Chaque vaisseau ennemie tir sur le joueur
                foreach (Vaisseau v in jeu.ennemies)
                {

                    v.Attaque(jeu.joueur1.vaisseau);
                    Console.WriteLine("____Vaisseau Joueur____ \n");
                    Console.WriteLine(jeu.joueur1.vaisseau.ToString());
                    if (jeu.joueur1.vaisseau.EstDetruit())
                    {
                        break;
                    }
                }
                
                // Si le joueur n'as pas jouer en premier il tir maintenant
                if (!ajouer && jeu.joueur1.vaisseau.EstDetruit() == false)
                {
                    int indVaiss = alea.Next(1, jeu.ennemies.Count());
                    jeu.joueur1.vaisseau.Attaque(jeu.ennemies[indVaiss]);

                    Console.WriteLine("____Vaisseau Attaqué par le joueur____ \n");
                    Console.WriteLine(jeu.ennemies[indVaiss].ToString());

                    //Si le vaisseau ennemies est detruit il est supprimer de la liste
                    if (jeu.ennemies[indVaiss].EstDetruit())
                    {
                        jeu.ennemies.RemoveAt(indVaiss);
                    }
                }
            }
            Console.WriteLine(jeu.armurerieGlobal.ToString());
        }
    }
}
