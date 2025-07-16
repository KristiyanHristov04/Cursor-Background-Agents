using System;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to Wordle!");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Guess the 5-letter word in 6 attempts or less.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Press any key to start...");
        Console.ResetColor();
        Console.ReadKey();
        
        bool playAgain = true;
        
        while (playAgain)
        {
            PlayGame();
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nWould you like to play again? (y/n)");
            Console.ResetColor();
            string? response = Console.ReadLine();
            playAgain = response?.ToLower().StartsWith("y") == true;
        }
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Thanks for playing!");
        Console.ResetColor();
    }
    
    static void PlayGame()
    {
        WordleGame game = new WordleGame();
        
        while (!game.IsGameOver)
        {
            game.DisplayGame();
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter your guess (5 letters):");
            Console.ResetColor();
            string? input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid 5-letter word.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }
            
            try
            {
                string feedback = game.MakeGuess(input);
                
                if (game.IsGameWon)
                {
                    game.DisplayGame();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"🎉 Congratulations! You guessed the word '{game.GetTargetWord()}' in {game.GetGuesses().Count} attempts!");
                    Console.ResetColor();
                    break;
                }
                else if (game.IsGameOver)
                {
                    game.DisplayGame();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"💔 Game Over! The word was '{game.GetTargetWord()}'.");
                    Console.ResetColor();
                    break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ {ex.Message}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}