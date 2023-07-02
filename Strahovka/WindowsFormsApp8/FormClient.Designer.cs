namespace WindowsFormsApp8
{
    partial class FormClient
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
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.buttonAddClient = new System.Windows.Forms.Button();
            this.buttonDelClient = new System.Windows.Forms.Button();
            this.labelIdCl = new System.Windows.Forms.Label();
            this.labelSurName = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPatron = new System.Windows.Forms.Label();
            this.labelAdress = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelInn = new System.Windows.Forms.Label();
            this.textBoxIdClient = new System.Windows.Forms.TextBox();
            this.textBoxSuraName = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPatron = new System.Windows.Forms.TextBox();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxInn = new System.Windows.Forms.TextBox();
            this.buttonOkDel = new System.Windows.Forms.Button();
            this.buttonOkAdd = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(12, 12);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(619, 302);
            this.textBoxInfo.TabIndex = 0;
            // 
            // buttonAddClient
            // 
            this.buttonAddClient.Location = new System.Drawing.Point(648, 14);
            this.buttonAddClient.Name = "buttonAddClient";
            this.buttonAddClient.Size = new System.Drawing.Size(95, 30);
            this.buttonAddClient.TabIndex = 1;
            this.buttonAddClient.Text = "Добавить";
            this.buttonAddClient.UseVisualStyleBackColor = true;
            this.buttonAddClient.Click += new System.EventHandler(this.buttonAddClient_Click);
            // 
            // buttonDelClient
            // 
            this.buttonDelClient.Location = new System.Drawing.Point(648, 50);
            this.buttonDelClient.Name = "buttonDelClient";
            this.buttonDelClient.Size = new System.Drawing.Size(95, 28);
            this.buttonDelClient.TabIndex = 2;
            this.buttonDelClient.Text = "Удалить";
            this.buttonDelClient.UseVisualStyleBackColor = true;
            this.buttonDelClient.Click += new System.EventHandler(this.buttonDelClient_Click);
            // 
            // labelIdCl
            // 
            this.labelIdCl.AutoSize = true;
            this.labelIdCl.Location = new System.Drawing.Point(648, 90);
            this.labelIdCl.Name = "labelIdCl";
            this.labelIdCl.Size = new System.Drawing.Size(95, 17);
            this.labelIdCl.TabIndex = 3;
            this.labelIdCl.Text = "Код клиента:";
            // 
            // labelSurName
            // 
            this.labelSurName.AutoSize = true;
            this.labelSurName.Location = new System.Drawing.Point(648, 116);
            this.labelSurName.Name = "labelSurName";
            this.labelSurName.Size = new System.Drawing.Size(74, 17);
            this.labelSurName.TabIndex = 4;
            this.labelSurName.Text = "Фамилия:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(648, 143);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 17);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Имя:";
            // 
            // labelPatron
            // 
            this.labelPatron.AutoSize = true;
            this.labelPatron.Location = new System.Drawing.Point(648, 169);
            this.labelPatron.Name = "labelPatron";
            this.labelPatron.Size = new System.Drawing.Size(75, 17);
            this.labelPatron.TabIndex = 6;
            this.labelPatron.Text = "Отчество:";
            // 
            // labelAdress
            // 
            this.labelAdress.AutoSize = true;
            this.labelAdress.Location = new System.Drawing.Point(648, 196);
            this.labelAdress.Name = "labelAdress";
            this.labelAdress.Size = new System.Drawing.Size(52, 17);
            this.labelAdress.TabIndex = 7;
            this.labelAdress.Text = "Адрес:";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(648, 223);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(72, 17);
            this.labelPhone.TabIndex = 8;
            this.labelPhone.Text = "Телефон:";
            // 
            // labelInn
            // 
            this.labelInn.AutoSize = true;
            this.labelInn.Location = new System.Drawing.Point(648, 249);
            this.labelInn.Name = "labelInn";
            this.labelInn.Size = new System.Drawing.Size(42, 17);
            this.labelInn.TabIndex = 9;
            this.labelInn.Text = "ИНН:";
            // 
            // textBoxIdClient
            // 
            this.textBoxIdClient.Location = new System.Drawing.Point(749, 83);
            this.textBoxIdClient.Name = "textBoxIdClient";
            this.textBoxIdClient.Size = new System.Drawing.Size(100, 22);
            this.textBoxIdClient.TabIndex = 10;
            // 
            // textBoxSuraName
            // 
            this.textBoxSuraName.Location = new System.Drawing.Point(749, 111);
            this.textBoxSuraName.Name = "textBoxSuraName";
            this.textBoxSuraName.Size = new System.Drawing.Size(100, 22);
            this.textBoxSuraName.TabIndex = 11;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(749, 138);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 22);
            this.textBoxName.TabIndex = 12;
            // 
            // textBoxPatron
            // 
            this.textBoxPatron.Location = new System.Drawing.Point(749, 164);
            this.textBoxPatron.Name = "textBoxPatron";
            this.textBoxPatron.Size = new System.Drawing.Size(100, 22);
            this.textBoxPatron.TabIndex = 13;
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Location = new System.Drawing.Point(749, 191);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(100, 22);
            this.textBoxAdress.TabIndex = 14;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(749, 218);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(100, 22);
            this.textBoxPhone.TabIndex = 15;
            // 
            // textBoxInn
            // 
            this.textBoxInn.Location = new System.Drawing.Point(749, 244);
            this.textBoxInn.Name = "textBoxInn";
            this.textBoxInn.Size = new System.Drawing.Size(100, 22);
            this.textBoxInn.TabIndex = 16;
            // 
            // buttonOkDel
            // 
            this.buttonOkDel.Location = new System.Drawing.Point(868, 83);
            this.buttonOkDel.Name = "buttonOkDel";
            this.buttonOkDel.Size = new System.Drawing.Size(41, 23);
            this.buttonOkDel.TabIndex = 17;
            this.buttonOkDel.Text = "ОК";
            this.buttonOkDel.UseVisualStyleBackColor = true;
            this.buttonOkDel.Click += new System.EventHandler(this.buttonOkDel_Click);
            // 
            // buttonOkAdd
            // 
            this.buttonOkAdd.Location = new System.Drawing.Point(868, 246);
            this.buttonOkAdd.Name = "buttonOkAdd";
            this.buttonOkAdd.Size = new System.Drawing.Size(41, 23);
            this.buttonOkAdd.TabIndex = 18;
            this.buttonOkAdd.Text = "ОК";
            this.buttonOkAdd.UseVisualStyleBackColor = true;
            this.buttonOkAdd.Click += new System.EventHandler(this.buttonOkAdd_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(13, 415);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 19;
            this.buttonExit.Text = "Назад";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 450);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonOkAdd);
            this.Controls.Add(this.buttonOkDel);
            this.Controls.Add(this.textBoxInn);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxAdress);
            this.Controls.Add(this.textBoxPatron);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxSuraName);
            this.Controls.Add(this.textBoxIdClient);
            this.Controls.Add(this.labelInn);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelAdress);
            this.Controls.Add(this.labelPatron);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelSurName);
            this.Controls.Add(this.labelIdCl);
            this.Controls.Add(this.buttonDelClient);
            this.Controls.Add(this.buttonAddClient);
            this.Controls.Add(this.textBoxInfo);
            this.Name = "FormClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиенты";
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button buttonAddClient;
        private System.Windows.Forms.Button buttonDelClient;
        private System.Windows.Forms.Label labelIdCl;
        private System.Windows.Forms.Label labelSurName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPatron;
        private System.Windows.Forms.Label labelAdress;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelInn;
        private System.Windows.Forms.TextBox textBoxIdClient;
        private System.Windows.Forms.TextBox textBoxSuraName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPatron;
        private System.Windows.Forms.TextBox textBoxAdress;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxInn;
        private System.Windows.Forms.Button buttonOkDel;
        private System.Windows.Forms.Button buttonOkAdd;
        private System.Windows.Forms.Button buttonExit;
    }
}