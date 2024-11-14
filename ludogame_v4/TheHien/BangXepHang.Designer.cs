namespace ludogame_v4.TheHien
{
    partial class BangXepHang
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
            this.lvRank = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvRank
            // 
            this.lvRank.BackgroundImage = global::ludogame_v4.Properties.Resources.BangXepHang;
            this.lvRank.HideSelection = false;
            this.lvRank.Location = new System.Drawing.Point(12, 12);
            this.lvRank.Name = "lvRank";
            this.lvRank.Size = new System.Drawing.Size(776, 426);
            this.lvRank.TabIndex = 1;
            this.lvRank.UseCompatibleStateImageBehavior = false;
            this.lvRank.View = System.Windows.Forms.View.Details;
            // 
            // BangXepHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvRank);
            this.Name = "BangXepHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng Xếp Hạng";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvRank;
    }
}