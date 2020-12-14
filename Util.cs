namespace SearchFight
{
    internal static class Util
    {
        internal static Entity.SearchResult GetWinner(Entity.SearchResult lastestWinner, Entity.SearchResult defiant)
        {
            Entity.SearchResult _result = new Entity.SearchResult();
            _result = lastestWinner;

            if(string.IsNullOrEmpty(lastestWinner.word))
            {
                _result = defiant;
            }
            else
            {
                if(lastestWinner.total< defiant.total)
                {
                    _result = defiant;
                }
                else if(lastestWinner.total == defiant.total)
                {
                    _result.word = "Tie";
                }
            }

            return _result;
        }
    }
}