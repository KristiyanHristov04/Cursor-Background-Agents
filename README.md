# C# Wordle Game

A simple console-based implementation of the popular Wordle game in C#.

## Features

- **Classic Wordle gameplay**: Guess a 5-letter word in 6 attempts or less
- **Color-coded feedback**: 
  - 🟢 Green: Correct letter in correct position
  - 🟡 Yellow: Correct letter in wrong position
  - ⚫ Gray: Letter not in the word
- **Word validation**: Only accepts valid 5-letter words from a curated word list
- **Duplicate prevention**: Prevents entering the same guess twice
- **Visual game board**: Clear display of all guesses and feedback
- **Play again option**: Continue playing multiple rounds
- **500+ word dictionary**: Extensive word list for varied gameplay

## How to Play

1. The game will randomly select a 5-letter word
2. You have 6 attempts to guess the word
3. After each guess, you'll receive feedback:
   - Letters in the correct position will be shown in green
   - Letters in the word but wrong position will be shown in yellow
   - Letters not in the word will be shown in gray
4. Win by guessing the word within 6 attempts!

## Requirements

- .NET 6.0 or later
- Console/Terminal environment

## How to Run

1. Clone or download the project
2. Open a terminal/command prompt in the project directory
3. Run the following commands:

```bash
dotnet run
```

Or build and run separately:

```bash
dotnet build
dotnet run
```

## Game Rules

- Words must be exactly 5 letters long
- Only valid English words are accepted
- You cannot guess the same word twice
- You have 6 attempts to guess the correct word
- The game is case-insensitive (you can type in lower or upper case)

## Example Gameplay

```
==================
    WORDLE GAME
==================

Attempts left: 5

1. H E A R T | - Y - G -
2. _ _ _ _ _
3. _ _ _ _ _
4. _ _ _ _ _
5. _ _ _ _ _
6. _ _ _ _ _

Legend:
G = Green (correct letter, correct position)
Y = Yellow (correct letter, wrong position)
- = Gray (letter not in word)

Enter your guess (5 letters):
```

## Project Structure

- `Program.cs` - Main entry point and game loop
- `WordleGame.cs` - Core game logic and mechanics
- `WordleGame.csproj` - Project configuration file
- `README.md` - This file

## Technical Details

The game implements the classic Wordle algorithm:
1. **Exact matches first**: Letters in correct positions are marked green
2. **Position matches second**: Remaining letters that exist in the word but in wrong positions are marked yellow
3. **No matches last**: Letters not in the word are marked gray

The feedback system properly handles duplicate letters according to official Wordle rules.

Enjoy playing!