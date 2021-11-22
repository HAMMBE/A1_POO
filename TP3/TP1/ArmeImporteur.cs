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
        public ArmeImporteur(string path) {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    if(!armeToImport.ContainsKey(line)) {
                        armeToImport.Add(line, 1);
                    }
                    else
                    {
                        armeToImport.Add(line, );
                    }
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            foreach(var a in armeToImport)
            {
                Array values = Enum.GetValues(typeof(TP3.Type));
                Random random = new Random();
                Type randomType = (Type)values.GetValue(random.Next(values.Length));
                Arme test = new Arme(a.Key, a.Value, a.Key.Length, (Type)randomType);
            }
        }
    }
}
