using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect_4
{
	/* Name: Reggie Telemaque 
	 * 
	 * Date: 02/18/2020
	 *  
	 *  Program: Connect 4
	 *
	 *  Purpose: A Connect 4 program that takes user input and changes pictureboxes corresponding to the users choice.
	 * 
	 */

	public partial class Connect4 : Form
	{
		// Global Variables
		int turn_count;
		int Turns = 0;
		bool playerTurn = true;
		string[,] Connect4Grid = new string[6, 7];
		int row = -1;
		int column = -1;

		Diagnostics diagWindow;
		bool viewArrayContents = false;
		bool viewPatternBuild = false;

		public Connect4()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clears the array when game is reset. 
		/// </summary>
		/// <returns> Col = 0, and row = 0
		private void ClearTheBoardArray()
		{
			for (int row = 0; row < Connect4Grid.GetLength(0); row++)
			{
				for (int col = 0; col < Connect4Grid.GetLength(1); col++)
				{
					Connect4Grid[row, col] = "-";
				}
			}
		}

		/// <summary>
		/// Turns count to zero for when game is reset.
		/// </summary>
		/// <returns>Turn_Count to value 0.
		private void ButtonClicked(object sender, EventArgs e)
		{
			// Cast object to picturebox
			PictureBox button = (PictureBox)sender;

			// Set string to find tag in picture box
			int row = int.Parse(button.Tag.ToString().Substring(1, 1));
			int column = int.Parse(button.Tag.ToString().Substring(3, 1));

			button.Image = SetImage();

			button.Enabled = false;

			UpdateTheBoardArray(row, column);

			PlayerID();

			if (CheckWinner())
			{
				// Announce Winner
				ResetBoard("Disable");
			}
			else
			{
				playerTurn = !playerTurn;
			}

			playerTurn = !playerTurn;
		}

		private Bitmap SetImage()
		{
			return (playerTurn) ? Properties.Resources.Red_Coin : Properties.Resources.White_Coin;
		}

		/// <summary>
		/// This method sets picture boxes to be enabled when the game is reset.
		/// </summary>
		/// <param name="SetEnabled">""Full" to be usable when game is reset.
		///                           "Disable" means disable the picture boxes.</param>
		private void MassSetPictureBoxEnable(bool SetEnabled)
		{
			foreach (Control controlUsed in Controls["grpGameBoard"].Controls)
			{
				if (controlUsed is PictureBox) controlUsed.Enabled = SetEnabled;
			}
		}

		/// <summary>
		/// Prcoedure for clearing pictureboxes when game is recet
		/// </summary>
		/// <returns> null picture box
		private void MassSetPictureBoxImage()
		{
			foreach (Control controlUsed in Controls["grpGameBoard"].Controls)
			{
				if (controlUsed is PictureBox)
				{
					((PictureBox)controlUsed).Image = null;
				}
			}

		}

		/// <summary>
		/// Based on player turn determines the value to be placed in the array 
		/// </summary>
		/// <returns>"R" for the Red Coin player, "W" for White Coin</returns>
		private string SetPlayerValue()
		{
			return (playerTurn) ? "R" : "W";
		}


		/// <summary>
		/// Turns count to zero for when game is reset/
		/// </summary>
		/// <returns>Turn_Count to value 0.
		private void TurnCountReset()
		{
			turn_count = 0;
		}


		private string GenerateColumnPattern()
		{
			string pattern = "";

			for (int columnIndex = 0; columnIndex < Connect4Grid.GetLength(1); columnIndex++)
			{
				pattern += Connect4Grid[row, columnIndex];
			}
			if (viewPatternBuild)
			{
				diagWindow.DisplayLine("Row Pattern: " + pattern);
			}

			return pattern;
		}

		private string GenerateRowPattern()
		{
			return "";
		}

		private string GenerateDiagonal1Pattern()
		{
			return "";
		}

		private string GenerateDiagonal2Upper(int rowStart, int columnStart)
		{
			string pattern = "";

			rowStart++;
			columnStart++;

			while (rowStart < Connect4Grid.GetLength(0) && columnStart < Connect4Grid.GetLength(1))
			{
				pattern += Connect4Grid[row, column];

				rowStart++;
				columnStart++;
			}

			return pattern;
		}

		private string GenerateDiagonal2Pattern()
		{
			string partUpper = GenerateDiagonal2Upper(row, column);
			string partCenter = Connect4Grid[row, column];
			string partLower = "";

			string pattern = partLower + partCenter + partUpper;

			if (viewPatternBuild)
			{
				diagWindow.DisplayLine(Environment.NewLine);
				diagWindow.DisplayLine("Diagonal 2:");
				diagWindow.DisplayLine("  Upper: " + partUpper);
				diagWindow.DisplayLine(" Center: " + partCenter);
				diagWindow.DisplayLine("  Lower: " + partLower);
				diagWindow.DisplayLine("    All:  " + pattern);
			}
			return "";
		}

		/// <summary>
		/// Chekcs for winner corresponding if a user has 4 connecting pictureboxes.
		/// </summary>
		/// <returns> A messagebox to tell if a user is a winner.
		private bool CheckWinner()
		{
			string rowPattern = GenerateRowPattern();
			string columnPattern = GenerateColumnPattern();
			string diagonal1Pattern = GenerateDiagonal1Pattern();
			string diagonal2Pattern = GenerateDiagonal2Pattern();

			if (rowPattern.Contains("WWWW") || rowPattern.Contains("RRRR"))
			{
				return true;
			}
			else if (columnPattern.Contains("WWWW") || columnPattern.Contains("RRRR"))
			{
				return true;
			}
			else if (diagonal1Pattern.Contains("WWWW") || diagonal1Pattern.Contains("RRRR"))
			{
				return true;
			}
			else if (diagonal2Pattern.Contains("WWWW") || diagonal2Pattern.Contains("RRRR"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// Checks if both name textboxes are filled in order to start a game. 
		/// </summary>
		/// <returns> Start game to be "Enabled" or "Disabled".
		private void AllTermsEntered()
		{
			if (txtPlayer1.Text != "" && txtPlayer2.Text != "")
			{
				btnStartGame.Enabled = true;
			}
			else
			{
				btnStartGame.Enabled = false;
			}
		}

		/// <summary>
		/// This method resets the game board based on the type of reset specified.
		/// </summary>
		/// <param name="typeOfReset">"Full" means all properties will be set to default.
		///                           "Disable" means disable the board at game win.</param>
		private void ResetBoard(string typeOfReset)
		{
			typeOfReset = typeOfReset.ToUpper();

			grpGameBoard.Enabled = true;

			foreach (Control buttonControl in Controls["grpGameBoard"].Controls)
			{
				if (buttonControl is Button)
				{
					if (typeOfReset == "DISABLE")
					{
						buttonControl.Enabled = false;
					}
					else
					{
						buttonControl.Enabled = true;
					}
				}
			}
		}

		/// <summary>
		/// Procedure to reset gameboard if the game is reset through menu strip. 
		/// </summary>
		private void ResetGameBoard()
		{
			ResetBoard("Full");
			ClearTheBoardArray();
		}

		/// <summary>
		/// TMenu strip click when game needs to be reset or a new game is initiallized. 
		/// </summary>
		private void msReset_Click(object sender, EventArgs e)
		{
			MassSetPictureBoxEnable(true);
			MassSetPictureBoxImage();
			TurnCountReset();
			ClearTheBoardArray();
			ResetGameBoard();

			grpGameBoard.Enabled = false;

			txtPlayer1.Text = null;
			txtPlayer2.Text = null;

			btnStartGame.Enabled = false;

			Turns = 0;
		}

		//private void SetEnableProperty(bool howToSet)
		//{
		//	foreach (Control controlUsed in Controls["grpGameBoard}"].Controls)
		//	{
		//		if (controlUsed is PictureBox)
		//			if (controlUsed.Tag == "(0,0)")
		//			{
		//				PictureBox picturetodown = (PictureBox)controlUsed;
		//			}
		//	}

		//}

		/// <summary>
		/// This method drops the corresponding coin in the row that the user picked.
		/// </summary>
		/// <param name="columnClickedIn">"Full" to be drop in the column that the user picked
		///                           "Disable" means that the coin will drop anywhere.</param>
		private int GetDropToRow(int columnClickedIn)
		{
			int row = 0;

			for (row = 0; row < Connect4Grid.GetLength(1); row++)
			{
				if (Connect4Grid[row, columnClickedIn] == "-")
				{
					break;
				}
			}

			return row;
		}

		/// <summary>
		/// This method drops the corresponding coin in the row that the user picked.
		/// </summary>
		/// <param name="column">"Full" to be drop in the column that the user picked
		///                           "Disable" means that the coin will drop anywhere.</param>
		private int DropTheCoin(int column)
		{
			int rowToPlaceCoinIn = GetDropToRow(column);

			string nameOfPictureBox = "btn" + rowToPlaceCoinIn + column;

			PictureBox pictureBoxforCoin = (PictureBox)Controls["grpGameBoard"].Controls[nameOfPictureBox];

			pictureBoxforCoin.Image = SetImage();
			pictureBoxforCoin.Enabled = true;

			return rowToPlaceCoinIn;
		}

		/// <summary>
		/// This method updates the board array to the diagnostic window.
		/// </summary>
		/// <param name="rowToUse">"Full" to 
		///                           "Disable" means that the coin will drop anywhere.</param>
		///                         
		private void UpdateTheBoardArray(int rowToUse, int columnToUse)
		{
			Connect4Grid[rowToUse, columnToUse] = SetPlayerValue();

			if (viewArrayContents)
			{
				diagWindow.ClearDisplay();
				diagWindow.DisplayArray(Connect4Grid);
		
			}
		}

		/// <summary>
		/// Method to change a coreesponding label to read textbox names corresponding to whos turn it is. 
		/// </summary>
		/// <returns> lblTurn  = Name of player.
		private void PlayerID()
		{
			if (playerTurn)
			{
				lblTurn.Text = txtPlayer1.Text;
			}
			else
			{
				lblTurn.Text = txtPlayer2.Text;
			}
		}

		/// <summary>
		/// Diagonostics click to see array.
		/// </summary>
		/// <returns> Show diagWindow
		private void msDiagnostics_Click(object sender, EventArgs e)
		{
			diagWindow = new Diagnostics();

			diagWindow.Show();

			diagWindow.StartPosition = FormStartPosition.Manual;
			diagWindow.Location = new Point(this.Location.X - 538, this.Location.Y);

			viewArrayContents = true;

			// display the current contents of the array
			diagWindow.DisplayArray(Connect4Grid);
		}

		/// <summary>
		/// Validated if both textboxes are filled. 
		/// </summary>
		private new void Validating(object sender, CancelEventArgs e)
		{
			AllTermsEntered();
		}

		/// <summary>
		/// Button click event for group box to be enabled to start game. 
		/// </summary>
		/// <returns> Connect 4 group box is enabled.
		private void btnStartGame_Click(object sender, EventArgs e)
		{
			grpGameBoard.Enabled = true;
		}

		// Load event to clear board array and reset board on load. 
		private void Connect4_Load(object sender, EventArgs e)
		{
			ClearTheBoardArray();
			ResetGameBoard();
		}
	}
}