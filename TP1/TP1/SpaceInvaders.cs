using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1;

namespace TP1
{
    class SpaceInvaders
    {
        private List<Joueur> joueurs;
        public SpaceInvaders(){
            joueurs = Init();
        }

        private List<Joueur> Init()
        {
            List<Joueur> joueurs = new();
            joueurs.Add(new Joueur("Benjamin", "Hamm", "ESAqua"));
            joueurs.Add(new Joueur("Amine", "Mersel", "AbsoToasty"));
            joueurs.Add(new Joueur("Noel", "Larcher", "yuubeats"));

            return joueurs;
        }

        static void Main(string[] args)
        {
            SpaceInvaders jeu = new SpaceInvaders();


            foreach (var j in jeu.joueurs)
            {
                Console.WriteLine(j.ToString());
            }
        }
    }
}
