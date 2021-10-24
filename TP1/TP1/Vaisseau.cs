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
            armes = new List<Arme>(3);
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
            armes.Add(arme);
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
