
namespace gostinicha
{
    partial class Form3
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
            this.label10 = new System.Windows.Forms.Label();
            this.num_pers = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.room_numb = new System.Windows.Forms.ComboBox();
            this.sale = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.night = new System.Windows.Forms.Label();
            this.full_cost = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.room_price = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_fio = new System.Windows.Forms.TextBox();
            this.cm_room_type = new System.Windows.Forms.ComboBox();
            this.tb_des = new System.Windows.Forms.TextBox();
            this.date_dep = new System.Windows.Forms.DateTimePicker();
            this.date_arr = new System.Windows.Forms.DateTimePicker();
            this.tb_perm = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_pers)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(527, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 20);
            this.label10.TabIndex = 47;
            this.label10.Text = "Кол-во проживающих";
            // 
            // num_pers
            // 
            this.num_pers.Location = new System.Drawing.Point(636, 164);
            this.num_pers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_pers.Name = "num_pers";
            this.num_pers.Size = new System.Drawing.Size(56, 27);
            this.num_pers.TabIndex = 46;
            this.num_pers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_pers.ValueChanged += new System.EventHandler(this.num_pers_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(104, 313);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 45;
            this.label9.Text = "Описание";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(446, 514);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 46);
            this.button2.TabIndex = 43;
            this.button2.Text = "Обновить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // room_numb
            // 
            this.room_numb.FormattingEnabled = true;
            this.room_numb.Location = new System.Drawing.Point(236, 165);
            this.room_numb.Name = "room_numb";
            this.room_numb.Size = new System.Drawing.Size(122, 28);
            this.room_numb.TabIndex = 42;
            // 
            // sale
            // 
            this.sale.AutoSize = true;
            this.sale.Location = new System.Drawing.Point(446, 478);
            this.sale.Name = "sale";
            this.sale.Size = new System.Drawing.Size(64, 20);
            this.sale.TabIndex = 41;
            this.sale.Text = "Скидка: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(474, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "суток";
            // 
            // night
            // 
            this.night.AutoSize = true;
            this.night.Location = new System.Drawing.Point(453, 274);
            this.night.Name = "night";
            this.night.Size = new System.Drawing.Size(17, 20);
            this.night.TabIndex = 39;
            this.night.Text = "0";
            // 
            // full_cost
            // 
            this.full_cost.BackColor = System.Drawing.SystemColors.ControlLight;
            this.full_cost.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.full_cost.ForeColor = System.Drawing.Color.Red;
            this.full_cost.Location = new System.Drawing.Point(446, 402);
            this.full_cost.Name = "full_cost";
            this.full_cost.Size = new System.Drawing.Size(179, 76);
            this.full_cost.TabIndex = 38;
            this.full_cost.Text = "Full price";
            this.full_cost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(389, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Цена за сутки";
            // 
            // room_price
            // 
            this.room_price.BackColor = System.Drawing.SystemColors.ControlLight;
            this.room_price.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.room_price.Location = new System.Drawing.Point(389, 161);
            this.room_price.Name = "room_price";
            this.room_price.Size = new System.Drawing.Size(105, 30);
            this.room_price.TabIndex = 36;
            this.room_price.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "Дата выезда";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Дата заезда";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Номер комнаты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Тип комнаты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Фио";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(300, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 36);
            this.label1.TabIndex = 27;
            this.label1.Text = "Бронь";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 46);
            this.button1.TabIndex = 26;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_fio
            // 
            this.tb_fio.Location = new System.Drawing.Point(104, 108);
            this.tb_fio.Name = "tb_fio";
            this.tb_fio.Size = new System.Drawing.Size(560, 27);
            this.tb_fio.TabIndex = 48;
            // 
            // cm_room_type
            // 
            this.cm_room_type.FormattingEnabled = true;
            this.cm_room_type.Items.AddRange(new object[] {
            "DBC",
            "TWC",
            "ROH",
            "DSC"});
            this.cm_room_type.Location = new System.Drawing.Point(104, 165);
            this.cm_room_type.Name = "cm_room_type";
            this.cm_room_type.Size = new System.Drawing.Size(110, 28);
            this.cm_room_type.TabIndex = 49;
            this.cm_room_type.SelectedValueChanged += new System.EventHandler(this.cm_room_type_SelectedValueChanged);
            // 
            // tb_des
            // 
            this.tb_des.Location = new System.Drawing.Point(104, 336);
            this.tb_des.Multiline = true;
            this.tb_des.Name = "tb_des";
            this.tb_des.Size = new System.Drawing.Size(300, 162);
            this.tb_des.TabIndex = 50;
            // 
            // date_dep
            // 
            this.date_dep.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_dep.Location = new System.Drawing.Point(272, 274);
            this.date_dep.Name = "date_dep";
            this.date_dep.Size = new System.Drawing.Size(132, 27);
            this.date_dep.TabIndex = 51;
            // 
            // date_arr
            // 
            this.date_arr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_arr.Location = new System.Drawing.Point(104, 274);
            this.date_arr.Name = "date_arr";
            this.date_arr.Size = new System.Drawing.Size(132, 27);
            this.date_arr.TabIndex = 52;
            // 
            // tb_perm
            // 
            this.tb_perm.Location = new System.Drawing.Point(527, 217);
            this.tb_perm.Name = "tb_perm";
            this.tb_perm.Size = new System.Drawing.Size(73, 27);
            this.tb_perm.TabIndex = 53;
            this.tb_perm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_perm_KeyPress);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(496, 576);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 46);
            this.button3.TabIndex = 79;
            this.button3.Text = "Выселить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 634);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tb_perm);
            this.Controls.Add(this.date_arr);
            this.Controls.Add(this.date_dep);
            this.Controls.Add(this.tb_des);
            this.Controls.Add(this.cm_room_type);
            this.Controls.Add(this.tb_fio);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.num_pers);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.room_numb);
            this.Controls.Add(this.sale);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.night);
            this.Controls.Add(this.full_cost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.room_price);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_pers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown num_pers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox room_numb;
        private System.Windows.Forms.Label sale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label night;
        private System.Windows.Forms.Label full_cost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label room_price;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_fio;
        private System.Windows.Forms.ComboBox cm_room_type;
        private System.Windows.Forms.TextBox tb_des;
        private System.Windows.Forms.DateTimePicker date_dep;
        private System.Windows.Forms.DateTimePicker date_arr;
        private System.Windows.Forms.TextBox tb_perm;
        private System.Windows.Forms.Button button3;
    }
}