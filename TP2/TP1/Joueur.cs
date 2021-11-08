using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Joueur
    {
        private string nom, prenom, pseudo;
        public Vaisseau vaisseau;

        public Joueur(string nom, string prenom, string pseudo)
        {
            this.nom = MajPremiereLettre(nom);
            this.prenom = MajPremiereLettre(prenom);
            this.pseudo = pseudo;
            vaisseau = new Vaisseau();
        }

        public string getNomPrenom()
        {
            return $"{prenom} {nom}";
        }
        public string Pseudo { get => pseudo; set => pseudo = value; }

        static private string MajPremiereLettre(string nom)
        {
            string str = nom.ToLower();
            if (str.Length == 1)
            {
               str = str.ToUpper();
            }

            else
            {
               str = char.ToUpper(str[0]) + str.Substring(1);
            }
            return str;
        }
        public override string ToString()
        {
            return $"{pseudo} ({getNomPrenom()})";
        }
        public override bool Equals(object obj)
        {
            Joueur j = obj as Joueur;
            if (j == null)
            {
                return false;
            }
            return pseudo == j.pseudo;
        }
    }
}
