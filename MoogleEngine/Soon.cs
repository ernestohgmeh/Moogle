namespace MoogleEngine
{
    public class Soon
    {
         public mainVector words;
         public Document[] documents;

         public Document query;

         public State()
         {
            documents = Algo.Carga();
            words = new mainVector();
            words.mVs(documents);
            foreach (Document doc in documents)
            {
                doc.TFIDF(words,documents.Length);
            }
         }


        public SearchItem[] Search(string s)
        {
           query = Algo.QLoader(s,words,documents.Length);
           foreach (Document doc in documents)
           {
               doc.score = (float)doc.Similarity(query);
           }

           List<Document> dlist = documents.ToList();
           dlist.Sort();
           dlist.Reverse();

           List<SearchItem> si = new List<SearchItem>();
           for (int i = 0; i < dlist.cantPalabras.Length; i++)
           {
             if(dlist[i].score > 0)
             si.Add(new SearchItem(dlist[i].Title,"...",dlist[i].score));
           }

           return si.ToArray();


           
        }


    }
}