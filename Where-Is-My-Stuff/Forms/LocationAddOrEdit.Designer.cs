namespace Where_Is_My_Stuff.Forms
{
    partial class LocationAddOrEdit
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
            this.cb_location_category = new System.Windows.Forms.ComboBox();
            this.tb_location_name = new System.Windows.Forms.TextBox();
            this.lbl_location_name = new System.Windows.Forms.Label();
            this.lbl_location_type = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(9, 80);
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
            this.btn_save.Location = new System.Drawing.Point(70, 80);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(56, 19);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Zapisz";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cb_location_category
            // 
            this.cb_location_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_location_category.FormattingEnabled = true;
            this.cb_location_category.Location = new System.Drawing.Point(9, 56);
            this.cb_location_category.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_location_category.Name = "cb_location_category";
            this.cb_location_category.Size = new System.Drawing.Size(118, 21);
            this.cb_location_category.TabIndex = 2;
            // 
            // tb_location_name
            // 
            this.tb_location_name.Location = new System.Drawing.Point(9, 21);
            this.tb_location_name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_location_name.Name = "tb_location_name";
            this.tb_location_name.Size = new System.Drawing.Size(118, 20);
            this.tb_location_name.TabIndex = 3;
            // 
            // lbl_location_name
            // 
            this.lbl_location_name.AutoSize = true;
            this.lbl_location_name.Location = new System.Drawing.Point(7, 6);
            this.lbl_location_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_location_name.Name = "lbl_location_name";
            this.lbl_location_name.Size = new System.Drawing.Size(40, 13);
            this.lbl_location_name.TabIndex = 4;
            this.lbl_location_name.Text = "Nazwa";
            // 
            // lbl_location_type
            // 
            this.lbl_location_type.AutoSize = true;
            this.lbl_location_type.Location = new System.Drawing.Point(7, 41);
            this.lbl_location_type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_location_type.Name = "lbl_location_type";
            this.lbl_location_type.Size = new System.Drawing.Size(25, 13);
            this.lbl_location_type.TabIndex = 5;
            this.lbl_location_type.Text = "Typ";
            // 
            // LocationAddOrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(133, 110);
            this.Controls.Add(this.lbl_location_type);
            this.Controls.Add(this.lbl_location_name);
            this.Controls.Add(this.tb_location_name);
            this.Controls.Add(this.cb_location_category);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationAddOrEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodanie lokalizacji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cb_location_category;
        private System.Windows.Forms.TextBox tb_location_name;
        private System.Windows.Forms.Label lbl_location_name;
        private System.Windows.Forms.Label lbl_location_type;
    }
}