namespace ludogame_v4.TheHien
{
	partial class ForgotPassword
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPassword));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtEmailDK = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtKetQua = new System.Windows.Forms.TextBox();
			this.btnLayLaiMatKhau = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(139, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(205, 171);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// txtEmailDK
			// 
			this.txtEmailDK.Location = new System.Drawing.Point(190, 224);
			this.txtEmailDK.Name = "txtEmailDK";
			this.txtEmailDK.Size = new System.Drawing.Size(238, 22);
			this.txtEmailDK.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label1.Location = new System.Drawing.Point(26, 224);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "Email Đăng Ký:";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label2.Location = new System.Drawing.Point(40, 265);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 22);
			this.label2.TabIndex = 2;
			this.label2.Text = "Kết Quả:";
			// 
			// txtKetQua
			// 
			this.txtKetQua.Location = new System.Drawing.Point(190, 265);
			this.txtKetQua.Name = "txtKetQua";
			this.txtKetQua.Size = new System.Drawing.Size(238, 22);
			this.txtKetQua.TabIndex = 3;
			// 
			// btnLayLaiMatKhau
			// 
			this.btnLayLaiMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.btnLayLaiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLayLaiMatKhau.ForeColor = System.Drawing.Color.White;
			this.btnLayLaiMatKhau.Location = new System.Drawing.Point(150, 325);
			this.btnLayLaiMatKhau.Name = "btnLayLaiMatKhau";
			this.btnLayLaiMatKhau.Size = new System.Drawing.Size(184, 35);
			this.btnLayLaiMatKhau.TabIndex = 6;
			this.btnLayLaiMatKhau.Text = "Lấy Lại Mật Khẩu";
			this.btnLayLaiMatKhau.UseVisualStyleBackColor = false;
			this.btnLayLaiMatKhau.Click += new System.EventHandler(this.btnLayLaiMatKhau_Click);
			// 
			// ForgotPassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(472, 413);
			this.Controls.Add(this.btnLayLaiMatKhau);
			this.Controls.Add(this.txtKetQua);
			this.Controls.Add(this.txtEmailDK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "ForgotPassword";
			this.Text = "Quên Mật Khẩu";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ForgotPassword_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox txtEmailDK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtKetQua;
		private System.Windows.Forms.Button btnLayLaiMatKhau;
	}
}