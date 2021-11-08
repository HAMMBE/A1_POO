using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2;

namespace TP2
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
            armes.Add(new Arme("AK-47", 2, 3, 1, Type.Direct));
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
