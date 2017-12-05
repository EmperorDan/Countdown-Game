using System.Collections.Generic;
using System.Text.RegularExpressions;
using LoopBytes.Database;
namespace Game.Algorithm
{
    public class CountdownAlgo : IAlgorithm
    {

        private const string pattern = "[a-zA-Z]{1|9}";
        private DatabaseManager _db;
        public CountdownAlgo(DatabaseManager db) {
            _db = db;
        }
   
        public bool IsValid(string anagram)
        {
            if (anagram == null) return false;
            return Regex.IsMatch(anagram, pattern);
        }

        public string Solve(string anagram)
        {
            var solution = "";

            _db.ReadLines((line) => {
                if (line.Length > anagram.Length) return;
                if(IsWordValid(anagram, line) && solution.Length < line.Length)
                    solution = line;                
            });

            return solution;
        }

        private bool IsWordValid(string anagram, string line) {
            var slots = new Dictionary<int, bool>(line.Length);         
            for (var i = 0; i < line.Length; i++) {
                var found = false;
                for (var j = 0; j < anagram.Length && !found; j++) {
                    if (line[i] == anagram[j] && !slots.ContainsKey(j))                                               
                         slots.Add(j, found = true);
                }
                // if one letter was not found, we break the loop, the word is not a match
                if (found == false)                
                    return false;        
            }
            return true;
        }
    }
}
