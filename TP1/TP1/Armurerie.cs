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
        private List<Arme> Armes {get; set;}

        public Armurerie()
        {
            Init();
        }
        private void Init()
        {
            Armes = new List<Arme>();
            Armes.Add(new Arme("AK-47", 100, 200, Type.Direct));
            Armes.Add(new Arme("C4", 50, 1000, Type.Explosif));
            Armes.Add(new Arme("Lance-Roquettes", 700, 1000, Type.Guidé));
            Armes.Add(new Arme("Farine", 0, 10, Type.Direct));
        }
    }
}
