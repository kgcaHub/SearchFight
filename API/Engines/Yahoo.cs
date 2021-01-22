using SearchFight.Entity;

namespace SearchFight.API.Engines
{
    internal class Yahoo: UseCase.Engine
    {
        internal Yahoo()
        {
            this.Name = "Yahoo";
        }

        internal override void ExecuteSearch(SearchResult searchResult)
        {
            searchResult.engine = this.Name;
            throw new System.NotImplementedException("Not implemented");
        }
    }
}