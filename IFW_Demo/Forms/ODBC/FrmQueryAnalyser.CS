using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;
using System.IO;	
using System.Drawing.Printing;

public class queryanalyser: Form
{
int lowerlimit=1;
int upperlimit=5;
int increment=5;
int dispint;
Panel p1,p2;
ListView lv;
RichTextBox t1;
ToolBar tbar;
ToolBarButton b1,b2,b3,b4,b5;
StatusBar statusBar;
private System.ComponentModel.Container components;
OdbcConnection connection;
string fileName="";
string flag="";
PrintDialog printDialog1;
PageSetupDialog pageSetupDialog1;
MenuItem mistatus;

public queryanalyser()
{
InitializeComponent();
}

public void InitializeComponent()
{
//initialising components..
this.components = new System.ComponentModel.Container ();

p1=new Panel();
p1.Location=new Point(0,0);
p1.Size=new Size(800,200);

p2=new Panel();
p2.Location=new Point(0,200);
p2.Size=new Size(800,320);

this.t1=new RichTextBox();
t1.Location=new Point(0,40);
t1.Size=new Size(700,160);
t1.Multiline=true;
t1.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
t1.ScrollBars= RichTextBoxScrollBars.ForcedHorizontal;
t1.WordWrap = true;

this.b1 = new System.Windows.Forms.ToolBarButton ();
b1.Text = "Connect";
this.b2 = new System.Windows.Forms.ToolBarButton ();
b2.Text = "Disconnect";
b2.Enabled=false;
this.b3 = new System.Windows.Forms.ToolBarButton ();
b3.Text = "User Tables";
b3.Enabled=false;
this.b4 = new System.Windows.Forms.ToolBarButton ();
b4.Text = "Execute";
b4.Enabled=false;
this.b5 = new System.Windows.Forms.ToolBarButton ();
b5.Text = "Next Row Set";
b5.Enabled=false;

this.tbar = new System.Windows.Forms.ToolBar ();
tbar.ButtonClick += new ToolBarButtonClickEventHandler(b1_Click);
tbar.Location=new Point(0,0);
tbar.ButtonSize = new System.Drawing.Size (130,35);
tbar.Size = new System.Drawing.Size (650, 40);
tbar.TabIndex = 2;
tbar.DropDownArrows = true;
this.tbar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {this.b1, this.b2, this.b3, this.b4, this.b5});		

lv = new ListView() ;
lv.View = View.Details ;
lv.GridLines = false ;
lv.FullRowSelect = true ;
lv.MultiSelect = false ;
lv.Width = 800 ;
lv.Height=320;

MainMenu mainMenu = new MainMenu();
this.Menu = mainMenu;
ContextMenu label1ContextMenu = new ContextMenu();
Label label1 = new Label();
label1.ContextMenu = label1ContextMenu; 

MenuItem miFile = mainMenu.MenuItems.Add("&File");
MenuItem mnew=new MenuItem("New", new EventHandler(this.FileNew_Clicked), Shortcut.CtrlN);
miFile.MenuItems.Add(mnew);
mnew.Select+=new EventHandler(mnew_Click);

miFile.MenuItems.Add("-"); // Gives us a seperator
MenuItem mopen=new MenuItem("Open", new EventHandler(this.FileOpen_Clicked), Shortcut.CtrlO);
miFile.MenuItems.Add(mopen);
mopen.Select+=new EventHandler(mopen_Click);

miFile.MenuItems.Add("-"); 
MenuItem msave=new MenuItem("Save", new EventHandler(this.FileSave_Clicked),Shortcut.CtrlS);
miFile.MenuItems.Add(msave);
msave.Select+=new EventHandler(msave_Click);

miFile.MenuItems.Add("-"); 
MenuItem msaveas=new MenuItem("SaveAs", new EventHandler(this.FileSaveAs_Clicked), Shortcut.CtrlA);
miFile.MenuItems.Add(msaveas);
msaveas.Select+=new EventHandler(msaveas_Click);

miFile.MenuItems.Add("-"); 
MenuItem mpagesetup=new MenuItem("PageSetUp", new EventHandler(this.FilePageSetUp_Clicked));
miFile.MenuItems.Add(mpagesetup);
mpagesetup.Select+=new EventHandler(mpagesetup_Click);

miFile.MenuItems.Add("-"); // Gives us a seperator
MenuItem mprint=new MenuItem("Print", new EventHandler(this.FilePrint_Clicked),Shortcut.CtrlP);
miFile.MenuItems.Add(mprint);
mprint.Select+=new EventHandler(mprint_Click);

miFile.MenuItems.Add("-");
MenuItem mexit=new MenuItem("Exit", new EventHandler(this.FileExit_Clicked));
miFile.MenuItems.Add(mexit);
mexit.Select+=new EventHandler(mexit_Click);
	
miFile = mainMenu.MenuItems.Add("&Edit");
MenuItem mcut=new MenuItem("Cut", new EventHandler(this.FileCut_Clicked), Shortcut.CtrlX);
miFile.MenuItems.Add(mcut);
mcut.Select+=new EventHandler(mcut_Click);

miFile.MenuItems.Add("-"); 
MenuItem mcopy=new MenuItem("Copy", new EventHandler(this.FileCopy_Clicked), Shortcut.CtrlC);
miFile.MenuItems.Add(mcopy);
mcopy.Select+=new EventHandler(mcopy_Click);

miFile.MenuItems.Add("-"); 
MenuItem mpaste=new MenuItem("Paste", new EventHandler(this.FilePaste_Clicked), Shortcut.CtrlV);
miFile.MenuItems.Add(mpaste);
mpaste.Select+=new EventHandler(mpaste_Click);

miFile = mainMenu.MenuItems.Add("&View");
mistatus=new MenuItem("Status Bar", new EventHandler(this.StatusBar_Clicked));
mistatus.Checked=true;
miFile.MenuItems.Add(mistatus);

statusBar=new StatusBar();
statusBar.Size = new System.Drawing.Size(800,30);
statusBar.Location = new System.Drawing.Point(0, 500);
statusBar.BackColor = System.Drawing.Color.Black;
statusBar.Text = "Ready";

p1.Controls.Add(tbar);
p1.Controls.Add(t1);
p2.Controls.Add(lv);
this.Controls.Add(p1);
this.Controls.Add(p2);
this.Controls.Add(statusBar);
this.Size=new Size(800,600);
}

