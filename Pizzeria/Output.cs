using System;
using System.IO;

namespace Pizzeria
{
    public class Output
    {
        public void OutputRegularFile()
        {
            string filePath = "chemin/vers/le/fichier.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("");
            }
        }


    }
}
