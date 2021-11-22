using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3;

namespace TP3
{
    class Armurerie
    {
        private List<Arme> armes;
        public List<Arme> Armes { get => armes; set => armes = value; }

        public Armurerie()
        {
            Init();
        }
        private void Init()
        {
            armes = new List<Arme>();
        }

        public override string ToString()
        {
            String texte = "";
            foreach(Arme a in armes)
            {
                texte+= a.ToString();
            }
            return texte;
        }
    }
}
