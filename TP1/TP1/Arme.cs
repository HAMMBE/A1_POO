using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1;

namespace TP1
{
    class Arme
    {
        private string nom {get; set;}
        private int degatMin {get;}
        private int degatMax {get;}

        private Type type {get;}

        public int degatMoyen {get;}

        public Arme(string nom, int degatMin,int degatMax, Type type)
        {
            this.nom = nom;
            this.degatMin = degatMin;
            this.degatMax = degatMax;
            this.type = type;
            degatMoyen = (degatMin + degatMax) / 2;
        }


        public override string ToString()
        {
            return $"Nom : {nom} Degat Min : {degatMin} Degat Max : {degatMax} Type : {type} \n";
        }
    }
}
