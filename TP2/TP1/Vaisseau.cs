using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2;

namespace TP2
{
    abstract class Vaisseau
    {
        protected int pointStructMax { get; set; }
        protected int pointBouclierMax { get; set; }
        protected int pointStruct, pointBouclier;   
        protected bool estDetruit;
        protected Armurerie armurerieVaisseau { get; set; }
        protected List<Vaisseau> Vaisseaux;
        
        private void EstDetruit()
        {
            if(pointStruct == 0)
            {
                estDetruit = true;
            }
        }

        public void Init()
        {
            Vaisseaux = new List<Vaisseau>();
            Vaisseaux.Add(B_Wings());

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
                return "Le vaisseau est détruit";
            }
            return $"Maximum de points de structure : {pointStructMax} \nMaximum de points de bouclier : {pointBouclierMax}\n Degat moyen du vaisseau : {DegatMoyVaisseau()}";
            
        }

    }
}
