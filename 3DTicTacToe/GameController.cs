using System;
using System.Windows.Forms;

namespace _3DTicTacToe
{
    class GameController
    {
        //This will only ever need one copy of this controller, so just uses a singleton. 
        private static GameController _instance;
        public static GameController Instance
        {
            get { return _instance ?? (_instance = new GameController()); }
        }

        private TicTacToeForm _userInterface;
        private Player _playerTurn;
        private BoardModel _boardModel;
        private IComputerMoveChooser _moveChooser;

        private GameController()
        {           
        }
        
        #region Public Methods
        /// <summary>
        /// Begin new game. 
        /// </summary>
        /// <param name="userInterface">Instance of form that the controller will send various game state updates to</param>
        /// <param name="startingPlayer">Who begins the game, must be Human or Computer</param>
        /// <param name="difficulty">The level of difficulty</param>
        public void StartNewGame(TicTacToeForm userInterface, Player startingPlayer = Player.Human, Difficulty difficulty=Difficulty.Easy)
        {
            if (startingPlayer == Player.None)
            {
                throw new ArgumentException("Player must be either human or computer.");
            }
            _boardModel = new BoardModel();
            _userInterface = userInterface;
            _playerTurn = startingPlayer;

            //If the difficulty is easy, then the computer will choose indicies at random.
            //If the diffuculty is hard, the computer uses a min-max algorithm to choose the optimal index. 
            switch(difficulty)
            {
                case Difficulty.Easy:
                    _moveChooser = new RandomComputerMoveChooser();
                    break;
                case Difficulty.Hard:
                    _moveChooser = new MinMaxComputerMoveChooser();
                    break;
            }

            if(_playerTurn == Player.Computer)
            {
                DoComputerTurn();
            } 
        }

        /// <summary>
        /// Awards the given index to the player, checks for a winner, and switches turns.
        /// </summary>
        /// <param name="index">The index of the square taken</param>
        public void SetIndexTaken (int index)
        {
            //Update internal model and user interface
            _boardModel.UpdatePositionAtIndex(index, _playerTurn);
            _userInterface.SetIndexTaken(index, _playerTurn);

            var winner = _boardModel.CheckForWinner();

            if(winner != Player.None)
            {
                _userInterface.GameEnded();
                MessageBox.Show(winner == Player.Human ? "Congratulations! You won!" : "The computer won. Try again!");
            }
            else
            {
                //Check if there was a tie
                if (_boardModel.GetOpenIndicies().Count == 0)
                {
                    _userInterface.GameEnded();
                    MessageBox.Show(@"There are no spots left. It's a tie!");
                }
                //Switch players and continue the game. 
                else
                {
                    _playerTurn = Utilities.SwitchPlayer(_playerTurn);
                    if (_playerTurn == Player.Computer)
                    {
                        DoComputerTurn();
                    }
                }
            }
        }


        /// <returns>Returns true if the index isn't chosen, false otherwise.</returns>
        public bool IndexAvailable(int index)
        {
            return _boardModel.GetOpenIndicies().Contains(index);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Use the IComputerMoveChooser to select the next computer move
        /// </summary>
        private void DoComputerTurn()
        {
            SetIndexTaken(_moveChooser.GetMove(new BoardModel(_boardModel)));
        }
        #endregion
    }
}
