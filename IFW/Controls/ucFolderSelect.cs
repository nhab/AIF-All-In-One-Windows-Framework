/*
 * User: a    Created by SharpDevelop.
 * Date: 5/22/2004   Time: 9:58 PM
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace myWinShell
{

	public class FolderSelect  : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TreeView treeView1;
	#region controls
		private static string driveLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private DirectoryInfo folder;
#endregion
	#region	FolderSelect
		public FolderSelect()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			// initialize the treeView
			fillTree();
		}
#endregion	
	#region fillTree
		/// <summary> method fillTree
		/// <para>This method is used to initially fill the treeView control with a list
		/// of available drives from which you can search for the desired folder.</para>
		/// </summary>

		private void fillTree()
		{
			DirectoryInfo directory;
			string sCurPath = "";

			// clear out the old values
			treeView1.Nodes.Clear();
            string sErrs = "";
			// loop through the drive letters and find the available drives.
			foreach( char c in driveLetters )
			{
				sCurPath = c + ":\\";
				try 
				{
					// get the directory informaiton for this path.
					directory = new DirectoryInfo(sCurPath);

					// if the retrieved directory information points to a valid
					// directory or drive in this case, add it to the root of the 
					// treeView.
					if ( directory.Exists == true )
					{
						TreeNode newNode = new TreeNode(directory.FullName);
						treeView1.Nodes.Add(newNode);   // add the new node to the root level.
                        sErrs=getSubDirs(newNode);			// scan for any sub folders on this drive.
                        if ((sErrs !=null ) && (sErrs != ""))
                            MessageBox.Show(sErrs);
					}
				}
				catch( Exception doh)
				{
					MessageBox.Show (doh.Message);
				}
			}
		}
#endregion
	#region getSubDirs
		/// <summary> method getSubDirs
		/// <para>this function will scan the specified parent for any subfolders 
		/// if they exist.  To minimize the memory usage, we only scan a single 
		/// folder level down from the existing, and only if it is needed.</para>
		/// <param name="parent">the parent folder in which to search for sub-folders.</param>
		/// </summary>

		private string getSubDirs( TreeNode parent )
		{
            string sErrors="";
			DirectoryInfo directory;
			try
			{
				// if we have not scanned this folder before
				if ( parent.Nodes.Count == 0 )
				{
					directory = new DirectoryInfo(parent.FullPath);
					foreach( DirectoryInfo dir in directory.GetDirectories())
					{
						TreeNode newNode = new TreeNode(dir.Name);
						parent.Nodes.Add(newNode);
					}
				}

				// now that we have the children of the parent, see if they
				// have any child members that need to be scanned.  Scanning 
				// the first level of sub folders insures that you properly 
				// see the '+' or '-' expanding controls on each node that represents
				// a sub folder with it's own children.
				foreach(TreeNode node in parent.Nodes)
				{
					// if we have not scanned this node before.
					if (node.Nodes.Count == 0)
					{
						// get the folder information for the specified path.
						directory = new DirectoryInfo(node.FullPath);

						// check this folder for any possible sub-folders
						foreach( DirectoryInfo dir in directory.GetDirectories())
						{
							// make a new TreeNode and add it to the treeView.
							TreeNode newNode = new TreeNode(dir.Name);
							node.Nodes.Add(newNode);
						}
					}
				}
			}
			catch( Exception ex )
			{
                sErrors = ex.Message + "\r\n";

			}
            return sErrors;

        }
#endregion
	#region fixPath
		/// <summary> method fixPath
		/// <para>For some reason, the treeView will only work with paths constructed like the following example.
		/// "c:\\Program Files\Microsoft\...".  What this method does is strip the leading "\\" next to the drive
		/// letter.</para>
		/// <param name="node">the folder that needs it's path fixed for display.</param>
		/// <returns>The correctly formatted full path to the selected folder.</returns>
		/// </summary>

		private string fixPath( TreeNode node )
		{
			string sRet = "";
			try
			{
				sRet = node.FullPath;
				int index = sRet.IndexOf("\\\\");
				if (index > 1 )
				{
					sRet = node.FullPath.Remove(index, 1);
				}
			}
			catch( Exception doh )
			{
				MessageBox.Show(doh.Message);
			}
			return sRet;
		}
	#endregion
	#region Dispose
	/// <summary>
		/// Clean up any resources being used.
		/// </summary>
	
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
#endregion
	#region treeView1_BeforeSelect
		/// <summary> method treeView1_BeforeSelect
		/// <para>Before we select a tree node we want to make sure that we scan the soon to be selected
		/// tree node for any sub-folders.  this insures proper tree construction on the fly.</para>
		/// <param name="sender">The object that invoked this event</param>
		/// <param name="e">The TreeViewCancelEventArgs event arguments.</param>
		/// <see cref="System.Windows.Forms.TreeViewCancelEventArgs"/>
		/// <see cref="System.Windows.Forms.TreeView"/>
		/// </summary>
	
		private void treeView1_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			getSubDirs(e.Node);					// get the sub-folders for the selected node.
			textBox1.Text = fixPath(e.Node);	// update the user selection text box.
			folder = new DirectoryInfo(e.Node.FullPath);	// get it's Directory info.
		}
	#endregion
	#region treeView1_BeforeExpand
			/// <summary> method treeView1_BeforeExpand
		/// <para>Before we expand a tree node we want to make sure that we scan the soon to be expanded
		/// tree node for any sub-folders.  this insures proper tree construction on the fly.</para>
		/// <param name="sender">The object that invoked this event</param>
		/// <param name="e">The TreeViewCancelEventArgs event arguments.</param>
		/// <see cref="System.Windows.Forms.TreeViewCancelEventArgs"/>
		/// <see cref="System.Windows.Forms.TreeView"/>
		/// </summary>
		private void treeView1_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			getSubDirs(e.Node);					// get the sub-folders for the selected node.
			textBox1.Text = fixPath(e.Node);	// update the user selection text box.
			folder = new DirectoryInfo(e.Node.FullPath);	// get it's Directory info.
		}
	#endregion

	#region name
		/// <summary> method name
		/// <para>A method to retrieve the short name for the selected folder.</para>
		/// <returns>The folder name for the selected folder.</returns>
		/// </summary>
		
		public string name
		{
			get { return ((folder != null && folder.Exists))? folder.Name : null; }
		}
		#endregion
	#region fullPath
		/// <summary> method fullPath
		/// <para>Retrieve the full path for the selected folder.</para>
		/// 
		/// <returns>The correctly formatted full path to the selected folder.</returns>
		/// <seealso cref="FolderSelect.fixPath"/>
		/// </summary>
	
		public string fullPath
		{
			get { return ((folder != null && folder.Exists && treeView1.SelectedNode != null))? fixPath(treeView1.SelectedNode) : null; }
		}
		#endregion	
	#region DirectoryInfo
		/// <summary> method info
		/// <para>Retrieve the full DirectoryInfo object associated with the selected folder.  Note
		/// that this will not have the corrected full path string.</para>
		/// <returns>The full DirectoryInfo object associated with the selected folder.</returns>
		/// <see cref="System.IO.DirectoryInfo"/>
		/// </summary>
		
		public DirectoryInfo info
		{
			get { return ((folder != null && folder.Exists))? folder : null; }
		}
	#endregion
	#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
						new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
									new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
												new System.Windows.Forms.TreeNode("Node2")})})});
			this.treeView1.Size = new System.Drawing.Size(280, 257);
			this.treeView1.TabIndex = 0;
			this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.textBox1.Location = new System.Drawing.Point(0, 237);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(280, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.textBox1);
			this.panel3.Controls.Add(this.treeView1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(6, 6);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(280, 257);
			this.panel3.TabIndex = 2;
			// 
			// FolderSelect
			// 
			this.Controls.Add(this.panel3);
			this.DockPadding.All = 6;
			this.Name = "FolderSelect";
			this.Size = new System.Drawing.Size(292, 269);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion
		
		
	}
}
