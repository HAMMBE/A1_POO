using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1;

namespace TP1
{
    class Vaisseau
    {
        private int pointStructMax { get; set; }
        private int pointBouclierMax { get; set; }
        private bool estDetruit;
        private List<Arme> armes;
        public Vaisseau()
        {
            armes = new List<Arme>();
            pointStructMax = 2000;
            pointBouclierMax = 1000;
            estDetruit = false;

        }
        private void EstDetruit()
        {
            if(pointStructMax == 0)
            {
                estDetruit = true;
            }
        }

        public void AjoutArme(Arme arme)
        {
            // Ajoute une arme au vaisseau et vérifie si il n'y en as pas déjà 3 (le maximum)

            if (armes.Count() == 3)
            {
                Console.WriteLine("Impossible de rajouter une arme plus, veuillez en enlever une d'abord !");
            }
            else
            {
                armes.Add(arme);
            }
        }

        public void RetireArme(Arme arme)
        {
            armes.Remove(arme);
        }

        public void AffichArme()
        {
            foreach(var a in armes)
            {
                Console.WriteLine(a.ToString());
            }
        }

        public override string ToString()
        {
            if (estDetruit)
            {
                return "Le vaisseau est détruit";
            }
            return $"Maximum de points de structure : {pointStructMax} \nMaximum de points de bouclier : {pointBouclierMax}\n";
            
        }
    }
}
