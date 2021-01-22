using System;

namespace SearchFight.UseCase
{
    internal class Engine
    {
        internal string Name { get; set; }
        internal Entity.SearchResult WinnerResult { get; private set; }
        internal Engine()
        {
            this.WinnerResult = new Entity.SearchResult();
        }
        internal Entity.SearchResult Search(string word)
        {
            Entity.SearchResult _result = new Entity.SearchResult();
            _result.word = word;
            try
            {
                this.ExecuteSearch(_result);
            }
            catch (System.Exception ex)
            {
                _result.error = ex.Message;
            }

            this.SetWinner(_result);

            return _result;
        }
        internal virtual void ExecuteSearch(Entity.SearchResult searchResult)
        {
        }
        private void SetWinner(Entity.SearchResult searchResult)
        {
            this.WinnerResult = Util.GetWinner(this.WinnerResult, searchResult);
        }

        public void Dispose()
        {
            this.Name = string.Empty;
            this.WinnerResult = null;
        }
    }
}