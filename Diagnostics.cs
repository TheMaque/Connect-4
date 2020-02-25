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
	public partial class Diagnostics : Form
	{
		public Diagnostics()
		{
			InitializeComponent();
		}
        /// <summary>
        /// Displays the provided line in the diagnostic window.
        /// </summary>
        /// <param name="dataToPrint">The data to display.</param>
        public void DisplayLine(string dataToPrint)
        {
            txtDisplayWindow.Text += dataToPrint + Environment.NewLine;
        }

        /// <summary>
        /// Clear the display in the diagnostic window
        /// </summary>
        public void ClearDisplay()
        {
            txtDisplayWindow.Text = "";
        }

        /// <summary>
        /// Constructs the proper formatting to display an element from the array.
        /// </summary>
        /// <param name="element">Array element to display</param>
        /// <returns>Formatted output</returns>
        private string DisplayElement(string element)
        {
            return " " + element + "  | ";
        }

        /// <summary>
        /// Display the contents of the provided array in the diagnostic window.
        /// </summary>
        /// <param name="boardArrayToDisplay">Array to display</param>
        public void DisplayArray(string[,] boardArrayToDisplay)
        {
            string tableLine = "       +-----+-----+-----+-----+-----+-----+-----+" + Environment.NewLine;
            string arrayContents = tableLine;

            for (int row = boardArrayToDisplay.GetLength(0) - 1; row >= 0; row--)
            {
                arrayContents += "Row " + row + ": | ";

                for (int column = 0; column < boardArrayToDisplay.GetLength(1); column++)
                {
                    arrayContents += DisplayElement(boardArrayToDisplay[row, column]);
                }

                arrayContents += Environment.NewLine;
                arrayContents += tableLine;
            }

            arrayContents += "         0     1     2     3     4     5     6  " + Environment.NewLine;
            arrayContents += "        col   col   col   col   col   col   col ";

            txtDisplayWindow.Text = arrayContents;
            txtDisplayWindow.Select(0, 0);
        }
    }
}
