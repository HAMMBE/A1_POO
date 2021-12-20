using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4;

namespace TP4
{
    public class Arme
    {
        private string nom {get; set;}
        private int degatMin {get;}
        private int degatMax {get;}

        private Type type;

        public int degatMoyen {get;}

        private int tempsRechargement;

        private int nbTourRechargement;

        public Type types { get => type; set => type = value; }
        public int TempsRechargement { get => tempsRechargement; set => tempsRechargement = value; }

        public int NbTourRechargement { get => nbTourRechargement; set => nbTourRechargement = value; }

        public Arme(string nom, int degatMin,int degatMax,int tempsRechargement , Type type)
        {
            this.nom = nom;
            this.degatMin = degatMin;
            this.degatMax = degatMax;
            this.type = type;
            this.tempsRechargement = tempsRechargement;
            nbTourRechargement = (type == Type.Explosif) ? tempsRechargement * 2 : tempsRechargement; 

            degatMoyen = (degatMin + degatMax) / 2;
        }

        public int Tir()
        {
            if(nbTourRechargement > 0)
            {
                nbTourRechargement -= 1;
                Console.WriteLine($"L'arme : {nom} est en cours de rechargement");
                return 0;
            } else
            {
                Random alea = new Random();
                switch (type)
                {
                    case Type.Direct:
                        if(alea.Next(0, 100) > 90)
                        {
                            return 0;
                        } else
                        {
                            return alea.Next(degatMin, degatMax);
                        }
                    case Type.Explosif:
                        if (alea.Next(0, 100) > 75)
                        {
                            return 0;
                        }
                        else
                        {
                            return alea.Next(degatMin, degatMax) * 2;
                        }
                    case Type.Guidé:
                        return degatMin;


                }
            }
            return 1;
        }

        public override string ToString()
        {
            return $"Nom : {nom} Degat Min : {degatMin} Degat Max : {degatMax} Degat Moyen : {degatMoyen} Type : {type} \n";
        }
    }
}