protected void b1_Click(object sender,
ToolBarButtonClickEventArgs e)
{
if(e.Button==b1)
{   
	//Calling the Connection method of the connect.cs file for establishing connection to the //database..		    
	FrmConnect c=new FrmConnect();
	c.ShowDialog();
	connection=c.Connection();
	statusBar.Text="Connection established";
	b1.Enabled=false;
	b2.Enabled=true;
	b3.Enabled=true;
	b4.Enabled=true;
	b5.Enabled=false;
}
if(e.Button==b2)
{
	//Closing the connection...
	connection.Close();
	b1.Enabled=true;
	b2.Enabled=false;
	b3.Enabled=false;
	b4.Enabled=false;
	b5.Enabled=false;
	t1.Text="";
	lv.Clear();
	lowerlimit=1;
	upperlimit=5;
	dispint=0;
}
if(e.Button==b3)
{	
	//Setting the lower limit and upperlimit for no of records to be displayed per page...
	//Retrieving all the tables present in the database....
	lowerlimit=1;
	upperlimit=5;
	lv.Clear();
	flag="usertables";
  	try
  		{
		string query="select * from (select a.* ,rownum rnum from (select * from tab) a where rownum<="+upperlimit+" ) where rnum>="+lowerlimit;
		OdbcCommand myCommand= new OdbcCommand(query, connection) ;
		myCommand.Connection.Open() ;
		OdbcDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection) ;
		int count=myReader.FieldCount-1;
		lv.Columns.Add("Row No.", 100, HorizontalAlignment.Center) ;
		for(int i=0;i<count;i++)
			{
				lv.Columns.Add(myReader.GetName(i), 100, HorizontalAlignment.Center) ;
			}
			dispint=0;
		while(myReader.Read())
			{
			if (!myReader.IsDBNull(0))
			lv.Items.Add((dispint+1).ToString()) ;
						
			for (int i = 0; i < count; i++)
				{
					if (!myReader.IsDBNull(i))
					lv.Items[dispint].SubItems.Add(myReader.GetValue(i).ToString()) ;
				}
			dispint++ ;
			}
		myReader.Close();
		b5.Enabled=true;
		}
	catch(Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
}
if(e.Button==b4)
{  
	lowerlimit=1;
	upperlimit=5;
	flag="execute";
	try
		{
		string a=t1.Text;
		//For executing only the select query...
		if(a.IndexOf("select")!=-1)
		{
		lv.Clear();
		string query="select * from (select a.* ,rownum rnum from (" + t1.Text + ") a where rownum<="+upperlimit+" ) where rnum>="+lowerlimit;
		OdbcCommand myCommand= new OdbcCommand(query, connection) ;
		myCommand.Connection.Open() ;
		OdbcDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection) ;
		int count=myReader.FieldCount - 1;
		lv.Columns.Add("Row No.", 100, HorizontalAlignment.Center) ;
		for(int i=0;i<count;i++)
			{
				lv.Columns.Add(myReader.GetName(i), 100, HorizontalAlignment.Center) ;
			}
			dispint=0;
		while(myReader.Read())
			{
				if (!myReader.IsDBNull(0))
				lv.Items.Add((dispint+1).ToString()) ;
				for (int i = 0; i < count; i++)
					{
						if (!myReader.IsDBNull(i))
						lv.Items[dispint].SubItems.Add(myReader.GetValue(i).ToString()) ;
					}
			dispint++ ;
			}
		myReader.Close();
		b5.Enabled=true;
		}
		//For executing any query like insert,create etc...
		else
		{
		string nonquery= t1.Text ;
		OdbcCommand mynonqueryCommand= new OdbcCommand(nonquery, connection) ;
		mynonqueryCommand.Connection.Open() ;
		mynonqueryCommand.ExecuteNonQuery() ;
		mynonqueryCommand.Connection.Close();
		}
		}
	catch(Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
}

if(e.Button==b5)
{  
	lv.Clear();
	try
		{
		lowerlimit=upperlimit+1;
		upperlimit=upperlimit+increment;
		//For displaying the records of the select query five records per page...
		//When the last record is displayed the NextRowSet button is disabled...
		if(flag=="execute")
		{
		string abc=t1.Text;
		string xyz=abc.Substring(abc.IndexOf("from"));
		string querycount="select count(*) " + xyz;
		OdbcCommand countcommand1= new OdbcCommand(querycount, connection) ;
		countcommand1.Connection.Open() ;
		OdbcDataReader countreader1 = countcommand1.ExecuteReader(CommandBehavior.CloseConnection) ;
		countreader1.Read() ;
		int counttext = countreader1.GetInt32(0) ;
		countreader1.Close() ;
		countcommand1.Connection.Close() ;
		if(counttext<=upperlimit)
		{
		upperlimit=counttext;
		b5.Enabled=false;
		}
		
		string query="select * from (select a.* ,rownum rnum from (" + t1.Text + ") a where rownum<="+upperlimit+") where rnum>="+lowerlimit+"";		
		OdbcCommand myCommand= new OdbcCommand(query, connection) ;
		myCommand.Connection.Open() ;
		OdbcDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection) ;
		int count=myReader.FieldCount - 1 ;
		lv.Columns.Add("Row No.", 100, HorizontalAlignment.Center) ;
		for(int i=0;i<count;i++)
			{
				lv.Columns.Add(myReader.GetName(i), 100, HorizontalAlignment.Center) ;
			}
		dispint=0;
		int rowid = lowerlimit ;
		while(myReader.Read())
			{
				if (!myReader.IsDBNull(0))
				lv.Items.Add((rowid++).ToString()) ;

				for (int i = 0; i < count; i++)
					{
						if (!myReader.IsDBNull(i))
						lv.Items[dispint].SubItems.Add(myReader.GetValue(i).ToString()) ;
					}
			dispint++ ;
			}
		myReader.Close();
		}
		//For displaying all the  tables present in the database five per page....
		//When the last table is displayed the NextRowSet button is disabled...
		if(flag=="usertables")
		{
		string query1count="select count(*) from tab";
		OdbcCommand countcommand= new OdbcCommand(query1count, connection) ;
		countcommand.Connection.Open() ;
		OdbcDataReader countreader = countcommand.ExecuteReader(CommandBehavior.CloseConnection) ;
		countreader.Read() ;
		int counttab = countreader.GetInt32(0) ;
		countreader.Close() ;
		countcommand.Connection.Close() ;
		if(counttab<=upperlimit)
		{
		upperlimit=counttab;
		b5.Enabled=false;
		}
			
		string query1="select * from (select a.* ,rownum rnum from (select * from tab) a where rownum<="+upperlimit+") where rnum>="+lowerlimit+"";		
		OdbcCommand myCommand1= new OdbcCommand(query1, connection) ;
		myCommand1.Connection.Open() ;
		OdbcDataReader myReader1 = myCommand1.ExecuteReader(CommandBehavior.CloseConnection) ;
		int count1=myReader1.FieldCount - 1 ;
		lv.Columns.Add("Row No.", 100, HorizontalAlignment.Center) ;
		for(int i=0;i<count1;i++)
			{
				lv.Columns.Add(myReader1.GetName(i), 100, HorizontalAlignment.Center) ;
			}
		dispint=0;
		int rowid1 = lowerlimit ;
		while(myReader1.Read())
			{
				if (!myReader1.IsDBNull(0))
				lv.Items.Add((rowid1++).ToString()) ;

				for (int i = 0; i < count1; i++)
					{
						if (!myReader1.IsDBNull(i))
						lv.Items[dispint].SubItems.Add(myReader1.GetValue(i).ToString()) ;
					}
			dispint++ ;
			}
		myReader1.Close();
		}
		}
	catch(Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
}
}
//Creating a new file...
private void FileNew_Clicked(object sender, System.EventArgs e)
{
t1.Text=null;
}
//Text on the statusbar changes when the mouse comes over the menuitem...
private void mnew_Click(object sender, System.EventArgs e)
{
statusBar.Text="Create a new file";
}
//Opening an existing file...
private void FileOpen_Clicked(object sender, System.EventArgs e)
{
OpenFileDialog  openFileDialog = new OpenFileDialog();
//openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*" ;
openFileDialog.Filter = "Sql files (*.sql)|*.sql|All files (*.*)|*.*" ;
if(openFileDialog.ShowDialog() == DialogResult.OK)
{
 try
	 {
        t1.LoadFile(openFileDialog.FileName,RichTextBoxStreamType.PlainText);
        fileName=openFileDialog.FileName;
     }
 catch 
	 {
	    MessageBox.Show ("Could not open the file");
     }
}
}
private void mopen_Click(object sender, System.EventArgs e)
{
statusBar.Text="Open an existing file";
}
//Saving the file...
private void FileSave_Clicked(object sender, System.EventArgs e)
{
SaveFileDialog fdlg = new SaveFileDialog();
if (fileName=="")
        {
             FileSaveAs_Clicked(sender, e);
        }
        else
        {
            try
            {
                t1.SaveFile(fileName,RichTextBoxStreamType.PlainText);
            }
            catch 
            {
                MessageBox.Show ("Could not save the file");
            }
        }
}
private void msave_Click(object sender, System.EventArgs e)
{
statusBar.Text="Save the current document to a file";
}
//Saving the file...
private void FileSaveAs_Clicked(object sender, System.EventArgs e)
{
SaveFileDialog saveFileDialog = new SaveFileDialog();
saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*" ;
if(saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
				{
                    t1.SaveFile(saveFileDialog.FileName,RichTextBoxStreamType.PlainText);
                    fileName=saveFileDialog.FileName;
                }
            catch
				{
                    MessageBox.Show ("Could not save the file");
           		}
        }
}
private void msaveas_Click(object sender, System.EventArgs e)
{
statusBar.Text="Save the current document to a new file";
}
//Quiting the application...
private void FileExit_Clicked(object sender, System.EventArgs e)
{
this.Close(); 
}
private void mexit_Click(object sender, System.EventArgs e)
{
statusBar.Text="Quit the application";
}
private void FileCut_Clicked(object sender, System.EventArgs e)
{
t1.Cut();
}
private void mcut_Click(object sender, System.EventArgs e)
{
statusBar.Text="Cut the selection and puts it to the clipboard";
}
private void FileCopy_Clicked(object sender, System.EventArgs e)
{
t1.Copy();
}
private void mcopy_Click(object sender, System.EventArgs e)
{
statusBar.Text="Copy the selection to the clipboard";
}
private void FilePaste_Clicked(object sender, System.EventArgs e)
{
 t1.Paste();
}
private void mpaste_Click(object sender, System.EventArgs e)
{
statusBar.Text="Insert clipboard contents";
}
//Printing a file..
protected void FilePrint_Clicked(object sender, System.EventArgs e)
{	
	printDialog1=new PrintDialog();
	printDialog1.AllowPrintToFile =true;
	PrintDocument docPrn = new PrintDocument();
	docPrn.DocumentName=t1.Text;
	printDialog1.Document=docPrn;			
	if(printDialog1.ShowDialog()==DialogResult.OK)
	{
		try
		{
			docPrn.Print();
		}
		catch
		{
			MessageBox.Show ("Error While Printing", "Print Error");
		}
	}
}
private void mprint_Click(object sender, System.EventArgs e)
{
statusBar.Text="Print the current document";
}
//Printer options...
protected void FilePageSetUp_Clicked(object sender, System.EventArgs e)
{
	PrintDocument docPrn = new PrintDocument();
	docPrn.DocumentName=t1.Text;
	pageSetupDialog1=new PageSetupDialog();
	pageSetupDialog1.Document=docPrn;
	pageSetupDialog1.ShowDialog();
	
}
private void mpagesetup_Click(object sender, System.EventArgs e)
{
statusBar.Text="Change the printer options";
}
//Making the statusbar visible and invisible...
protected void StatusBar_Clicked(object sender, System.EventArgs e)
{
statusBar.Visible = !statusBar.Visible ;
mistatus.Checked=!mistatus.Checked;
}
}