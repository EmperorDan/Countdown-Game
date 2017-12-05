using UnityEngine;
namespace Game
{
    public class LetterPool
    {

        private char[] cons = { 'b', 'c', 'b', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
        private char[] vols = { 'a', 'e', 'i', 'o', 'u' };
        private char[] _pool;
        private int _picksCount;

        public string Word {
            get {
                var word = "";
                foreach (var letter in _pool)
                    word += letter;
                return word;
            }
        }
        public int Tries { get { return _pool.Length - _picksCount; } }
        public int Size { get { return _pool.Length; } }
        public bool IsFull { get { return _picksCount == _pool.Length; } }


        public LetterPool(uint size = 9)   {
            _pool = new char[size];
        }

        public char Get(uint index)  {
            if(index > _pool.Length) 
                Debug.LogError("Index out of bounds. Trying to get a character which is out of bounds."); 

            return _pool[index];
        }       

        public char Pick(bool isVol = false) {
            if (_picksCount >= _pool.Length) {
                Debug.LogErrorFormat("You have reached the max picks in the letter pool. You tried to pick {0} but the lenght is {1}.", _picksCount, _pool.Length);
            }
            var letter = _pool[_picksCount] = PickRandom(isVol ? vols : cons);
            _picksCount++;
            return letter;
        }

        private char PickRandom(char[] chars)  {
            var i = Random.Range(0, chars.Length);
            return chars[i];
        }
    }
}
