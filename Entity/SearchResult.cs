
namespace SearchFight.Entity
{
    internal class SearchResult
    {
        internal string word { get; set; }
        internal string engine { get; set; }
        internal long total { get; set; }
        internal string error { get; set; }

        public override string ToString()
        {
            string _result = string.Empty;
            if (string.IsNullOrEmpty(this.error))
            {
                _result = string.Format("{0}:{1}", this.engine, this.total);
            }
            else
            {
                _result = string.Format("{0}:Error({1})", this.engine, this.error);
            }
            return _result;
        }
    }
}