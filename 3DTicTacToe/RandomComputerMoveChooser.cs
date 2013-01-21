using System;

namespace _3DTicTacToe
{
    /// <summary>
    /// Randomly chooses an index for the computer from the available ones. 
    /// </summary>
    class RandomComputerMoveChooser : IComputerMoveChooser
    {
        private static Random _randomMove;
        public int GetMove(BoardModel boardModel)
        {
            var openIndicies = boardModel.GetOpenIndicies();
            if(_randomMove == null)
            {
                _randomMove = new Random();   
            }
            return openIndicies[_randomMove.Next(openIndicies.Count)];
        }
    }
}
