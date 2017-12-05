using System.Collections.Generic;



namespace Game.Algorithm
{
    interface IAlgorithm
    {
        bool IsValid(string anagram);
        string Solve(string anagram);
    }
}
