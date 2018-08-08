using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;
using System.IO;	
using Microsoft.Win32 ;
using System.Drawing.Printing;

public class FrmConnect: Form
{
TextBox t1,t2,t3,t4;
Label l1,l2,l3,l4;
Button b1,b2;
private ErrorProvider ep ;
private System.ComponentModel.Container components;
OdbcConnection myConnection;
public FrmConnect()
{
InitializeComponent();
}
/*public static void Main()
{
connect c=new connect();
c.FormBorderStyle=FormBorderStyle.Fixed3D;
Application.Run(c);
}*/
public void InitializeComponent()
{
ep = new ErrorProvider() ; 
this.components = new System.ComponentModel.Container ();
this.l1=new Label();
l1.Location=new Point(25,20);
l1.Size=new Size(30,20);
l1.Text="DSN";
this.t1=new TextBox();
t1.Location=new Point(85,20);
t1.Size=new Size(120,20);

this.l2=new Label();
l2.Location=new Point(25,50);
l2.Size=new Size(60,20);
l2.Text="Username";
this.t2=new TextBox();
t2.Location=new Point(85,50);
t2.Size=new Size(120,20);

this.l3=new Label();
l3.Location=new Point(25,80);
l3.Size=new Size(60,20);
l3.Text="Password";
this.t3=new TextBox();
t3.Location=new Point(85,80);
t3.Size=new Size(120,20);
t3.PasswordChar = '*';

this.l4=new Label();
l4.Location=new Point(25,110);
l4.Size=new Size(60,20);
l4.Text="Service";
this.t4=new TextBox();
t4.Location=new Point(85,110);
t4.Size=new Size(120,20);

this.b1=new Button();
b1.Location=new Point(70,150);
b1.Size=new Size(60,30);
b1.Text="Connect";
b1.Click += new System.EventHandler(b1_Click);
b1.BackColor = System.Drawing.Color.Pink ;
b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

this.b2=new Button();
b2.Location=new Point(155,150);
b2.Size=new Size(60,30);
b2.Text="Close";
b2.Click += new System.EventHandler(b2_Click);
b2.BackColor = System.Drawing.Color.Pink;
b2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

this.Size=new Size(300,300);
this.MaximizeBox = false;
this.Controls.Add(t1);
this.Controls.Add(t2);
this.Controls.Add(t3);
this.Controls.Add(t4);
this.Controls.Add(l1);
this.Controls.Add(l2);
this.Controls.Add(l3);
this.Controls.Add(l4);
this.Controls.Add(b1);
this.Controls.Add(b2);
}
protected void b1_Click(object sender, EventArgs e)
{
   try
   	{
		string connection = "Provider=MSDAORA;FileDSN="+t1.Text+";UID="+t2.Text+";PWD="+t3.Text+";SID="+t4.Text+"";
		string	query = "select * from tab" ;
		myConnection = new OdbcConnection(connection) ;
		System.Console.Write("Connection established");
	    OdbcCommand myCommand = new OdbcCommand(query,myConnection);
		myCommand = new OdbcCommand(query, myConnection) ;
		myCommand.Connection.Open() ;
		OdbcDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection) ;
		while (myReader.Read())
			{
				string count = myReader.GetString(0) ;
				Console.WriteLine("{0}",count);
			}
		myReader.Close() ;
		myCommand.Connection.Close() ;
		this.Hide();
		
	}
   catch(Exception ee)
    {
	if(ee.Message.IndexOf("invalid username/password")!=-1)
		{
			MessageBox.Show("Invalid Username/Password");
		}
	if(ee.Message.IndexOf("Invalid file dsn")!=-1)
		{
		MessageBox.Show("Invalid File DSN");
		}
	}
}
protected void b2_Click(object sender, EventArgs e)
{
Application.Exit();
}
public OdbcConnection Connection()
{
	return myConnection;
}
}
