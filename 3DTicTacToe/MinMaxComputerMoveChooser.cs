using System;

namespace _3DTicTacToe
{
    /// <summary>
    /// Uses the min-max algorithm to select the optimal position for the computer's next move. 
    /// </summary>
    class MinMaxComputerMoveChooser:IComputerMoveChooser
    {
        private static Random _random;

        public int GetMove(BoardModel boardModel)
        {
            var openIndicies = boardModel.GetOpenIndicies();
            if (openIndicies.Count == 0)
            {
                return -1;
            }

            HypotheticalBoard best = null;
            //Generate a tree of HypotheticalBoards for each open spot to determine which move is the best. 
            foreach (var index in openIndicies)
            {
                var board = new HypotheticalBoard(new BoardModel(boardModel), Player.Computer, index);
                if ((best == null) || board.GetScore() > best.GetScore())
                {
                    best = board;
                } else if (best.GetScore() == board.GetScore())
                {
                    //Randomly decide whether to use the new board, or the existing best board. 
                    //This will make the game a bit more random, while still using strategy.
                    if (_random == null)
                    {
                        _random = new Random();
                    }
                    if (_random.NextDouble() < 0.25)
                    {
                        best = board;
                    }
                }
            }
            //best can never be null, it will be set in the first pass of the for loop. 
            return best.Index;
        }
    }
}
