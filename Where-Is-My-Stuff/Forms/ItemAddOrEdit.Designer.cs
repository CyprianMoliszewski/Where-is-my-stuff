namespace Where_Is_My_Stuff.Forms
{
    partial class ItemAddOrEdit
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
            this.lbl_item_name = new System.Windows.Forms.Label();
            this.lbl_item_category = new System.Windows.Forms.Label();
            this.lbl_item_owner = new System.Windows.Forms.Label();
            this.tb_item_name = new System.Windows.Forms.TextBox();
            this.cb_item_category = new System.Windows.Forms.ComboBox();
            this.cb_item_owner = new System.Windows.Forms.ComboBox();
            this.lbl_item_location = new System.Windows.Forms.Label();
            this.lbl_item_description = new System.Windows.Forms.Label();
            this.tb_item_description = new System.Windows.Forms.TextBox();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_item_location = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_item_name
            // 
            this.lbl_item_name.AutoSize = true;
            this.lbl_item_name.Location = new System.Drawing.Point(9, 9);
            this.lbl_item_name.Name = "lbl_item_name";
            this.lbl_item_name.Size = new System.Drawing.Size(48, 16);
            this.lbl_item_name.TabIndex = 0;
            this.lbl_item_name.Text = "Nazwa";
            // 
            // lbl_item_category
            // 
            this.lbl_item_category.AutoSize = true;
            this.lbl_item_category.Location = new System.Drawing.Point(9, 53);
            this.lbl_item_category.Name = "lbl_item_category";
            this.lbl_item_category.Size = new System.Drawing.Size(65, 16);
            this.lbl_item_category.TabIndex = 1;
            this.lbl_item_category.Text = "Kategoria";
            // 
            // lbl_item_owner
            // 
            this.lbl_item_owner.AutoSize = true;
            this.lbl_item_owner.Location = new System.Drawing.Point(9, 99);
            this.lbl_item_owner.Name = "lbl_item_owner";
            this.lbl_item_owner.Size = new System.Drawing.Size(72, 16);
            this.lbl_item_owner.TabIndex = 2;
            this.lbl_item_owner.Text = "Właściciel";
            // 
            // tb_item_name
            // 
            this.tb_item_name.Location = new System.Drawing.Point(12, 28);
            this.tb_item_name.Name = "tb_item_name";
            this.tb_item_name.Size = new System.Drawing.Size(156, 22);
            this.tb_item_name.TabIndex = 3;
            // 
            // cb_item_category
            // 
            this.cb_item_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_item_category.FormattingEnabled = true;
            this.cb_item_category.Location = new System.Drawing.Point(12, 72);
            this.cb_item_category.Name = "cb_item_category";
            this.cb_item_category.Size = new System.Drawing.Size(156, 24);
            this.cb_item_category.TabIndex = 4;
            // 
            // cb_item_owner
            // 
            this.cb_item_owner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_item_owner.FormattingEnabled = true;
            this.cb_item_owner.Location = new System.Drawing.Point(12, 118);
            this.cb_item_owner.Name = "cb_item_owner";
            this.cb_item_owner.Size = new System.Drawing.Size(156, 24);
            this.cb_item_owner.TabIndex = 5;
            // 
            // lbl_item_location
            // 
            this.lbl_item_location.AutoSize = true;
            this.lbl_item_location.Location = new System.Drawing.Point(9, 302);
            this.lbl_item_location.Name = "lbl_item_location";
            this.lbl_item_location.Size = new System.Drawing.Size(75, 16);
            this.lbl_item_location.TabIndex = 6;
            this.lbl_item_location.Text = "Lokalizacja";
            // 
            // lbl_item_description
            // 
            this.lbl_item_description.AutoSize = true;
            this.lbl_item_description.Location = new System.Drawing.Point(9, 145);
            this.lbl_item_description.Name = "lbl_item_description";
            this.lbl_item_description.Size = new System.Drawing.Size(35, 16);
            this.lbl_item_description.TabIndex = 10;
            this.lbl_item_description.Text = "Opis";
            // 
            // tb_item_description
            // 
            this.tb_item_description.Location = new System.Drawing.Point(12, 164);
            this.tb_item_description.Multiline = true;
            this.tb_item_description.Name = "tb_item_description";
            this.tb_item_description.Size = new System.Drawing.Size(156, 135);
            this.tb_item_description.TabIndex = 11;
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(12, 421);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 12;
            this.btn_cancle.Text = "Anuluj";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(93, 421);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 13;
            this.btn_save.Text = "Zapisz";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_item_location
            // 
            this.tb_item_location.Enabled = false;
            this.tb_item_location.Location = new System.Drawing.Point(12, 321);
            this.tb_item_location.Multiline = true;
            this.tb_item_location.Name = "tb_item_location";
            this.tb_item_location.Size = new System.Drawing.Size(156, 94);
            this.tb_item_location.TabIndex = 14;
            // 
            // ItemAddOrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 452);
            this.Controls.Add(this.tb_item_location);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.tb_item_description);
            this.Controls.Add(this.lbl_item_description);
            this.Controls.Add(this.lbl_item_location);
            this.Controls.Add(this.cb_item_owner);
            this.Controls.Add(this.cb_item_category);
            this.Controls.Add(this.tb_item_name);
            this.Controls.Add(this.lbl_item_owner);
            this.Controls.Add(this.lbl_item_category);
            this.Controls.Add(this.lbl_item_name);
            this.Name = "ItemAddOrEdit";
            this.Text = "ItemAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_item_name;
        private System.Windows.Forms.Label lbl_item_category;
        private System.Windows.Forms.Label lbl_item_owner;
        private System.Windows.Forms.TextBox tb_item_name;
        private System.Windows.Forms.ComboBox cb_item_category;
        private System.Windows.Forms.ComboBox cb_item_owner;
        private System.Windows.Forms.Label lbl_item_location;
        private System.Windows.Forms.Label lbl_item_description;
        private System.Windows.Forms.TextBox tb_item_description;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tb_item_location;
    }
}