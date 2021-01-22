using SearchFight.Entity;

namespace SearchFight.API.Engines
{
    internal class DuckDuckGo: UseCase.Engine
    {
        internal DuckDuckGo()
        {
            this.Name = "DuckDuckGo";
        }

        internal override void ExecuteSearch(SearchResult searchResult)
        {
            searchResult.engine = this.Name;
            throw new System.NotImplementedException("Not implemented");
        }
    }
}