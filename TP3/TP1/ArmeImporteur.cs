using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3;

namespace TP3
{
    class ArmeImporteur
    {
        public Dictionary<string, int> armeToImport = new Dictionary<string, int>();

        public List<string> Blacklist = new List<string>();
        public ArmeImporteur(string path, Armurerie armurerie) {
            try
            {
                //Pass the file path and file name to the StreamReader constructor
               string text = File.ReadAllText(path);
                //Read the first line of text
                
                //Continue to read until you reach end of file
                foreach(string word in text.Replace("\n", " ").Split(" "))
                {
                    if (!Blacklist.Contains(word))
                    {
                        Console.WriteLine(word);
                        //Si l'arme n'est pas connu on l'ajoute
                        if (!armeToImport.ContainsKey(word))
                        {
                            armeToImport.Add(word, 1);
                        }
                        //Si l'arme est connu on ajoute 1
                        else
                        {
                            armeToImport[word]++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            foreach(var a in armeToImport)
            {
                Console.WriteLine(a.Key.ToLower());
                Array values = Enum.GetValues(typeof(TP3.Type));
                Random random = new Random();
                Type randomType = (Type)values.GetValue(random.Next(values.Length));
                Arme ar = new Arme(a.Key.ToLower(), a.Value, a.Key.Length, random.Next(5)+1, randomType);
                armurerie.Armes.Add(ar);
            }
        }
    }
}
