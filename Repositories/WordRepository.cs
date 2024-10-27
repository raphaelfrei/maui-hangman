using Hangman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Repositories {

    public class WordRepository {

        private List<Word> _words;

        public WordRepository() {

            _words = new List<Word>() {
                new Word("Food", "Pizza"),
                new Word("Fruit", "Apple"),
                new Word("Vegetable", "Carrot"),
                new Word("Country", "Brazil")
            };

        }

        public Word GetRandomWord() {

            Random rand = new Random();
            int elem = rand.Next(0, _words.Count);

            return _words[elem];
        }

    }
}
