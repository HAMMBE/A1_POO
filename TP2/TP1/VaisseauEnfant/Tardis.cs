using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.VaisseauEnfant
{
    class Tardis: Vaisseau, IApptitude
    {
        public Tardis()
        {
            pointStructMax = 1;
            pointStruct = pointStructMax;
            pointBouclierMax = 0;
            pointBouclier = pointBouclierMax;

            armurerieVaisseau = new Armurerie();

            estDetruit = false;

        }
        public override void AjoutArme(Arme arme)
        {
            // Ajoute une arme au vaisseau et vérifie si il n'y en as pas déjà 3 (le maximum)

            if (armurerieVaisseau.Armes.Count() == 3)
            {
                Console.WriteLine("Impossible de rajouter une arme plus, veuillez en enlever une d'abord !");
            }
            else
            {
                if (arme.types == Type.Direct)
                {
                    arme.TempsRechargement = 1;
                    arme.NbTourRechargement = 1;
                    armurerieVaisseau.Armes.Add(arme);
                }
                armurerieVaisseau.Armes.Add(arme);
            }
        }
        public override void RetireArme(Arme arme)
        {
            armurerieVaisseau.Armes.Remove(arme);
        }

        public override void AffichArme()
        {
            foreach (var a in armurerieVaisseau.Armes)
            {
                Console.WriteLine(a.ToString());
            }
        }

        public override int DegatMoyVaisseau()
        {
            if (armurerieVaisseau.Armes.Count == 0)
            {
                return 0;
            }
            int cumule = 0;
            foreach (Arme a in armurerieVaisseau.Armes)
            {
                cumule += a.degatMoyen;
            }
            return cumule / armurerieVaisseau.Armes.Count;
        }
        public override void Degats(int degat)
        {

            if (degat > pointBouclier + pointStruct)
            {
                estDetruit = true;
                pointBouclier = 0;
                pointStruct = 0;
            }
            else if (degat > pointBouclier)
            {
                degat -= pointBouclier;
                pointBouclier = 0;
                pointStruct -= degat;
            }
            else
            {
                pointBouclier -= degat;
            }
        }

        public override void Attaque(Vaisseau vaisseau)
        {
        }

        public void Utilise(List<Vaisseau> Vaisseaux)
        {
        }
    }
}
