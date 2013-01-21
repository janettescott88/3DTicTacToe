namespace _3DTicTacToe
{
    /// <summary>
    /// Used to analyze the current board, and select the next move for the computer. 
    /// </summary>
    interface IComputerMoveChooser
    {
        /// <param name="boardModel">The current game board</param>
        /// <returns>The index that the computer selects</returns>
        int GetMove(BoardModel boardModel);
    }
}
