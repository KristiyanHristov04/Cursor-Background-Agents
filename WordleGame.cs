using System;
using System.Collections.Generic;
using System.Linq;

public class WordleGame
{
    private readonly string targetWord;
    private readonly List<string> guesses;
    private readonly List<string> feedbacks;
    private readonly int maxAttempts = 6;
    private readonly string[] validWords;
    
    public WordleGame()
    {
        // Simple word list for the game
        validWords = new string[]
        {
            "about", "above", "abuse", "actor", "acute", "admit", "adopt", "adult", "after", "again",
            "agent", "agree", "ahead", "alarm", "album", "alert", "alien", "align", "alike", "alive",
            "allow", "alone", "along", "alter", "among", "anger", "angle", "angry", "apart", "apple",
            "apply", "arena", "argue", "arise", "array", "aside", "asset", "avoid", "awake", "award",
            "aware", "badly", "baker", "bases", "basic", "beach", "began", "begin", "being", "below",
            "bench", "billy", "birth", "black", "blame", "blind", "block", "blood", "board", "boost",
            "booth", "bound", "brain", "brand", "brass", "brave", "bread", "break", "breed", "brief",
            "bring", "broad", "broke", "brown", "build", "built", "buyer", "cable", "calif", "carry",
            "catch", "cause", "chain", "chair", "chaos", "charm", "chart", "chase", "cheap", "check",
            "chest", "chief", "child", "china", "chose", "civil", "claim", "class", "clean", "clear",
            "click", "climb", "clock", "close", "cloud", "coach", "coast", "could", "count", "court",
            "cover", "craft", "crash", "crazy", "cream", "crime", "cross", "crowd", "crown", "crude",
            "curve", "cycle", "daily", "damage", "dance", "dated", "dealt", "death", "debut", "delay",
            "depth", "doing", "doubt", "dozen", "draft", "drama", "drank", "dream", "dress", "drill",
            "drink", "drive", "drove", "dying", "eager", "early", "earth", "eight", "elite", "empty",
            "enemy", "enjoy", "enter", "entry", "equal", "error", "event", "every", "exact", "exist",
            "extra", "faith", "false", "fault", "fiber", "field", "fifth", "fifty", "fight", "final",
            "first", "fixed", "flash", "fleet", "floor", "fluid", "focus", "force", "forth", "forty",
            "forum", "found", "frame", "frank", "fraud", "fresh", "front", "fruit", "fully", "funny",
            "giant", "given", "glass", "globe", "going", "grace", "grade", "grain", "grand", "grant",
            "grass", "grave", "great", "green", "gross", "group", "grown", "guard", "guess", "guest",
            "guide", "happy", "harry", "heart", "heavy", "hence", "henry", "horse", "hotel", "house",
            "human", "ideal", "image", "index", "inner", "input", "issue", "japan", "jimmy", "joint",
            "jones", "judge", "known", "label", "large", "laser", "later", "laugh", "layer", "learn",
            "lease", "least", "leave", "legal", "level", "lewis", "light", "limit", "links", "lives",
            "local", "loose", "lower", "lucky", "lunch", "lying", "magic", "major", "maker", "march",
            "maria", "match", "maybe", "mayor", "meant", "media", "metal", "might", "minor", "minus",
            "mixed", "model", "money", "month", "moral", "motor", "mount", "mouse", "mouth", "moved",
            "movie", "music", "needs", "never", "newly", "night", "noise", "north", "noted", "novel",
            "nurse", "occur", "ocean", "offer", "often", "order", "other", "ought", "paint", "panel",
            "paper", "party", "peace", "peter", "phase", "phone", "photo", "piano", "picked", "piece",
            "pilot", "pitch", "place", "plain", "plane", "plant", "plate", "point", "pound", "power",
            "press", "price", "pride", "prime", "print", "prior", "prize", "proof", "proud", "prove",
            "queen", "quick", "quiet", "quite", "radio", "raise", "range", "rapid", "ratio", "reach",
            "ready", "realm", "rebel", "refer", "relax", "repay", "reply", "right", "rigid", "rival",
            "river", "robin", "roger", "roman", "rough", "round", "route", "royal", "rural", "scale",
            "scene", "scope", "score", "sense", "serve", "seven", "shall", "shape", "share", "sharp",
            "sheet", "shelf", "shell", "shift", "shine", "shirt", "shock", "shoot", "short", "shown",
            "sides", "sight", "silly", "since", "sixth", "sixty", "sized", "skill", "sleep", "slide",
            "small", "smart", "smile", "smith", "smoke", "solid", "solve", "sorry", "sound", "south",
            "space", "spare", "speak", "speed", "spend", "spent", "split", "spoke", "sport", "staff",
            "stage", "stake", "stand", "start", "state", "steam", "steel", "steep", "steer", "stern",
            "stick", "still", "stock", "stone", "stood", "store", "storm", "story", "strip", "stuck",
            "study", "stuff", "style", "sugar", "suite", "super", "sweet", "swift", "swing", "swiss",
            "table", "taken", "taste", "taxes", "teach", "teeth", "terry", "texas", "thank", "theft",
            "their", "theme", "there", "these", "thick", "thing", "think", "third", "those", "three",
            "threw", "throw", "thumb", "thus", "tiger", "tight", "timer", "tiny", "title", "today",
            "topic", "total", "touch", "tough", "tower", "track", "trade", "train", "treat", "trend",
            "trial", "tribe", "trick", "tried", "tries", "truck", "truly", "trunk", "trust", "truth",
            "twice", "under", "undue", "union", "unity", "until", "upper", "upset", "urban", "usage",
            "usual", "valid", "value", "video", "virus", "visit", "vital", "vocal", "voice", "waste",
            "watch", "water", "wave", "ways", "wealth", "wheel", "where", "which", "while", "white",
            "whole", "whose", "woman", "women", "world", "worry", "worse", "worst", "worth", "would",
            "write", "wrong", "wrote", "young", "yours", "youth"
        };
        
        Random random = new Random();
        targetWord = validWords[random.Next(validWords.Length)].ToUpper();
        guesses = new List<string>();
        feedbacks = new List<string>();
    }
    
