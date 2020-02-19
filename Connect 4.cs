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
	public partial class Connect4 : Form
	{
		public Connect4()
		{
			InitializeComponent();
		}

		// Global Variables
		int turn_count;
		int Turns = 0;
		bool playerTurn = true;
		int[,] Connect4Grid = new int [7,6];

		private void ButtonClicked(object sender, EventArgs e)
		{
			// Cast object to picturebox
			PictureBox button = (PictureBox)sender;

			// Set string to find tag in picture box
			int row = int.Parse(button.Tag.ToString().Substring(1, 1));
			int column = int.Parse(button.Tag.ToString().Substring(3, 1));

			button.Image = SetImage();

			button.Enabled = false;

			playerTurn = !playerTurn;
		}
		private Bitmap SetImage()
		{
			return (playerTurn) ? Properties.Resources.Red_Coin : Properties.Resources.White_Coin;
		}
	}
}
