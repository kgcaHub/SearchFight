using SearchFight.Entity;

namespace SearchFight.UseCase.Engines
{
    internal class DuckDuckGo: Engine
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