using System.Numerics;
namespace MoogleEngine
{
    public class Document
    {

        public string Title;

        public string[] Contenido;

        
        public double[] TF_IDF;

        
        public int[] cantPalabras;
        
        public float score = 0;

        public Document(string name, string[] content)
        {
            Title=name;
            Contenido=content.Clone();
        }

        public void Reset()
        {
            score=0;
        }

         /// <summary>
        /// Devuelve el TF_IDF de cada vector
        /// </summary>
        /// <param name="w"></param>
        /// <param name="total_docs"></param>
        public void TFIDF(WordVector w, double total_docs)
        {
            TF_IDF = new double[count.Length];

            for (int i = 0; i < TF_IDF.Length; i++)
            {
                
                TF_IDF[i] = ((double)count[i] / (double)Content.Length) * (Math.Log(total_docs / w.d_counter[i]) + 1);
                
                

            }
        }

        /// <summary>
        /// calcula el coseno similitud de este documento
        /// </summary>
        /// <param name="doc"></param>
        public double Similitud(Document doc)
        { 
             double x = 0;
            for (int i = 0; i < doc.TF_IDF.Length; i++)
            {
                x += TF_IDF[i] * doc.TF_IDF[i];
            }
            double y = 0;

            for (int i = 0; i < doc.TF_IDF.Length; i++)
            {
                y += Math.Pow(TF_IDF[i],2);
            }

            y = Math.Sqrt(y);

            double z = 0;

            for (int i = 0; i < doc.TF_IDF.Length; i++)
            {
                z += Math.Pow(doc.TF_IDF[i],2);
            }

            z = Math.Sqrt(z);

            return x / (y * z);
        }

    }
}