    public bool IsGameWon => guesses.Contains(targetWord);
    public bool IsGameOver => IsGameWon || guesses.Count >= maxAttempts;
    public int AttemptsLeft => maxAttempts - guesses.Count;
    
    public string MakeGuess(string guess)
    {
        if (guess == null || guess.Length != 5)
            throw new ArgumentException("Guess must be exactly 5 letters long");
            
        guess = guess.ToUpper();
        
        if (!validWords.Contains(guess.ToLower()))
            throw new ArgumentException("Word not in word list");
        
        if (guesses.Contains(guess))
            throw new ArgumentException("You already guessed that word");
            
        guesses.Add(guess);
        
        string feedback = GenerateFeedback(guess);
        feedbacks.Add(feedback);
        
        return feedback;
    }
    
    private string GenerateFeedback(string guess)
    {
        char[] feedback = new char[5];
        bool[] targetUsed = new bool[5];
        bool[] guessUsed = new bool[5];
        
        // First pass: mark exact matches (green)
        for (int i = 0; i < 5; i++)
        {
            if (guess[i] == targetWord[i])
            {
                feedback[i] = 'G'; // Green
                targetUsed[i] = true;
                guessUsed[i] = true;
            }
        }
        
        // Second pass: mark letters in wrong positions (yellow)
        for (int i = 0; i < 5; i++)
        {
            if (!guessUsed[i])
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!targetUsed[j] && guess[i] == targetWord[j])
                    {
                        feedback[i] = 'Y'; // Yellow
                        targetUsed[j] = true;
                        break;
                    }
                }
            }
        }
        
        // Third pass: mark letters not in word (gray)
        for (int i = 0; i < 5; i++)
        {
            if (feedback[i] == '\0')
            {
                feedback[i] = '-'; // Gray
            }
        }
        
        return new string(feedback);
    }
    
    public void DisplayGame()
    {
        Console.Clear();
        Console.WriteLine("==================");
        Console.WriteLine("    WORDLE GAME");
        Console.WriteLine("==================");
        Console.WriteLine();
        
        Console.WriteLine($"Attempts left: {AttemptsLeft}");
        Console.WriteLine();
        
        // Display previous guesses
        for (int i = 0; i < guesses.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            DisplayGuessWithFeedback(guesses[i], feedbacks[i]);
        }
        
        // Display empty rows for remaining attempts
        for (int i = guesses.Count; i < maxAttempts; i++)
        {
            Console.WriteLine($"{i + 1}. _ _ _ _ _");
        }
        
        Console.WriteLine();
        Console.WriteLine("Legend:");
        Console.WriteLine("G = Green (correct letter, correct position)");
        Console.WriteLine("Y = Yellow (correct letter, wrong position)");
        Console.WriteLine("- = Gray (letter not in word)");
        Console.WriteLine();
    }
    
    private void DisplayGuessWithFeedback(string guess, string feedback)
    {
        for (int i = 0; i < 5; i++)
        {
            ConsoleColor color = feedback[i] switch
            {
                'G' => ConsoleColor.Green,
                'Y' => ConsoleColor.Yellow,
                '-' => ConsoleColor.Gray,
                _ => ConsoleColor.White
            };
            
            Console.ForegroundColor = color;
            Console.Write(guess[i]);
            Console.ResetColor();
            Console.Write(" ");
        }
        
        Console.Write(" | ");
        for (int i = 0; i < 5; i++)
        {
            Console.Write(feedback[i] + " ");
        }
        Console.WriteLine();
    }
    
    public string GetTargetWord() => targetWord;
    
    public List<string> GetGuesses() => new List<string>(guesses);
    
    public bool IsValidWord(string word)
    {
        return word != null && word.Length == 5 && validWords.Contains(word.ToLower());
    }
}