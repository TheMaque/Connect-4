﻿using System;
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

		// Procedure for enabling or disabling a picture box to be clicked or whe  game is reset
		private void MassSetPictureBoxEnable(bool howToSet)
		{
			foreach (Control controlUsed in Controls)
			{
				if (controlUsed is PictureBox) controlUsed.Enabled = howToSet;
			}
		}

		// Procedure for clearing of picture boxes when game is reset
		private void MassSetPictureBoxImage()
		{
			foreach (Control controlUsed in Controls)
			{
				if (controlUsed is PictureBox)
				{
					((PictureBox)controlUsed).Image = null;
				}
			}

		}
		
		// Reset turns
		private void TurnCountReset()
		{
			turn_count = 0;
		}


		private void msReset_Click(object sender, EventArgs e)
		{
			MassSetPictureBoxEnable(true);
			MassSetPictureBoxImage();
			TurnCountReset();

		}

		private void msDiagnostics_Click(object sender, EventArgs e)
		{
			Diagnostics diagWindow = new Diagnostics();

			diagWindow.Show();
		}
	}
}