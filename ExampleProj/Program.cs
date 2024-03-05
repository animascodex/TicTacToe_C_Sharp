using System;
using System.Threading;

namespace TicTacToeProg
{
    class Program
    {
        // Initialize char type "spaces", 9 boxes in a tic tac toe game
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        // Initialize Player 1  as 1
        static int player = 1;
        static int choice;
        static int flag;
/// <summary>
/// Function to draw the Gameboard
/// </summary>
        static void GameBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("     |     |     ");
        }
/// <summary>
/// Checks is the game has been won using if conditional statements
/// </summary>
static int CheckWinCondition()
        {
            if (spaces[0] == spaces[1] && spaces[1] == spaces[2] || //Row 1 Win
                spaces[3] == spaces[4] && spaces[4] == spaces[5] || //Row 2 Win 
                spaces[6] == spaces[7] && spaces[7] == spaces[8] || //Row 3 Win
                spaces[0] == spaces[3] && spaces[3] == spaces[6] || //Column 1 Win
                spaces[1] == spaces[4] && spaces[4] == spaces[7] || //Column 2 Win
                spaces[2] == spaces[5] && spaces[5] == spaces[8] || //Column 3 Win
                spaces[0] == spaces[4] && spaces[4] == spaces[8] || //Left Diagonal Win
                spaces[2] == spaces[4] && spaces[4] == spaces[6])  // Right Diagonal Win
            {
                return 1;
            }
            else if (spaces[0] != '1' &&
                     spaces[1] != '2' &&
                     spaces[2] != '3' &&
                     spaces[3] != '4' &&
                     spaces[4] != '5' &&
                     spaces[5] != '6' &&
                     spaces[6] != '7' &&
                     spaces[7] != '8' &&
                     spaces[8] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Draws an X on the Game Board
        /// </summary>
        /// <param name="pos"></param>
        static void DrawX(int pos)
        {
            spaces[pos] = 'X';
        }

        /// <summary>
        /// Draws an O on the Game Board
        /// </summary>
        /// <param name="pos"></param>
        static void DrawO(int pos)
        {
            spaces[pos] = 'O';
        }


        /// <summary>
        /// Main Game Loop
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X and Player 2: O " + "\n");
                if (player % 2 == 0) //If Odd Number is equavalent to Player 1 and Player 2 for Even.
                {
                    Console.WriteLine("Player 2 Turn");
                }
                else
                {
                    Console.WriteLine("Player 1 Turn");
                }
                Console.WriteLine("\n");
                GameBoard();
                choice = int.Parse(Console.ReadLine()) - 1; //Index Starts from 0 hence -1
                if (spaces[choice] != 'X' && spaces[choice] != 'O')
                {
                    if (player % 2 == 0) //If Odd Number is equavalent to Player 1 and Player 2 for Even.
                    {
                        DrawO(choice);
                    }
                    else
                    {
                        DrawX(choice);
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already Marked with Symbol {1}", choice, spaces[choice]);
                    Console.WriteLine("Gameboard is reloading, please wait for a moment...");
                    Thread.Sleep(2000);
                }
                flag = CheckWinCondition();
            } while (flag != 1 && flag != -1);

            Console.Clear();
            GameBoard();

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has Won!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Game is a Draw ");
            }
            Console.ReadLine();

        }


    }
}

