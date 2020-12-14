using System;
using SearchFight.Entity;

namespace SearchFight.UseCase.Engines
{
    internal class Google : Engine
    {
        internal Google()
        {
            this.Name = "Google";
        }

        internal override void ExecuteSearch(SearchResult searchResult)
        {
            searchResult.engine = this.Name;

            try
            {
                using (Api.Google _googleApi = new Api.Google())
                {
                    _googleApi.Auth();
                    searchResult.total = _googleApi.Search(searchResult.word).totalResults;
                }
            }
            catch (System.Exception ex)
            {
                searchResult.error = ex.Message;
            }
        }
    }
}