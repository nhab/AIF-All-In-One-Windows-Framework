namespace WinControl
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;

    public class HoverButton: Button
    {

		Color FChangedForeColor = Color.Red;
		Color FSaveForeColor;
		public Color ChangedForeColor
		{
			get { return FChangedForeColor; }
			set { FChangedForeColor = value; }
		}


		protected override void OnMouseEnter(System.EventArgs e) 
		{
		base.OnMouseEnter(e);
		FSaveForeColor = ForeColor;
		ForeColor = FChangedForeColor;
		}

		protected override void OnMouseLeave(System.EventArgs e) 
		{
		base.OnMouseLeave(e);
		ForeColor = FSaveForeColor;
		}

	}
}

