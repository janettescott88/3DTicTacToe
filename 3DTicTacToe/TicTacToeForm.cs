using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _3DTicTacToe
{
    public partial class TicTacToeForm : Form
    {
        private List<ParallelogramButton> _squares;
        private Dictionary<int, HashSet<int>> _hoverDictionary;
        private Color _humanColor = Color.MediumBlue, _computerColor = Color.Red;
        private bool _showHelp;

        public TicTacToeForm()
        {
            InitializeComponent();
            _squares = new List<ParallelogramButton>();
            _hoverDictionary = new Dictionary<int, HashSet<int>>();
            _showHelp = true;
            DrawBoard();
            SetGameConfigurationEnabled(true);
        }

        #region Public Methods

        /// <summary>
        /// Update the UI to an ended state. 
        /// This is for the controller to not worry about implementation details.
        /// </summary>
        public void GameEnded()
        {
            SetGameConfigurationEnabled(true);
        }
        
        /// <summary>
        /// Modifies the color of the square to denote which player choose it, and disables it.  
        /// </summary>
        /// <param name="index">The index of the button the player selected</param>
        /// <param name="player">The player that made the selection</param>
        public void SetIndexTaken(int index, Player player)
        {
            _squares[index].ButtonColor = player == Player.Human ? _humanColor : _computerColor;
            _squares[index].Enabled = false;
        }

        #endregion

        #region Event Handlers
        private void square_Click(object sender, EventArgs e)
        {
            // Notify the game controller that the player selected a square
            GameController.Instance.SetIndexTaken(_squares.IndexOf((ParallelogramButton) sender));
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            SetGameConfigurationEnabled(false);
            ResetButtonColors();
            GameController.Instance.StartNewGame(this, GetSelectedPlayer(), GetSelectedDifficulty());
        }

        private void reset_Click(object sender, EventArgs e)
        {
            SetGameConfigurationEnabled(true);
        }

        private void square_Enter(object sender, EventArgs e)
        {
            if (!_showHelp) return;
            var index = _squares.IndexOf((ParallelogramButton) sender);
            //If the square hasn't been hovered over before, build up the dictionary of squares to highlight.
            if (!_hoverDictionary.ContainsKey(index))
            {
                var matchingSquares = new HashSet<int>();
                foreach (var combination in Constants.WinningCombinations)
                {
                    if (combination.Contains(index))
                    {
                        foreach(var combinationPiece in combination.Indicies)
                        {
                            matchingSquares.Add(combinationPiece);
                        }
                    }
                }
                _hoverDictionary.Add(index, matchingSquares);
            }
            ShowMatchingWinnersForIndex(index);
        }

        private void square_Leave(object sender, EventArgs e)
        {
            if (!_showHelp) return;
            //When done hovering, revert to the unselected color. 
            ResetColorsForOpenSquares();
        }

        private void showHelp_CheckedChanged(object sender, EventArgs e)
        {
            //Toggle wheter to highlight squares on hover. 
            _showHelp = showHelp.Checked;
        }
        #endregion 

        #region Private Methods

        /// <summary>
        /// Layout all of the button squares.
        /// </summary>
        private void DrawBoard()
        {
            for (var i = 0; i < Constants.boardWidth; i++)
            {
                for (var j = 0; j < Constants.boardWidth; j++)
                {
                    for (var k = 0; k < Constants.numBoards; k++)
                    {
                        var x = 200 + (k * 40) - (j * 10);
                        var y = 125 + ((j + ((i - 1) * 3)) * 30) + i * 20;

                        var square = new ParallelogramButton(x, y);

                        square.Click += square_Click;
                        square.MouseEnter += square_Enter;
                        square.MouseLeave += square_Leave;
                        Controls.Add(square);
                        _squares.Add(square);
                    }
                }
            }
        }

        /// <summary>
        /// Get the user selected game difficulty
        /// </summary>
        /// <returns>GameController.Difficulty</returns>
        private Difficulty GetSelectedDifficulty()
        {
            return easyDifficulty.Checked ? Difficulty.Easy : Difficulty.Hard;
        }

        /// <summary>
        /// Gets the user selected player to start the game
        /// </summary>
        /// <returns></returns>
        private Player GetSelectedPlayer()
        {
            return playerFirst.Checked ? Player.Human : Player.Computer;
        }

        /// <summary>
        /// Set all of the buttons used to configure the game, to enabled.
        /// Set all of the buttons used during the game, to the opposite. 
        /// </summary>
        /// <param name="enabled"></param>
        private void SetGameConfigurationEnabled(bool enabled)
        {
            startGame.Enabled = enabled;
            gameOrder.Enabled = enabled;
            difficultyLevels.Enabled = enabled;
            reset.Enabled = !enabled;
            SetGameSquaresEnabled(!enabled);
        }

        /// <summary>
        /// Revert all buttons to their default background color, 
        /// giving the appearance of unclaimed. 
        /// </summary>
        private void ResetButtonColors()
        {
            foreach (var square in _squares)
            {
                square.ButtonColor = DefaultBackColor;
            }
        }

        /// <summary>
        /// Set all of the buttons in the 3x3x3 grid to enabled. 
        /// </summary>
        /// <param name="enabled"></param>
        private void SetGameSquaresEnabled(bool enabled)
        {
            foreach (var square in _squares)
            {
                square.Enabled = enabled;               
            }
        }

        /// <summary>
        /// Given an index, this will change the button color of all other squares 
        /// that could be used as part of a winning row. 
        /// </summary>
        /// <param name="index"></param>
        private void ShowMatchingWinnersForIndex(int index)
        {
            foreach (var indexToHighlight in _hoverDictionary[index])
            {
                if (GameController.Instance.IndexAvailable(indexToHighlight))
                {
                    _squares[indexToHighlight].ButtonColor = Color.LightSkyBlue;
                }
            }
            //For the one that the mouse is over, make it a slightly darker color
            _squares[index].ButtonColor = Color.LightSeaGreen;
        }

        /// <summary>
        ///  Sets the color back to the default background color for any squares not chosen. 
        /// </summary>
        private void ResetColorsForOpenSquares()
        {
            for(var i = 0; i < Constants.numSquares; i++)
            {
                if (GameController.Instance.IndexAvailable(i))
                {
                    _squares[i].ButtonColor = DefaultBackColor;
                }
            }
        }
        #endregion
    }

    #region ParallelogramButton
    internal class ParallelogramButton : UserControl
    {
        private Color _buttonColor;
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set 
            { 
                _buttonColor = value;
                Refresh();
            }
        }

        public ParallelogramButton(int x, int y)
        {
            Location = new Point(x, y);
            Size = new Size(40, 25);
            ButtonColor = DefaultBackColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var pen = new Pen(Color.Black);

            var points = new Point[4];
            const int offset = 10;

            points[0] = new Point(offset - 1, 0);
            points[1] = new Point(Size.Width -1 , 0);
            points[2] = new Point(Size.Width - offset, Size.Height - 1);
            points[3] = new Point(0, Size.Height - 1);

            graphics.DrawPolygon(pen, points);
            graphics.FillPolygon(new SolidBrush(ButtonColor), points);
            pen.Dispose();
        }
    #endregion
    }
}
