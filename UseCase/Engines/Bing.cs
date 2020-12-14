using System;
using SearchFight.Entity;

namespace SearchFight.UseCase.Engines
{
    internal class Bing : Engine
    {
        internal Bing()
        {
            this.Name = "MSN Search";
        }
        internal override void ExecuteSearch(SearchResult searchResult)
        {
            searchResult.engine = this.Name;
            try
            {
                using (Api.Bing _bingApi = new Api.Bing())
                {
                    searchResult.total = _bingApi.Search(searchResult.word).totalResults;
                }
            }
            catch (System.Exception ex)
            {
                searchResult.error = ex.Message;
            }
        }
    }
}