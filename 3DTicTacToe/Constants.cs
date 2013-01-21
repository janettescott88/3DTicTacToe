using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;

namespace _3DTicTacToe
{
    class Constants
    {
        public const int boardWidth = 3, numBoards = 3, numAnswers = 49;
        public const int numSquares = boardWidth * boardWidth * numBoards;

        private static List<WinningCombination> _winningCombinations;
        /// <summary>
        /// The list of all possible index triplets that enable a player to win the game. 
        /// </summary>
        public static List<WinningCombination> WinningCombinations
        {
            get
            {
                if (_winningCombinations == null)
                {
                    //Lazily initialize from text file. 
                    _winningCombinations = new List<WinningCombination>();

                    foreach (var line in Properties.Resources.WinningCombinations.Split(new string[] {"\r\n"}, StringSplitOptions.None))
                    {
                        //Allow comments in text file
                        if (line.StartsWith("#") || line.Trim().Length == 0)
                        {
                            continue;
                        }

                        var combination = line.Trim().Split(new[]{", "}, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            _winningCombinations.Add(new WinningCombination(int.Parse(combination[0]),
                                                                            int.Parse(combination[1]),
                                                                            int.Parse(combination[2])));
                        } 
                        catch (Exception e)
                        {
                            //The list of winning combinations is invalid, so the game cannot be won. 
                            //Crashing the game is okay in this case, because this is needed. 
                            throw new Exception("The data in the text file is corrupt.", e);
                        }
                    }
                }
                return _winningCombinations;
            }
        }
    }
}
