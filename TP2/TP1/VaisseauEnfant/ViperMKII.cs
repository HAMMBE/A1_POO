using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.VaisseauEnfant
{
    class ViperMKII:Vaisseau
    {
            public ViperMKII()
            {
                pointStructMax = 10;
                pointStruct = pointStructMax;
                pointBouclierMax = 15;
                pointBouclier = pointBouclierMax;

                armurerieVaisseau = new Armurerie();
                armurerieVaisseau.Armes.Add(new("Mitrallieuse", 2, 3, 1, Type.Guidé));
                armurerieVaisseau.Armes.Add(new("EMG", 1, 7, 2, Type.Guidé));
                armurerieVaisseau.Armes.Add(new("Torpille", 4, 100, 2, Type.Guidé));



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
                vaisseau.Degats(armurerieVaisseau.Armes[1].Tir());
            }
        }
}
