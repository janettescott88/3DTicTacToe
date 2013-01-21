using System.Collections.Generic;
using System.Linq;

namespace _3DTicTacToe
{
    class HypotheticalBoard
    {
        public List<HypotheticalBoard> ChildBoards { get; private set; }
        public int Index { get; private set; }

        private BoardModel _board;
        private int _depth;
        private Player _player;
        private int? _score;
        private const int maxDepth = 2;

        /// <summary>
        /// Creates a board using the given BoardModel in which the given player
        /// will take the given index. 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="player"></param>
        /// <param name="index"></param>
        public HypotheticalBoard(BoardModel board, Player player, int index) : this(0, board, player, index)
        {
        }

        /// <summary>
        /// Keeping depth private, because external uses do not need to worry about it. 
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="board"></param>
        /// <param name="player"></param>
        /// <param name="index"></param>
        private HypotheticalBoard(int depth, BoardModel board, Player player, int index)
        {
            _depth = depth;
            _board = board;
            _player = player;
            Index = index;

            _board.UpdatePositionAtIndex(Index, _player);

            // Continue to fill the tree of next possible moves
            // Stop the recursion when there are no open spots left, 
            // or we have reached the max depth of recursion.
            if (_depth < maxDepth)
            {
                // Get the open indicies for the board where there are moves are still available
                var openIndicies = _board.GetOpenIndicies();
                if (openIndicies.Count > 0)
                {
                    ChildBoards = new List<HypotheticalBoard>();
                    foreach (var openIndex in openIndicies)
                    {
                        ChildBoards.Add(new HypotheticalBoard(depth + 1, new BoardModel(board),
                                                               Utilities.SwitchPlayer(_player), openIndex));
                    }
                }
            }
        }

        #region Public Methods
        /// <summary>
        /// Calculate the score
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            if (_score == null)
            {
                //For leaves and winning boards, this should evaluate itself. 
                if(ChildBoards == null || (_board.CheckForWinner() != Player.None))
                {
                    _score = 0;
                    foreach (var winningCombination in Constants.WinningCombinations)
                    {
                        //Calculate how many spots in the combination belong to each player.
                        var humanIndicies = Matches(Player.Human, winningCombination);
                        var computerIndicies = Matches(Player.Computer, winningCombination);

                        //Computer squares are positive, player squares are negative
                        _score += PointsForCount(computerIndicies);
                        _score -= PointsForCount(humanIndicies);
                    }
                    return (int) _score;
                }

                //Default best score to an extreme value, so that this is definitely updated. 
                var bestChildScore = _player == Player.Computer ? int.MaxValue : int.MinValue;
                foreach (var hypotheticalBoard in ChildBoards)
                {
                    //If this hypothetical board represents a computer turn, take the lowest score.
                    //This is assuming that the player will make the best move for themself on their turn.
                    if((_player == Player.Computer && hypotheticalBoard.GetScore() < bestChildScore)
                        || (_player == Player.Human && hypotheticalBoard.GetScore() > bestChildScore))
                    {
                        bestChildScore = hypotheticalBoard.GetScore();
                    }
                }
                _score = bestChildScore;
            }
            return (int) _score;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// In a given winning combintation, check how many indicies belong to the given player
        /// </summary>
        /// <param name="player"></param>
        /// <param name="winningCombination"></param>
        /// <returns>Value between 0 and 3.</returns>
        private int Matches(Player player, WinningCombination winningCombination)
        {
            return winningCombination.Indicies.Count(index => _board.DoesIndexBelongToPlayer(index, player));
        }

        //Weight it so that n in a row is worth exponentially more than n-1 in a row. 
        private int PointsForCount(int count)
        {
            switch (count)
            {
                case 1:
                    return 1;
                case 2:
                    return 10;
                case 3:
                    return 100;
                default:
                    return 0;
            }
        }
        #endregion
    }
}
