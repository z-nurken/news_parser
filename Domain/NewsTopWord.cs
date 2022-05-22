
namespace Domain
{
    public class NewsTopWord
    {
        public string Word { get; set; }
        public int Count { get; set; }
        
        public NewsTopWord(string word, int count)
        {
            Word = word;
            Count = count;
        }
    }
}
