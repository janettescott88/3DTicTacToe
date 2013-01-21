using System.Collections.Generic;

namespace _3DTicTacToe
{
    public class BoardModel
    {
        private List<Player> _board;
        private List<int> openIndicies;

        /// <summary>
        /// Build an empty BoardModel, all indicies will be set to Player.None
        /// </summary>
        public BoardModel()
        {
            _board = new List<Player>();
            for(var i = 0; i < Constants.numSquares; i++)
            {
                _board.Add(Player.None);
            }
        }

        /// <summary>
        /// Construct a BoardModel copy of the given baseBoardModel
        /// </summary>
        /// <param name="baseBoardModel">The BoardModel to copy.</param>
        public BoardModel(BoardModel baseBoardModel)
        {
            _board = new List<Player>(baseBoardModel._board);
        }

        #region Public Methods
        /// <summary>
        /// Loops through the board, and gets the integer position of all of the spots 
        /// that have not been taken by the player or computer
        /// </summary>
        /// <returns>A list of integer positions not yet chosen</returns>
        public List<int> GetOpenIndicies()
        {
            if (openIndicies == null)
            {
                openIndicies = new List<int>();

                for (var i = 0; i < _board.Count; i++)
                {
                    if (_board[i] == Player.None)
                    {
                        openIndicies.Add(i);
                    }
                }
            }
            return openIndicies;
        }

        /// <summary>
        /// Updates the state of an open spot on the board. 
        /// </summary>
        /// <param name="indexToAdd">The index of the spot to update</param>
        /// <param name="player">The player whom the spot belongs to now</param>
        public void UpdatePositionAtIndex(int indexToAdd, Player player)
        {
            if ((indexToAdd >= 0) && (indexToAdd < Constants.numSquares) && (_board[indexToAdd] == Player.None) && (player != Player.None))
            {
                openIndicies = null;
                _board[indexToAdd] = player;
            }
        }

        /// <summary>
        /// Loops through all of the possible winning combinations, 
        /// and checks to see if all 3 spots belong to either the human or computer.
        /// </summary>
        /// <returns>Returns the winner if there is one, otherwise Player.None</returns>
        public Player CheckForWinner()
        {
            foreach (var combination in Constants.WinningCombinations)
                {
                    var indicies = combination.Indicies;
                    if (_board[indicies[0]] == _board[indicies[1]] && _board[indicies[0]] == _board[indicies[2]] && _board[indicies[0]] != Player.None)
                    {
                        return _board[indicies[0]];
                    }
                }
            
            return Player.None;
        }

        /// <summary>
        /// Checks if the given index belongs to the given player
        /// </summary>
        /// <param name="index"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool DoesIndexBelongToPlayer(int index, Player player)
        {
            return _board[index] == player;
        }
        #endregion
    }
}
