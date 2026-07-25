namespace ScriptureMemorizer
{
    public class Word
    {
        private string text;
        private bool hidden;

        public Word(string text)
        {
            this.text = text;
            hidden = false;
        }

        public void Hide()
        {
            hidden = true;
        }

        public string GetDisplayText()
        {
            return hidden ? new string('_', text.Length) : text;
        }

        public bool IsHidden() => hidden;
    }
}
