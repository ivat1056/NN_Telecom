﻿namespace NN_TelekomPP.Forms
{
    partial class InternetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InternetForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_back = new System.Windows.Forms.Button();
            this.InternetADD_button = new System.Windows.Forms.Button();
            this.UPD_button = new System.Windows.Forms.Button();
            this.StrokaSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Del_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(362, 302);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back.Location = new System.Drawing.Point(421, 341);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(121, 37);
            this.button_back.TabIndex = 1;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button1_Click);
            // 
            // InternetADD_button
            // 
            this.InternetADD_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InternetADD_button.Location = new System.Drawing.Point(403, 76);
            this.InternetADD_button.Name = "InternetADD_button";
            this.InternetADD_button.Size = new System.Drawing.Size(158, 37);
            this.InternetADD_button.TabIndex = 2;
            this.InternetADD_button.Text = "Добавить";
            this.InternetADD_button.UseVisualStyleBackColor = true;
            this.InternetADD_button.Click += new System.EventHandler(this.InternetADD_button_Click);
            // 
            // UPD_button
            // 
            this.UPD_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UPD_button.Location = new System.Drawing.Point(403, 147);
            this.UPD_button.Name = "UPD_button";
            this.UPD_button.Size = new System.Drawing.Size(158, 37);
            this.UPD_button.TabIndex = 3;
            this.UPD_button.Text = "Изменить";
            this.UPD_button.UseVisualStyleBackColor = true;
            this.UPD_button.Click += new System.EventHandler(this.UPD_button_Click);
            // 
            // StrokaSearch
            // 
            this.StrokaSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StrokaSearch.Location = new System.Drawing.Point(225, 25);
            this.StrokaSearch.MaxLength = 25;
            this.StrokaSearch.Name = "StrokaSearch";
            this.StrokaSearch.Size = new System.Drawing.Size(191, 26);
            this.StrokaSearch.TabIndex = 18;
            this.StrokaSearch.TextChanged += new System.EventHandler(this.StrokaSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Введите название";
            // 
            // Del_button
            // 
            this.Del_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Del_button.Location = new System.Drawing.Point(403, 208);
            this.Del_button.Name = "Del_button";
            this.Del_button.Size = new System.Drawing.Size(158, 37);
            this.Del_button.TabIndex = 20;
            this.Del_button.Text = "Удалить";
            this.Del_button.UseVisualStyleBackColor = true;
            this.Del_button.Click += new System.EventHandler(this.Del_button_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(403, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 37);
            this.button1.TabIndex = 21;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // InternetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(597, 390);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Del_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StrokaSearch);
            this.Controls.Add(this.UPD_button);
            this.Controls.Add(this.InternetADD_button);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InternetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интернет";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.global_FormClosed);
            this.Load += new System.EventHandler(this.InternetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button InternetADD_button;
        private System.Windows.Forms.Button UPD_button;
        private System.Windows.Forms.TextBox StrokaSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Del_button;
        private System.Windows.Forms.Button button1;
    }
}