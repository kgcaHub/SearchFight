using System;
using System.Collections.Generic;

namespace SearchFight.UseCase
{
    internal class Search: IDisposable
    {
        private List<Engine> _AvailableEngines;
        private Entity.SearchResult _TotalWinnerSearch;
        internal Search()
        {
            API.Engines.Google _googleEngine = new API.Engines.Google();
            API.Engines.Bing _bingEngine = new API.Engines.Bing();
            API.Engines.DuckDuckGo _duckDuckGoEngine = new API.Engines.DuckDuckGo();
            API.Engines.Yahoo _yahoo = new API.Engines.Yahoo();

            this._AvailableEngines = new List<Engine>();
            this._AvailableEngines.Add(_googleEngine);
            this._AvailableEngines.Add(_bingEngine);
            this._AvailableEngines.Add(_duckDuckGoEngine);
            this._AvailableEngines.Add(_yahoo);

            this._TotalWinnerSearch = new Entity.SearchResult();
        }
        internal void Figth(string[] args)
        {
            this.SearchWriteResults(args);

            this.WriteWinnerByEngine();

            this.WriteTotalWinner();
        }

        private void SearchWriteResults(string[] args)
        {
            foreach (var _word in args)
            {
                Entity.SearchResult _searchByWord = new Entity.SearchResult();
                _searchByWord.word = _word;

                string _resultsLine = string.Format("{0}:", _word);

                foreach (var _engine in this._AvailableEngines)
                {
                    var _searchByEngine = _engine.Search(_word);

                    _resultsLine = string.Format("{0} {1}", _resultsLine, _searchByEngine.ToString());

                    _searchByWord.total = _searchByWord.total + _searchByEngine.total;
                }
                Console.WriteLine(_resultsLine);

                this._TotalWinnerSearch = Util.GetWinner(this._TotalWinnerSearch, _searchByWord);
            }
        }

        private void WriteWinnerByEngine()
        {
            foreach (var _engine in this._AvailableEngines)
            {
                Console.WriteLine("{0} winner: {1}", _engine.Name, _engine.WinnerResult.word);
                _engine.Dispose();
            }
        }

        private void WriteTotalWinner()
        {
            Console.WriteLine("Total winner: {0}({1})", this._TotalWinnerSearch.word, this._TotalWinnerSearch.total);
        }

        public void Dispose()
        {
            this._AvailableEngines = null;
            this._TotalWinnerSearch = null;
        }


    }
}