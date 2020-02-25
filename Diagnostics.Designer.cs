namespace Connect_4
{
	partial class Diagnostics
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
			this.txtDisplayWindow = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtDisplayWindow
			// 
			this.txtDisplayWindow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDisplayWindow.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDisplayWindow.Location = new System.Drawing.Point(0, 0);
			this.txtDisplayWindow.Multiline = true;
			this.txtDisplayWindow.Name = "txtDisplayWindow";
			this.txtDisplayWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDisplayWindow.Size = new System.Drawing.Size(580, 498);
			this.txtDisplayWindow.TabIndex = 1;
			// 
			// Diagnostics
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(580, 498);
			this.Controls.Add(this.txtDisplayWindow);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Diagnostics";
			this.Text = "Diagnostics";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtDisplayWindow;
	}
}