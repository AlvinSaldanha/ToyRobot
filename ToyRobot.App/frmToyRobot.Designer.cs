namespace ToyRobot.App
{
	partial class frmToyRobot
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.btnPlace = new System.Windows.Forms.Button();
			this.btnReport = new System.Windows.Forms.Button();
			this.btnRight = new System.Windows.Forms.Button();
			this.btnLeft = new System.Windows.Forms.Button();
			this.btnMove = new System.Windows.Forms.Button();
			this.txtX = new System.Windows.Forms.NumericUpDown();
			this.pbStart = new System.Windows.Forms.PictureBox();
			this.cmbDirection = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtY = new System.Windows.Forms.NumericUpDown();
			this.lblOutputLabel = new System.Windows.Forms.Label();
			this.lblOutputValue = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.txtX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtY)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 6;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.Location = new System.Drawing.Point(985, 36);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(653, 595);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(225, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Enter X";
			// 
			// btnPlace
			// 
			this.btnPlace.Location = new System.Drawing.Point(231, 271);
			this.btnPlace.Name = "btnPlace";
			this.btnPlace.Size = new System.Drawing.Size(120, 47);
			this.btnPlace.TabIndex = 5;
			this.btnPlace.Text = "Place";
			this.btnPlace.UseVisualStyleBackColor = true;
			this.btnPlace.Click += new System.EventHandler(this.btnPlace_Click);
			// 
			// btnReport
			// 
			this.btnReport.Location = new System.Drawing.Point(187, 708);
			this.btnReport.Name = "btnReport";
			this.btnReport.Size = new System.Drawing.Size(174, 79);
			this.btnReport.TabIndex = 6;
			this.btnReport.Text = "Report";
			this.btnReport.UseVisualStyleBackColor = true;
			this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
			// 
			// btnRight
			// 
			this.btnRight.Location = new System.Drawing.Point(641, 515);
			this.btnRight.Name = "btnRight";
			this.btnRight.Size = new System.Drawing.Size(174, 79);
			this.btnRight.TabIndex = 7;
			this.btnRight.Text = "Right";
			this.btnRight.UseVisualStyleBackColor = true;
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.Location = new System.Drawing.Point(187, 515);
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.Size = new System.Drawing.Size(174, 79);
			this.btnLeft.TabIndex = 8;
			this.btnLeft.Text = "Left";
			this.btnLeft.UseVisualStyleBackColor = true;
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// btnMove
			// 
			this.btnMove.Location = new System.Drawing.Point(414, 515);
			this.btnMove.Name = "btnMove";
			this.btnMove.Size = new System.Drawing.Size(174, 79);
			this.btnMove.TabIndex = 9;
			this.btnMove.Text = "Move";
			this.btnMove.UseVisualStyleBackColor = true;
			this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
			// 
			// txtX
			// 
			this.txtX.Location = new System.Drawing.Point(341, 81);
			this.txtX.Name = "txtX";
			this.txtX.Size = new System.Drawing.Size(151, 27);
			this.txtX.TabIndex = 10;
			// 
			// pbStart
			// 
			this.pbStart.Location = new System.Drawing.Point(1285, 674);
			this.pbStart.Name = "pbStart";
			this.pbStart.Size = new System.Drawing.Size(87, 81);
			this.pbStart.TabIndex = 12;
			this.pbStart.TabStop = false;
			// 
			// cmbDirection
			// 
			this.cmbDirection.FormattingEnabled = true;
			this.cmbDirection.Location = new System.Drawing.Point(341, 209);
			this.cmbDirection.Name = "cmbDirection";
			this.cmbDirection.Size = new System.Drawing.Size(151, 28);
			this.cmbDirection.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(226, 212);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 20);
			this.label3.TabIndex = 14;
			this.label3.Text = "Enter Direction";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(225, 147);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Enter Y";
			// 
			// txtY
			// 
			this.txtY.Location = new System.Drawing.Point(341, 145);
			this.txtY.Name = "txtY";
			this.txtY.Size = new System.Drawing.Size(150, 27);
			this.txtY.TabIndex = 11;
			// 
			// lblOutputLabel
			// 
			this.lblOutputLabel.AutoSize = true;
			this.lblOutputLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblOutputLabel.Location = new System.Drawing.Point(411, 735);
			this.lblOutputLabel.Name = "lblOutputLabel";
			this.lblOutputLabel.Size = new System.Drawing.Size(114, 37);
			this.lblOutputLabel.TabIndex = 15;
			this.lblOutputLabel.Text = "Output: ";
			this.lblOutputLabel.Visible = false;
			// 
			// lblOutputValue
			// 
			this.lblOutputValue.AutoSize = true;
			this.lblOutputValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblOutputValue.Location = new System.Drawing.Point(531, 735);
			this.lblOutputValue.Name = "lblOutputValue";
			this.lblOutputValue.Size = new System.Drawing.Size(122, 37);
			this.lblOutputValue.TabIndex = 16;
			this.lblOutputValue.Text = "Output: ";
			this.lblOutputValue.Visible = false;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btnPlace);
			this.panel1.Location = new System.Drawing.Point(199, 36);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(386, 357);
			this.panel1.TabIndex = 17;
			// 
			// frmToyRobot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1679, 872);
			this.Controls.Add(this.lblOutputValue);
			this.Controls.Add(this.lblOutputLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbDirection);
			this.Controls.Add(this.pbStart);
			this.Controls.Add(this.txtY);
			this.Controls.Add(this.txtX);
			this.Controls.Add(this.btnMove);
			this.Controls.Add(this.btnLeft);
			this.Controls.Add(this.btnRight);
			this.Controls.Add(this.btnReport);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panel1);
			this.Name = "frmToyRobot";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.txtX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtY)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnPlace;
		private System.Windows.Forms.Button btnReport;
		private System.Windows.Forms.Button btnRight;
		private System.Windows.Forms.Button btnLeft;
		private System.Windows.Forms.Button btnMove;
		private System.Windows.Forms.NumericUpDown txtX;
		private System.Windows.Forms.PictureBox pbStart;
		private System.Windows.Forms.ComboBox cmbDirection;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown txtY;
		private System.Windows.Forms.Label lblOutputLabel;
		private System.Windows.Forms.Label lblOutputValue;
		private System.Windows.Forms.Panel panel1;
	}
}
