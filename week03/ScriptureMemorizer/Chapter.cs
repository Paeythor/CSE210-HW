public class Chapter
    {
        private string _reference;
        private int _chapter;
        private List<Scripture> _verses;
        
        public string GetReference()
    {
        return _reference;
        }
        public void SetRefernce(String Reference)
        
        {
            _reference = Reference;
        }

        
        public int GetChapter()
        {
            return _chapter;
        }

        public void SetChapter(int chapter)
        {
            _chapter = chapter;
        }

        public List<Scripture> GetVerses()
        {
            return _verses;
        }

        public void SetVerses(List<Scripture> verses)
        {
            _verses = verses;
        }

    }

