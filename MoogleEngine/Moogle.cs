namespace MoogleEngine;


public static class Moogle
{
    public static SearchResult Query(string query, Soon soon) {
        // Modifique este método para responder a la búsqueda

       

        return new SearchResult(soon.Search(query), query);
    }
}
