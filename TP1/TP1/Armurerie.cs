using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1;

namespace TP1
{
    class Armurerie
    {
        private List<Arme> armes {get; set;}

        public Armurerie()
        {
            Init();
        }
        private void Init()
        {
            armes = new List<Arme>();
            armes.Add(new Arme("AK-47", 100, 200, Type.Direct));
            armes.Add(new Arme("C4", 50, 1000, Type.Explosif));
            armes.Add(new Arme("Lance-Roquettes", 700, 1000, Type.Guidé));
            armes.Add(new Arme("Farine", 0, 10, Type.Direct));
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
