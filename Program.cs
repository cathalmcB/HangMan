using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {

            bool repeat = true;
            int lives;
            char[] alphebet = new char[26];
            alphebet[0] = 'A'; alphebet[1] = 'B'; alphebet[2] = 'C'; alphebet[3] = 'D'; alphebet[4] = 'E'; alphebet[5] = 'F'; alphebet[6] = 'G'; alphebet[7] = 'H'; alphebet[8] = 'I'; alphebet[9] = 'J'; alphebet[10] = 'K'; alphebet[11] = 'L'; alphebet[12] = 'M'; alphebet[13] = 'N'; alphebet[14] = 'O'; alphebet[15] = 'P'; alphebet[16] = 'Q'; alphebet[17] = 'R'; alphebet[18] = 'S'; alphebet[19] = 'T'; alphebet[20] = 'U'; alphebet[21] = 'V'; alphebet[22] = 'W'; alphebet[23] = 'X'; alphebet[24] = 'Y'; alphebet[25] = 'Z';
            char[] usedLetters = new char[25];
            
            int counter=0;
            while (repeat)
            {
                Console.Clear();
                lives = 5;
                char[] charOfWord = InputWord().ToCharArray();
                int x = charOfWord.Length;
                char[] lettersGuessed = new char[x];
                char[] lettersCorrectUsed = new char[x];
                int correctGuessCount = 0;

                ProgressOfWord(charOfWord, lettersGuessed);
                while (lives > 0)
                {


                    
                    Console.WriteLine();
                    char guess = InputChecker();
                    Console.Clear();
                    usedLetters[counter] = guess;
                    counter++;
                    
                    if (GuessComparitor(charOfWord, guess, lettersGuessed, ref correctGuessCount) == true)
                    {
                        
                        for (int i = 0; i < charOfWord.Length; i++)
                        {
                            
                            Console.Write("{0} ", lettersGuessed[i]);
                                
                        }
 
                    }
                    else
                    {
                        lives--;
                    }

                    LifeDisplaySystem(lives);
                    if (correctGuessCount == charOfWord.Length)
                    {
                        bool playAgain = true;
                        string response;

                        Console.WriteLine("Congratulations You Win");

                        while (playAgain == true)
                        {
                            
                            Console.WriteLine("Do you want to play again? Y/N");
                            response = Console.ReadLine().Trim().ToUpper();
                            if (response == "Y" || response == "YES")
                            {
                                Console.WriteLine("Here we go again");
                                playAgain = false;
                                lives = -1000;
                            }
                            else if (response == "N" || response == "NO")
                            {
                                Console.WriteLine("Thanks for Playing");
                                Console.ReadLine();
                                repeat = false;
                                playAgain = false;
                                lives = -1000;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Response Please Enter again");
                            }
                        }
                    }
                    
                }
            }
        }
        public static string InputWord()
        {
            string word;

            Console.WriteLine("Enter in the word to be guessed");
            word = Console.ReadLine().ToUpper();

            return word;
        }

        public static char InputChecker()
        {
            bool checker;
            char guess;

            Console.WriteLine("Please Enter a Letter");
            checker = char.TryParse(Console.ReadLine().ToUpper(), out guess);
            if (checker == false)
            {
                Console.WriteLine("Invalid input please enter another character");
            }

            return guess;

        }

        public static bool GuessComparitor(char[] arr, char guess, char[] lettersCorrectUsed, ref int correctGuessCount)
        {
            bool correct = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == guess)
                {
                    arr[i] = '!';
                    lettersCorrectUsed[i] = guess;
                    Console.WriteLine("You got it, next letter");
                    correct = true;
                    correctGuessCount++;
                    
                }
                
            }
            return correct;
        }
        // Measures the length and number of '_'s diplayed
        public static void ProgressOfWord(char[] arrWord, char[] lettersGuessed)
        {
            for (int i = 0; i < arrWord.Length; i++)
            {
              lettersGuessed[i] = '_';
            }

            
        }
        // The visual life output
        public static void LifeDisplaySystem(int lives)
        {
            if (lives == 5)
            {
                Console.WriteLine("You have 5 Lives");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            if (lives == 4)
            {
                Console.WriteLine("You have 4 Lives");
                Console.WriteLine(" _ _ _");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
            }
            if (lives == 3)
            {
                Console.WriteLine("You have 3 Lives");
                Console.WriteLine(" _ _ _");
                Console.WriteLine(" |    |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
            }
            if (lives == 2)
            {
                Console.WriteLine("You have 2 Lives");
                Console.WriteLine(" _ _ _");
                Console.WriteLine(" |    |");
                Console.WriteLine(" O    |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
            }
            if (lives == 1)
            {
                Console.WriteLine("You have 1 Lives");
                Console.WriteLine(" _ _ _");
                Console.WriteLine(" |    |");
                Console.WriteLine(" O    |");
                Console.WriteLine("/|\\   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
            }
            if (lives == 0)
            {
                Console.WriteLine("You have no Lives");
                Console.WriteLine(" _ _ _");
                Console.WriteLine(" |    |");
                Console.WriteLine(" O    |");
                Console.WriteLine("/|\\   |");
                Console.WriteLine(" |    |");
                Console.WriteLine("/ \\   |");
            }
        }
    }
}

