namespace IFramework.Controls
{
    partial class DateTimeRangePickerJ
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblToDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFromJalali = new System.Windows.Forms.TextBox();
            this.txtToJalali = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToDate.Location = new System.Drawing.Point(359, 12);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(82, 25);
            this.lblToDate.TabIndex = 25;
            this.lblToDate.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "From Date";
            // 
            // txtFromJalali
            // 
            this.txtFromJalali.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFromJalali.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFromJalali.Location = new System.Drawing.Point(120, 46);
            this.txtFromJalali.Name = "txtFromJalali";
            this.txtFromJalali.ReadOnly = true;
            this.txtFromJalali.Size = new System.Drawing.Size(125, 23);
            this.txtFromJalali.TabIndex = 26;
            // 
            // txtToJalali
            // 
            this.txtToJalali.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtToJalali.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtToJalali.Location = new System.Drawing.Point(451, 48);
            this.txtToJalali.Name = "txtToJalali";
            this.txtToJalali.ReadOnly = true;
            this.txtToJalali.Size = new System.Drawing.Size(125, 23);
            this.txtToJalali.TabIndex = 26;
            // 
            // DateTimeRangePickerJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.txtFromJalali);
            this.Controls.Add(this.txtToJalali);
            this.Name = "DateTimeRangePickerJ";
            this.Size = new System.Drawing.Size(730, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtToJalali;
        public System.Windows.Forms.TextBox txtFromJalali;
    }
}
