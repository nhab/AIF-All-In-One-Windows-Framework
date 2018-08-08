    partial class frmMain
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
            this.btnHoverButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnColorPicker = new System.Windows.Forms.Button();
            this.btnClock = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnInputBox = new System.Windows.Forms.Button();
            this.btnIOLib = new System.Windows.Forms.Button();
            this.btnQueryAnalyser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHoverButton
            // 
            this.btnHoverButton.Location = new System.Drawing.Point(87, 64);
            this.btnHoverButton.Margin = new System.Windows.Forms.Padding(2);
            this.btnHoverButton.Name = "btnHoverButton";
            this.btnHoverButton.Size = new System.Drawing.Size(80, 32);
            this.btnHoverButton.TabIndex = 0;
            this.btnHoverButton.Text = "Hover Button";
            this.btnHoverButton.UseVisualStyleBackColor = true;
            this.btnHoverButton.Click += new System.EventHandler(this.btnHoverButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(662, 61);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 79);
            this.panel1.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(28, 64);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(54, 32);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnColorPicker
            // 
            this.btnColorPicker.Location = new System.Drawing.Point(169, 64);
            this.btnColorPicker.Margin = new System.Windows.Forms.Padding(2);
            this.btnColorPicker.Name = "btnColorPicker";
            this.btnColorPicker.Size = new System.Drawing.Size(69, 32);
            this.btnColorPicker.TabIndex = 3;
            this.btnColorPicker.Text = "ColorPicker";
            this.btnColorPicker.UseVisualStyleBackColor = true;
            this.btnColorPicker.Click += new System.EventHandler(this.btnColorPicker_Click);
            // 
            // btnClock
            // 
            this.btnClock.Location = new System.Drawing.Point(246, 64);
            this.btnClock.Margin = new System.Windows.Forms.Padding(2);
            this.btnClock.Name = "btnClock";
            this.btnClock.Size = new System.Drawing.Size(54, 32);
            this.btnClock.TabIndex = 3;
            this.btnClock.Text = "Clock";
            this.btnClock.UseVisualStyleBackColor = true;
            this.btnClock.Click += new System.EventHandler(this.btnClock_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 64);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Editable Grid";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(387, 64);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "Gridview";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnInputBox
            // 
            this.btnInputBox.Location = new System.Drawing.Point(444, 64);
            this.btnInputBox.Margin = new System.Windows.Forms.Padding(2);
            this.btnInputBox.Name = "btnInputBox";
            this.btnInputBox.Size = new System.Drawing.Size(59, 32);
            this.btnInputBox.TabIndex = 6;
            this.btnInputBox.Text = "InputBox";
            this.btnInputBox.UseVisualStyleBackColor = true;
            this.btnInputBox.Click += new System.EventHandler(this.btnInputBox_Click);
            // 
            // btnIOLib
            // 
            this.btnIOLib.Location = new System.Drawing.Point(508, 64);
            this.btnIOLib.Margin = new System.Windows.Forms.Padding(2);
            this.btnIOLib.Name = "btnIOLib";
            this.btnIOLib.Size = new System.Drawing.Size(56, 32);
            this.btnIOLib.TabIndex = 7;
            this.btnIOLib.Text = "IO Lib";
            this.btnIOLib.UseVisualStyleBackColor = true;
            this.btnIOLib.Click += new System.EventHandler(this.btnIOLib_Click);
            // 
            // btnQueryAnalyser
            // 
            this.btnQueryAnalyser.Location = new System.Drawing.Point(568, 65);
            this.btnQueryAnalyser.Margin = new System.Windows.Forms.Padding(2);
            this.btnQueryAnalyser.Name = "btnQueryAnalyser";
            this.btnQueryAnalyser.Size = new System.Drawing.Size(86, 32);
            this.btnQueryAnalyser.TabIndex = 8;
            this.btnQueryAnalyser.Text = "Query Analyser";
            this.btnQueryAnalyser.UseVisualStyleBackColor = true;
            this.btnQueryAnalyser.Click += new System.EventHandler(this.btnQueryAnalyser_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 354);
            this.Controls.Add(this.btnQueryAnalyser);
            this.Controls.Add(this.btnIOLib);
            this.Controls.Add(this.btnInputBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClock);
            this.Controls.Add(this.btnColorPicker);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnHoverButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "GridView";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHoverButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnColorPicker;
        private System.Windows.Forms.Button btnClock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnInputBox;
        private System.Windows.Forms.Button btnIOLib;
    private System.Windows.Forms.Button btnQueryAnalyser;
}
