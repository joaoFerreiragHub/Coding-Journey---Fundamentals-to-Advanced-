﻿using System;

namespace JogoDoGalo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid = true;
            int player = 2;
            int input = 0;
            // Quem é a jogar
            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO('O', input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO('X', input);
                }
                SetField();

                // Condições para ganhar ou empate
                #region  
                char[] playerChars = { 'X', 'O' };
                foreach (char playerChar in playerChars)
                {
                    if (((playField[0, 0] == playerChar) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar))
                       || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))
                       || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                       || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))
                       || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))
                       || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar))
                       || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))
                       || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[0, 2] == playerChar))
                      )
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\n Player 2 has won!");
                        }
                        else
                        {
                            Console.WriteLine("\n Player 1 has won!");
                        }
                        Console.WriteLine("Press any key to reset the game!");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("We Have a Draw!");
                        Console.WriteLine("Press any key to reset the game!");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                }
                #endregion

                // Jogadas, o que escolheu
                #region
                do
                {
                    Console.WriteLine("\n Player {0}: Choose your field!", player);
                    try
                    {
                        input = Convert.ToInt32(Console.Read());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number!");
                    }

                    if ((input == 1) && (playField[0, 0] == '1'))
                        isValid = true;
                    else if ((input == 2) && (playField[0, 1] == '2'))
                        isValid = true;
                    else if ((input == 3) && (playField[0, 2] == '3'))
                        isValid = true;
                    else if ((input == 4) && (playField[1, 0] == '4'))
                        isValid = true;
                    else if ((input == 5) && (playField[1, 1] == '5'))
                        isValid = true;
                    else if ((input == 6) && (playField[1, 2] == '6'))
                        isValid = true;
                    else if ((input == 7) && (playField[2, 0] == '7'))
                        isValid = true;
                    else if ((input == 8) && (playField[2, 1] == '8'))
                        isValid = true;
                    else if ((input == 9) && (playField[2, 2] == '9'))
                        isValid = true;
                    else
                    {
                        Console.WriteLine("\n Incorrect input! Please use another field!");
                        isValid = false;
                    }
                } while (!isValid);
                #endregion

            } while (true);
        }
        // Recomeçar a partida
        public static void ResetField()
        {
            char[,] playFieldInital =
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };
            playField = playFieldInital;
            SetField();
            turns = 0;
        }
        // Mostrar o campo
        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("       |       |     ");
            Console.WriteLine("   {0}   |   {1}   |  {2}", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("_______|_______|_____");
            Console.WriteLine("       |       |     ");
            Console.WriteLine("   {0}   |   {1}   |  {2}", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_______|_______|_____");
            Console.WriteLine("       |       |     ");
            Console.WriteLine("   {0}   |   {1}   |  {2}", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("       |       |     ");
            turns++;
        }
        // Esqueleto do campo
        static char[,] playField =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
        static int turns = 0;
        // Mudar o numero do campo
        public static void EnterXorO(Char playerSign, int input)
        {
            switch (input)
            {
                case 1:
                    playField[0, 0] = playerSign; break;
                case 2:
                    playField[0, 1] = playerSign; break;
                case 3:
                    playField[0, 2] = playerSign; break;
                case 4:
                    playField[1, 0] = playerSign; break;
                case 5:
                    playField[1, 1] = playerSign; break;
                case 6:
                    playField[1, 2] = playerSign; break;
                case 7:
                    playField[2, 0] = playerSign; break;
                case 8:
                    playField[2, 2] = playerSign; break;
                case 9:
                    playField[2, 2] = playerSign; break;
            }
        }
    }
}