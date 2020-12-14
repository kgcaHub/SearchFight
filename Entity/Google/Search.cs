using System;

namespace SearchFight.Entity.Google
{
    public class Search
    {
        public string id {get; set;}
        public long totalResults {get; set;}
        public Guid searchId {get; set;}
        public string word {get; set;}
    }
}