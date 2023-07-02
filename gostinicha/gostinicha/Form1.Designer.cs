
namespace gostinicha
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btt_arr = new System.Windows.Forms.Button();
            this.btt_HM = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.arr_dep_free = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_arr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_dep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btt_reside = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.WalkIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(180, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 100;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(852, 697);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btt_arr
            // 
            this.btt_arr.Location = new System.Drawing.Point(13, 94);
            this.btt_arr.Name = "btt_arr";
            this.btt_arr.Size = new System.Drawing.Size(143, 39);
            this.btt_arr.TabIndex = 2;
            this.btt_arr.Text = "Arrivals";
            this.btt_arr.UseVisualStyleBackColor = true;
            this.btt_arr.Click += new System.EventHandler(this.btt_arr_Click);
            // 
            // btt_HM
            // 
            this.btt_HM.Location = new System.Drawing.Point(13, 153);
            this.btt_HM.Name = "btt_HM";
            this.btt_HM.Size = new System.Drawing.Size(143, 39);
            this.btt_HM.TabIndex = 3;
            this.btt_HM.Text = "House Manager";
            this.btt_HM.UseVisualStyleBackColor = true;
            this.btt_HM.Click += new System.EventHandler(this.btt_HM_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Room_number,
            this.Status,
            this.arr_dep_free,
            this.date_arr,
            this.date_dep});
            this.dataGridView2.Location = new System.Drawing.Point(180, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 100;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(852, 697);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellEndEdit);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 53;
            // 
            // Room_number
            // 
            this.Room_number.HeaderText = "Room number";
            this.Room_number.MinimumWidth = 6;
            this.Room_number.Name = "Room_number";
            this.Room_number.ReadOnly = true;
            this.Room_number.Width = 133;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Items.AddRange(new object[] {
            "Clear",
            "Dirty",
            "PickUp"});
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Width = 55;
            // 
            // arr_dep_free
            // 
            this.arr_dep_free.HeaderText = "arr/dep/free";
            this.arr_dep_free.MinimumWidth = 6;
            this.arr_dep_free.Name = "arr_dep_free";
            this.arr_dep_free.ReadOnly = true;
            this.arr_dep_free.Width = 120;
            // 
            // date_arr
            // 
            this.date_arr.HeaderText = "Date Arr";
            this.date_arr.MinimumWidth = 6;
            this.date_arr.Name = "date_arr";
            this.date_arr.ReadOnly = true;
            this.date_arr.Width = 94;
            // 
            // date_dep
            // 
            this.date_dep.HeaderText = "Date Dep";
            this.date_dep.MinimumWidth = 6;
            this.date_dep.Name = "date_dep";
            this.date_dep.ReadOnly = true;
            this.date_dep.Width = 102;
            // 
            // btt_reside
            // 
            this.btt_reside.Location = new System.Drawing.Point(13, 211);
            this.btt_reside.Name = "btt_reside";
            this.btt_reside.Size = new System.Drawing.Size(143, 39);
            this.btt_reside.TabIndex = 5;
            this.btt_reside.Text = "Reside";
            this.btt_reside.UseVisualStyleBackColor = true;
            this.btt_reside.Click += new System.EventHandler(this.btt_reside_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(180, 12);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 100;
            this.dataGridView3.RowTemplate.Height = 29;
            this.dataGridView3.Size = new System.Drawing.Size(852, 697);
            this.dataGridView3.TabIndex = 6;
            this.dataGridView3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellDoubleClick);
            // 
            // WalkIn
            // 
            this.WalkIn.Location = new System.Drawing.Point(12, 414);
            this.WalkIn.Name = "WalkIn";
            this.WalkIn.Size = new System.Drawing.Size(143, 39);
            this.WalkIn.TabIndex = 7;
            this.WalkIn.Text = "Walk In";
            this.WalkIn.UseVisualStyleBackColor = true;
            this.WalkIn.Click += new System.EventHandler(this.WalkIn_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1062, 753);
            this.Controls.Add(this.WalkIn);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.btt_reside);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btt_HM);
            this.Controls.Add(this.btt_arr);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btt_arr;
        private System.Windows.Forms.Button btt_HM;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room_number;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn arr_dep_free;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_arr;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_dep;
        private System.Windows.Forms.Button btt_reside;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button WalkIn;
    }
}

