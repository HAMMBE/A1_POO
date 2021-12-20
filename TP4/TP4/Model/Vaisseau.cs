using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4;
using TP4.VaisseauEnfant;

namespace TP4
{
    abstract class Vaisseau
    {
        protected int pointStructMax { get; set; }
        protected int pointBouclierMax { get; set; }
        protected int pointStruct, pointBouclier;   
        protected bool estDetruit;
        public string imagePath { get; set; }
        public string nom;
        public Armurerie armurerieVaisseau { get; set; }
        
        public bool EstDetruit()
        {
            if(pointStruct == 0)
            {
                estDetruit = true;
                return true;
            }
            return false;
        }

        public abstract void AjoutArme(Arme arme);

        public abstract void RetireArme(Arme arme);

        public abstract void AffichArme();

        public abstract int DegatMoyVaisseau();

        public abstract void Degats(int degat);

        public abstract void Attaque(Vaisseau vaisseau);
        public override string ToString()
        {
            if (estDetruit)
            {
                return $"Le vaisseau est détruit. C'était un : {nom} \n";
            }
            return $"Points de structure : {pointStruct} \nPoints de bouclier : {pointBouclier}\n Type de vaisseau : {nom}";
            
        }

    }
}
