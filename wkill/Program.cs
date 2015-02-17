/*
 * Created by SharpDevelop.
 * Date: 17.02.2015
 * Time: 16:57
 */
using System;
using System.Windows.Forms;

using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;

namespace wkill
{
	/// <summary>
	/// Containment class for PInvokes
	/// </summary>
	static class Win32 {
	   [DllImport("User32.dll")]
	   public static extern IntPtr WindowFromPoint(Point p);
	   [DllImport("User32.dll")]
	   public static extern Int32 GetWindowThreadProcessId(IntPtr hwnd, out Int32 pid);
	}
	
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	static class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		public static void Wkill(Point p)
		{
			IntPtr hwnd;
			Int32 pid = 0;
			Process proc;
			
			hwnd = Win32.WindowFromPoint(p);
			if (hwnd == IntPtr.Zero)
			{
				MessageBox.Show(String.Format("Could not retrieve window (from %s,%s)",
					p.X, p.Y
				), "wkill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			Win32.GetWindowThreadProcessId(hwnd, out pid);
			if (pid == 0)
			{
				MessageBox.Show(String.Format("Could not retrieve process ID (from handle %s)",
					hwnd
				), "wkill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			try
			{
				proc = Process.GetProcessById(pid);
			}
			catch (ArgumentException e)
			{
				MessageBox.Show(String.Format("Could not retrieve process (from pid %s):\n\n%s",
					pid,
				    e.Message
				), "wkill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				proc.Kill();
			}
			catch (Win32Exception e)
			{
				MessageBox.Show(String.Format("Could not terminate process (%s, pid %s on %s):\n\n%s",
					proc.ProcessName, proc.Id, proc.MachineName,
				    e.Message
				), "wkill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
		}
		
	}
}
