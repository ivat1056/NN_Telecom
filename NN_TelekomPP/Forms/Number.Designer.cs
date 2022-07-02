namespace NN_TelekomPP.Forms
{
    partial class Number
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Number));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.StrokaSearch = new System.Windows.Forms.TextBox();
            this.InternetADD_button = new System.Windows.Forms.Button();
            this.UPD_button = new System.Windows.Forms.Button();
            this.Del_button = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(306, 334);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Введите название";
            // 
            // StrokaSearch
            // 
            this.StrokaSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StrokaSearch.Location = new System.Drawing.Point(249, 12);
            this.StrokaSearch.MaxLength = 25;
            this.StrokaSearch.Name = "StrokaSearch";
            this.StrokaSearch.Size = new System.Drawing.Size(191, 26);
            this.StrokaSearch.TabIndex = 21;
            this.StrokaSearch.TextChanged += new System.EventHandler(this.StrokaSearch_TextChanged);
            // 
            // InternetADD_button
            // 
            this.InternetADD_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InternetADD_button.Location = new System.Drawing.Point(344, 56);
            this.InternetADD_button.Name = "InternetADD_button";
            this.InternetADD_button.Size = new System.Drawing.Size(158, 37);
            this.InternetADD_button.TabIndex = 22;
            this.InternetADD_button.Text = "Добавить";
            this.InternetADD_button.UseVisualStyleBackColor = true;
            this.InternetADD_button.Click += new System.EventHandler(this.InternetADD_button_Click);
            // 
            // UPD_button
            // 
            this.UPD_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UPD_button.Location = new System.Drawing.Point(344, 123);
            this.UPD_button.Name = "UPD_button";
            this.UPD_button.Size = new System.Drawing.Size(158, 37);
            this.UPD_button.TabIndex = 23;
            this.UPD_button.Text = "Изменить";
            this.UPD_button.UseVisualStyleBackColor = true;
            this.UPD_button.Click += new System.EventHandler(this.UPD_button_Click);
            // 
            // Del_button
            // 
            this.Del_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Del_button.Location = new System.Drawing.Point(344, 185);
            this.Del_button.Name = "Del_button";
            this.Del_button.Size = new System.Drawing.Size(158, 37);
            this.Del_button.TabIndex = 24;
            this.Del_button.Text = "Удалить";
            this.Del_button.UseVisualStyleBackColor = true;
            this.Del_button.Click += new System.EventHandler(this.Del_button_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back.Location = new System.Drawing.Point(361, 353);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(121, 37);
            this.button_back.TabIndex = 25;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(344, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 37);
            this.button1.TabIndex = 36;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Number
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(540, 397);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.Del_button);
            this.Controls.Add(this.UPD_button);
            this.Controls.Add(this.InternetADD_button);
            this.Controls.Add(this.StrokaSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Number";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Телефоны";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.global_FormClosed);
            this.Load += new System.EventHandler(this.Number_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StrokaSearch;
        private System.Windows.Forms.Button InternetADD_button;
        private System.Windows.Forms.Button UPD_button;
        private System.Windows.Forms.Button Del_button;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button1;
    }
}