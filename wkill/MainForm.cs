/*
 * Created by SharpDevelop.
 * Date: 17.02.2015
 * Time: 16:57
 */
using System;
using System.Resources;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace wkill
{
	/// <summary>
	/// A transparent form that overlays the entire screen. Calls back to the Program on clicks.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			
			// Overlay _everything_, even multiple monitors
			int screenLeft = SystemInformation.VirtualScreen.Left;
	        int screenTop = SystemInformation.VirtualScreen.Top;
	        int screenWidth = SystemInformation.VirtualScreen.Width;
	        int screenHeight = SystemInformation.VirtualScreen.Height;    
	        this.Size = new System.Drawing.Size(screenWidth, screenHeight);
	        this.Location = new System.Drawing.Point(screenLeft, screenTop);
	        
	        // Main functionality
	        this.Click += onClick;
		}
		
		protected void onClick(object sender, EventArgs args) {
			MouseEventArgs margs = (MouseEventArgs) args;
			
			if (margs.Button == MouseButtons.Right)
			{
				this.Close();
			}
			else
			{
				this.SendToBack();
				Program.Wkill(MousePosition);
				this.Close();
			}
		}
		
		/// <summary>
		/// Makes sure that the user can use Escape at any time.
		/// </summary>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
	        if (keyData == Keys.Escape) {
	            this.Close();
	            return true;
	        }
	        return base.ProcessCmdKey(ref msg, keyData);
	    }
	}
}
