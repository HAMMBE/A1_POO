using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Vaisseau
    {
        private int pointStructMax { get; set; }
        private int pointBouclierMax { get; set; }
        private bool estDetruit;
        public Vaisseau(){
        }

        private void EstDetruit()
        {
            if(pointStructMax == 0)
            {
                estDetruit = true;
            }
        }
    }
}
