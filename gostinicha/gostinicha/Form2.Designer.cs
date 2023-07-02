
namespace gostinicha
{
    partial class Form2
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
            this.fio = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.room_type = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.date_arr = new System.Windows.Forms.Label();
            this.date_dep = new System.Windows.Forms.Label();
            this.room_price = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.full_cost = new System.Windows.Forms.Label();
            this.night = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sale = new System.Windows.Forms.Label();
            this.room_numb = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lb_des = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.num_pers = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_pers)).BeginInit();
            this.SuspendLayout();
            // 
            // fio
            // 
            this.fio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fio.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.fio.Location = new System.Drawing.Point(38, 48);
            this.fio.Name = "fio";
            this.fio.Size = new System.Drawing.Size(525, 35);
            this.fio.TabIndex = 0;
            this.fio.Text = "Test";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(238, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Бронь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Фио";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Тип комнаты";
            // 
            // room_type
            // 
            this.room_type.BackColor = System.Drawing.SystemColors.ControlLight;
            this.room_type.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.room_type.Location = new System.Drawing.Point(38, 106);
            this.room_type.Name = "room_type";
            this.room_type.Size = new System.Drawing.Size(100, 30);
            this.room_type.TabIndex = 5;
            this.room_type.Text = "DBC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Номер комнаты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Дата заезда";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Дата выезда";
            // 
            // date_arr
            // 
            this.date_arr.BackColor = System.Drawing.SystemColors.ControlLight;
            this.date_arr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.date_arr.Location = new System.Drawing.Point(38, 219);
            this.date_arr.Name = "date_arr";
            this.date_arr.Size = new System.Drawing.Size(130, 33);
            this.date_arr.TabIndex = 9;
            this.date_arr.Text = "DBC";
            // 
            // date_dep
            // 
            this.date_dep.BackColor = System.Drawing.SystemColors.ControlLight;
            this.date_dep.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.date_dep.Location = new System.Drawing.Point(210, 219);
            this.date_dep.Name = "date_dep";
            this.date_dep.Size = new System.Drawing.Size(132, 33);
            this.date_dep.TabIndex = 10;
            this.date_dep.Text = "DBC";
            // 
            // room_price
            // 
            this.room_price.BackColor = System.Drawing.SystemColors.ControlLight;
            this.room_price.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.room_price.Location = new System.Drawing.Point(327, 106);
            this.room_price.Name = "room_price";
            this.room_price.Size = new System.Drawing.Size(105, 30);
            this.room_price.TabIndex = 12;
            this.room_price.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(327, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Цена за сутки";
            // 
            // full_cost
            // 
            this.full_cost.BackColor = System.Drawing.SystemColors.ControlLight;
            this.full_cost.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.full_cost.ForeColor = System.Drawing.Color.Red;
            this.full_cost.Location = new System.Drawing.Point(384, 347);
            this.full_cost.Name = "full_cost";
            this.full_cost.Size = new System.Drawing.Size(179, 76);
            this.full_cost.TabIndex = 14;
            this.full_cost.Text = "Full price";
            this.full_cost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // night
            // 
            this.night.AutoSize = true;
            this.night.Location = new System.Drawing.Point(348, 219);
            this.night.Name = "night";
            this.night.Size = new System.Drawing.Size(17, 20);
            this.night.TabIndex = 15;
            this.night.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(369, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "суток";
            // 
            // sale
            // 
            this.sale.AutoSize = true;
            this.sale.Location = new System.Drawing.Point(384, 423);
            this.sale.Name = "sale";
            this.sale.Size = new System.Drawing.Size(64, 20);
            this.sale.TabIndex = 17;
            this.sale.Text = "Скидка: ";
            // 
            // room_numb
            // 
            this.room_numb.FormattingEnabled = true;
            this.room_numb.Location = new System.Drawing.Point(174, 110);
            this.room_numb.Name = "room_numb";
            this.room_numb.Size = new System.Drawing.Size(122, 28);
            this.room_numb.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(384, 459);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 46);
            this.button2.TabIndex = 20;
            this.button2.Text = "Заселить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lb_des
            // 
            this.lb_des.BackColor = System.Drawing.SystemColors.Control;
            this.lb_des.Location = new System.Drawing.Point(38, 281);
            this.lb_des.Name = "lb_des";
            this.lb_des.Size = new System.Drawing.Size(310, 158);
            this.lb_des.TabIndex = 21;
            this.lb_des.Text = "Примечания";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Описание";
            // 
            // num_pers
            // 
            this.num_pers.Location = new System.Drawing.Point(574, 109);
            this.num_pers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_pers.Name = "num_pers";
            this.num_pers.Size = new System.Drawing.Size(56, 27);
            this.num_pers.TabIndex = 23;
            this.num_pers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_pers.ValueChanged += new System.EventHandler(this.num_pers_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(465, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Кол-во проживающих";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(676, 537);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.num_pers);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_des);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.room_numb);
            this.Controls.Add(this.sale);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.night);
            this.Controls.Add(this.full_cost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.room_price);
            this.Controls.Add(this.date_dep);
            this.Controls.Add(this.date_arr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.room_type);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fio);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.num_pers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label room_type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label date_arr;
        private System.Windows.Forms.Label date_dep;
        private System.Windows.Forms.Label room_price;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label full_cost;
        private System.Windows.Forms.Label night;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label sale;
        private System.Windows.Forms.ComboBox room_numb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lb_des;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_pers;
        private System.Windows.Forms.Label label10;
    }
}