﻿using System;
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
            joueurs = Init();
            armurerie = new Armurerie();
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
            Console.WriteLine(jeu.armurerie.ToString());

            foreach (var j in jeu.joueurs)
            {
                Console.WriteLine(j.ToString());
                Console.WriteLine(j.vaisseau.ToString());
            }
        }
    }
}
