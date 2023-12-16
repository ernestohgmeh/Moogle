using System.Reflection.Metadata;
using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
namespace MoogleEngine
{
    public class Algo
    {
        public static Document[] Carga()
        {
            list<Document> lista = new list<Document>();
            string currentDirectory = Dictionary.GetFileNameWithoutExtension();
            string path = Path.Join(currentDirectory, "..", "Content");
            string[] archivos = Directory.GetFiles(path,"*.txt");
            foreach(string algo in archivos)
            {
                string nombre = Path.GetFileNameWithoutExtension(algo);

                string[] Contenido = File.ReadAllText(algo).Split(new[] {' ', '\n','\r'}, StringSplitOptions.RemoveEmptyEntries);

                for(int i=0; i<Contenido.Length; i++)
                {
                    Contenido[i]=Contenido[i].ToLower();
                }

                Document documento = new Document(nombre, Contenido);
                lista.Add(documento);
            }
            return lista.ToArray;
        }

        public void mVs(this mainVector x ,Document[] d)
        {
            List<string> words = new List<string>();
            foreach(Document doc in d)
            {
                foreach(string cadena in doc.Contenido)
                {
                    if(!words.Contains(cadena))
                    {
                        words.Add(cadena);
                    }
                }
            }

            x.palabras = words.ToArray();

            x.cantPalabras + new int[x.palabras.Length];
            x.documentCounter = new int[x.palabras.Length];

            foreach(Document doc in d)
            {
                doc.cantPalabras = new int[x.palabras.Length];
                for (int i = 0; i < x.palabras.Length; i++)
                {
                    x.documentCounter[i]+=1;
                    foreach(string word in doc.Contenido)
                    {
                        if(word == x.palabras[i])
                        {
                            x.cantPalabrasT+=1;
                            doc.cantPalabras[i]+=1;
                        }
                    }
                }
            }

        }

        public Document QueryLoader(string query, mainVector x, double total_docs)
        {
            Document salida = new Document("query", query.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
            salida.cantPalabras = new int[x.palabras.Length];
            for (int i = 0; i < x.palabras.Length; i++)
            {
                if (salida.Contenido.Contains(x.palabras[i]))
                {

                    foreach (string word in salida.Contenido)
                    {
                        if (word == x.palabras[i])
                        {

                            salida.cantPalabras[i] += 1;
                        }
                    }
                }
            }
            salida.TFIDF(x, total_docs);

            return salida;
        }
    }
}