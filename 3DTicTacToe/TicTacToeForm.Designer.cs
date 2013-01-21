namespace _3DTicTacToe
{
    partial class TicTacToeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startGame = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.gameOrder = new System.Windows.Forms.GroupBox();
            this.playerFirst = new System.Windows.Forms.RadioButton();
            this.computerFirst = new System.Windows.Forms.RadioButton();
            this.difficultyLevels = new System.Windows.Forms.GroupBox();
            this.hardDifficulty = new System.Windows.Forms.RadioButton();
            this.easyDifficulty = new System.Windows.Forms.RadioButton();
            this.showHelp = new System.Windows.Forms.CheckBox();
            this.gameOrder.SuspendLayout();
            this.difficultyLevels.SuspendLayout();
            this.SuspendLayout();
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(12, 253);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(91, 32);
            this.startGame.TabIndex = 0;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(12, 291);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(91, 31);
            this.reset.TabIndex = 1;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // gameOrder
            // 
            this.gameOrder.Controls.Add(this.playerFirst);
            this.gameOrder.Controls.Add(this.computerFirst);
            this.gameOrder.Location = new System.Drawing.Point(12, 13);
            this.gameOrder.Name = "gameOrder";
            this.gameOrder.Size = new System.Drawing.Size(145, 85);
            this.gameOrder.TabIndex = 2;
            this.gameOrder.TabStop = false;
            this.gameOrder.Text = "Who goes first?";
            // 
            // playerFirst
            // 
            this.playerFirst.AutoSize = true;
            this.playerFirst.Checked = true;
            this.playerFirst.Location = new System.Drawing.Point(7, 21);
            this.playerFirst.Name = "playerFirst";
            this.playerFirst.Size = new System.Drawing.Size(54, 21);
            this.playerFirst.TabIndex = 1;
            this.playerFirst.TabStop = true;
            this.playerFirst.Text = "You";
            this.playerFirst.UseVisualStyleBackColor = true;
            // 
            // computerFirst
            // 
            this.computerFirst.AutoSize = true;
            this.computerFirst.Location = new System.Drawing.Point(6, 48);
            this.computerFirst.Name = "computerFirst";
            this.computerFirst.Size = new System.Drawing.Size(90, 21);
            this.computerFirst.TabIndex = 0;
            this.computerFirst.Text = "Computer";
            this.computerFirst.UseVisualStyleBackColor = true;
            // 
            // difficultyLevels
            // 
            this.difficultyLevels.Controls.Add(this.hardDifficulty);
            this.difficultyLevels.Controls.Add(this.easyDifficulty);
            this.difficultyLevels.Location = new System.Drawing.Point(12, 104);
            this.difficultyLevels.Name = "difficultyLevels";
            this.difficultyLevels.Size = new System.Drawing.Size(145, 80);
            this.difficultyLevels.TabIndex = 3;
            this.difficultyLevels.TabStop = false;
            this.difficultyLevels.Text = "Difficulty";
            // 
            // hardDifficulty
            // 
            this.hardDifficulty.AutoSize = true;
            this.hardDifficulty.Location = new System.Drawing.Point(6, 48);
            this.hardDifficulty.Name = "hardDifficulty";
            this.hardDifficulty.Size = new System.Drawing.Size(60, 21);
            this.hardDifficulty.TabIndex = 1;
            this.hardDifficulty.Text = "Hard";
            this.hardDifficulty.UseVisualStyleBackColor = true;
            // 
            // easyDifficulty
            // 
            this.easyDifficulty.AutoSize = true;
            this.easyDifficulty.Checked = true;
            this.easyDifficulty.Location = new System.Drawing.Point(7, 21);
            this.easyDifficulty.Name = "easyDifficulty";
            this.easyDifficulty.Size = new System.Drawing.Size(60, 21);
            this.easyDifficulty.TabIndex = 0;
            this.easyDifficulty.TabStop = true;
            this.easyDifficulty.Text = "Easy";
            this.easyDifficulty.UseVisualStyleBackColor = true;
            // 
            // showHelp
            // 
            this.showHelp.AutoSize = true;
            this.showHelp.Checked = true;
            this.showHelp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showHelp.Location = new System.Drawing.Point(18, 199);
            this.showHelp.Name = "showHelp";
            this.showHelp.Size = new System.Drawing.Size(105, 21);
            this.showHelp.TabIndex = 4;
            this.showHelp.Text = "Show Help?";
            this.showHelp.UseVisualStyleBackColor = true;
            this.showHelp.CheckedChanged += new System.EventHandler(this.showHelp_CheckedChanged);
            // 
            // TicTacToeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 493);
            this.Controls.Add(this.showHelp);
            this.Controls.Add(this.difficultyLevels);
            this.Controls.Add(this.gameOrder);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.startGame);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicTacToeForm";
            this.ShowIcon = false;
            this.Text = "3D Tic Tac Toe";
            this.gameOrder.ResumeLayout(false);
            this.gameOrder.PerformLayout();
            this.difficultyLevels.ResumeLayout(false);
            this.difficultyLevels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.GroupBox gameOrder;
        private System.Windows.Forms.RadioButton playerFirst;
        private System.Windows.Forms.RadioButton computerFirst;
        private System.Windows.Forms.GroupBox difficultyLevels;
        private System.Windows.Forms.RadioButton hardDifficulty;
        private System.Windows.Forms.RadioButton easyDifficulty;
        private System.Windows.Forms.CheckBox showHelp;
    }
}

