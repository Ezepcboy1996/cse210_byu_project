using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference reference;
        private List<Word> words;
        private Random random = new Random();

        public Scripture(Reference reference, string text)
        {
            this.reference = reference;
            words = new List<Word>();
            foreach (string word in text.Split(' '))
            {
                words.Add(new Word(word));
            }
        }

        public string GetDisplayText()
        {
            List<string> displayWords = new List<string>();
            foreach (Word word in words)
            {
                displayWords.Add(word.GetDisplayText());
            }
            return $"{reference.GetDisplayText()} - {string.Join(" ", displayWords)}";
        }

        public void HideRandomWords(int count = 3)
        {
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(words.Count);
                words[index].Hide();
            }
        }

        public bool AllWordsHidden()
        {
            foreach (Word word in words)
            {
                if (!word.IsHidden()) return false;
            }
            return true;
        }
    }
}
