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

		Diagnostics diagWindow;
		bool viewArrayContents = false;
		bool viewPatternBuild = false;

		public Connect4()
		{
			InitializeComponent();
		}

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

			\

			playerTurn = !playerTurn;
		}

		/// <summary>
		/// This method clears the Game Board Array in preparation for a new game
		/// </summary>
		//private void ClearTheBoardArray()
		//{
		//	for (int row = 0; row < Connect4Grid.GetLength(0); row++)
		//	{
		//		for (int col = 0; col < Connect4Grid.GetLength(1); col++)
		//		{
		//		 Connect4Grid[row, col] = "-";
		//		}
		//	}
		//}

		private Bitmap SetImage()
		{
			return (playerTurn) ? Properties.Resources.Red_Coin : Properties.Resources.White_Coin;
		}

		// Procedure for enabling or disabling a picture box to be clicked or whe  game is reset
		private void MassSetPictureBoxEnable(bool SetEnabled)
		{
			foreach (Control controlUsed in Controls["grpGameBoard"].Controls)
			{
				if (controlUsed is PictureBox) controlUsed.Enabled = SetEnabled;
			}
		}

		// Procedure for clearing of picture boxes when game is reset
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


		// Reset turns
		private void TurnCountReset()
		{
			turn_count = 0;
		}

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

		private void msReset_Click(object sender, EventArgs e)
		{
			MassSetPictureBoxEnable(true);
			MassSetPictureBoxImage();
			TurnCountReset();
			ClearTheBoardArray();

			grpGameBoard.Enabled = false;

			txtPlayer1.Text = null;
			txtPlayer2.Text = null;

			btnStartGame.Enabled = false;

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

		private int DropTheCoin(int column)
		{
			int rowToPlaceCoinIn = GetDropToRow(column);

			string nameOfPictureBox = "btn" + rowToPlaceCoinIn + column;

			PictureBox pictureBoxforCoin = (PictureBox)Controls["grpGameBoard"].Controls[nameOfPictureBox];

			pictureBoxforCoin.Image = SetImage();
			pictureBoxforCoin.Enabled = true;

			return rowToPlaceCoinIn;
		}

		private void UpdateTheBoardArray(int rowToUse, int columnToUse)
		{
			Connect4Grid[rowToUse, columnToUse] = SetPlayerValue();

			if (viewArrayContents)
			{
				diagWindow.ClearDisplay();
				diagWindow.DisplayArray(Connect4Grid);
		
			}
		}

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

		private new void Validating(object sender, CancelEventArgs e)
		{
			AllTermsEntered();
		}

		private void btnStartGame_Click(object sender, EventArgs e)
		{
			grpGameBoard.Enabled = true;
		}

		private void Connect4_Load(object sender, EventArgs e)
		{
			ClearTheBoardArray();
		}
	}
}