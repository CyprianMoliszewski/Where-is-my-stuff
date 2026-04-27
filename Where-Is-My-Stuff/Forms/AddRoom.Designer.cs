namespace Where_Is_My_Stuff.Forms
{
    partial class AddRoom
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
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_room_name = new System.Windows.Forms.Label();
            this.tb_room_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(5, 46);
            this.btn_cancle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(56, 19);
            this.btn_cancle.TabIndex = 0;
            this.btn_cancle.Text = "Anuluj";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(66, 46);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(56, 19);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Zapisz";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_room_name
            // 
            this.lbl_room_name.AutoSize = true;
            this.lbl_room_name.Location = new System.Drawing.Point(3, 7);
            this.lbl_room_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_room_name.Name = "lbl_room_name";
            this.lbl_room_name.Size = new System.Drawing.Size(40, 13);
            this.lbl_room_name.TabIndex = 2;
            this.lbl_room_name.Text = "Nazwa";
            // 
            // tb_room_name
            // 
            this.tb_room_name.Location = new System.Drawing.Point(5, 23);
            this.tb_room_name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_room_name.Name = "tb_room_name";
            this.tb_room_name.Size = new System.Drawing.Size(118, 20);
            this.tb_room_name.TabIndex = 3;
            // 
            // AddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(125, 71);
            this.Controls.Add(this.tb_room_name);
            this.Controls.Add(this.lbl_room_name);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodanie pokoju";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_room_name;
        private System.Windows.Forms.TextBox tb_room_name;
    }
}