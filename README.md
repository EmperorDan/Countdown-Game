# Countdown-Game
> Research and implement a video game that mimics the popular show ‘Countdown’. Review, reflect, refactor and evolve the code you designed and developed in Project 003 as a reasonable starting point.
A 9 letter anagram puzzle. The user selects 8 vowels or consonants. 30 second countdown. User inputs word found. Check if valid. Compare to highest value word. Give or decrease score.

## Algorithm Flowchart
![Algorithm Flowchart](https://github.com/codrin-axinte/Countdown-Game/blob/master/Assets/Countdown.png)

## Requirements
Sint ea proident esse incididunt pariatur laborum id id consequat pariatur veniam aute. Do in non nisi eiusmod labore nisi. Fugiat veniam do veniam est minim esse commodo consectetur ullamco id labore.

## User Stories 
* As a user I want to be able to Select **Vowels** or **Consonants**.
* As a user I want the rules of Countdown to be implemented. 
* As a user I want to be able to input my highest value word.
* As a user I want feedback as to whether my word is valid.
* As a user I want feedback of the highest value word.
* As a user I want game aspects (I.e. scores). 

## Algorithm
1. User inputs a name
1. User selects how many vowels and consonants want to have. Based on selection a random letter will be added in the letter pool.
1. When the letter pool is full(8 letters were picked) than the countdown timer starts
1. User can form a word with the letters from the pool.
1. When the countdown timer is finished, the formed word is validated.
    1. If the word is **not valid** than score is **decreased**
    1. If the word is **valid** but **not the best**, the score is **half increased**
    1. If the word is **valid** and is **the best**, the score is **increased with full amount** of the score.
1. Show a popup with: 
    * The best solution, 
    * The player's solution 
    * The current score
    * A choice to continue or to resign.

## How the word is validated?

> Using the Object Oriented Paradigm(OOP), for word searching we've used the base of the [anagram solver](https://github.com/codrin-axinte/Anagram-Solver) and extend it.
```csharp
 public class CountdownAlgo : IAlgorithm
```
> Validating the word
```csharp
private const string pattern = "[a-zA-Z]{1|9}"; // Regex pattern: Anagram must contains only apha letters from a to z and must have between 1 and 9 letters.
public bool IsValid(string anagram)
{
    if (anagram == null) return false; // If the given anagram is empty return false(it's not valid)
    return Regex.IsMatch(anagram, pattern); // Otherwise check if matches to the regex pattern
}
```
> Solving the anagram
```csharp
private bool IsWordValid(string anagram, string line) {
    // create a slots dictionary, this stores if a letter is already assigned or not.
    var slots = new Dictionary<int, bool>(line.Length);         
    for (var i = 0; i < line.Length; i++) { // for each letter in the current line/word
        var found = false; 
        for (var j = 0; j < anagram.Length && !found; j++) { // for each letter in the anagram if a letter wasn't already found
            // if the line letter equals the current anagram letter 
            // and the anagram letter isn't already assigned set the found var to true and assign the slot tho the current anagram letter  
            if (line[i] == anagram[j] && !slots.ContainsKey(j))                                             
                    slots.Add(j, found = true);
        }
        // if one letter was not found, we break the loop, the word is not a match
        if (found == false)                
            return false;        
    }
    return true;
}
```

## Usage Example
 The program allows the player input a name then to Pick 8 Vowels or consonants and is given 30 seconds to come up with the highest value word they can. They are prompted as to whether their word is valid and if it is not, they are displayed the highest possible word and decrease score, if they are valid but not the highest value they gain half score, if valid and highest they gain full score. Option to continue again or quit. 

## Teamwork

Ullamco esse consequat aliquip veniam velit sint Lorem velit. Qui adipisicing ullamco Lorem nulla dolore sit veniam non quis. Esse officia pariatur nulla magna qui pariatur ut magna ea cupidatat ut anim sit.

## Time & Task Management
Veniam aute cillum est labore ea incididunt mollit do id amet nulla sint qui anim. Proident excepteur qui anim dolor commodo sit officia excepteur ad labore officia magna ea. Ex ut enim voluptate laborum consequat non cupidatat sit adipisicing dolore.

## Meta

Codrin Axinte – [@LinkedIn](https://www.linkedin.com/in/codrin-axinte-93776814b/) – xntcodrin@yahoo.com – loopbytes@yahoo.com

Distributed under the MIT license. See ``LICENSE`` for more information.

[https://github.com/codrin-axinte](https://github.com/codrin-axinte)

## Contributing

1. Fork it (<https://github.com/codrin-axinte/Countdown-Game/fork>)
2. Create your feature branch (`git checkout -b feature/Countdown-Game`)
3. Commit your changes (`git commit -am 'Add some Countdown-Game'`)
4. Push to the branch (`git push origin feature/Countdown-Game`)
5. Create a new Pull Request