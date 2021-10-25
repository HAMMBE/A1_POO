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
        private Armurerie armurerie;
        public SpaceInvaders(){
            Init();
            armurerie = new Armurerie();
        }

        private void Init()
        {
            this.joueurs = new();
            joueurs.Add(new Joueur("Benjamin", "Hamm", "ESAqua"));
            joueurs.Add(new Joueur("Amine", "Mersel", "AbsoToasty"));
            joueurs.Add(new Joueur("Noel", "Larcher", "yuubeats"));

        }

        static void Main(string[] args)
        {
            SpaceInvaders jeu = new SpaceInvaders();
            Console.WriteLine(jeu.armurerie.ToString());

            foreach (var j in jeu.joueurs)
            {
                Console.WriteLine(j.ToString());
                j.vaisseau.AjoutArme(new Arme("AK-47", 100, 200, Type.Direct));
                j.vaisseau.AjoutArme(new Arme("AK-47", 100, 200, Type.Direct));
                j.vaisseau.AjoutArme(new Arme("AK-47", 100, 200, Type.Direct));
                j.vaisseau.AjoutArme(new Arme("AK-47", 100, 200, Type.Direct));
                j.vaisseau.AffichArme();
                Console.WriteLine(j.vaisseau.ToString());
            }
        }
    }
}
