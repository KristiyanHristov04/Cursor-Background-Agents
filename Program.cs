using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Wordle!");
        Console.WriteLine("Guess the 5-letter word in 6 attempts or less.");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey();
        
        bool playAgain = true;
        
        while (playAgain)
        {
            PlayGame();
            
            Console.WriteLine("\nWould you like to play again? (y/n)");
            string? response = Console.ReadLine();
            playAgain = response?.ToLower().StartsWith("y") == true;
        }
        
        Console.WriteLine("Thanks for playing!");
    }
    
    static void PlayGame()
    {
        WordleGame game = new WordleGame();
        
        while (!game.IsGameOver)
        {
            game.DisplayGame();
            
            Console.WriteLine("Enter your guess (5 letters):");
            string? input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid 5-letter word.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
            
            try
            {
                string feedback = game.MakeGuess(input);
                
                if (game.IsGameWon)
                {
                    game.DisplayGame();
                    Console.WriteLine($"🎉 Congratulations! You guessed the word '{game.GetTargetWord()}' in {game.GetGuesses().Count} attempts!");
                    break;
                }
                else if (game.IsGameOver)
                {
                    game.DisplayGame();
                    Console.WriteLine($"💔 Game Over! The word was '{game.GetTargetWord()}'.");
                    break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"❌ {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}