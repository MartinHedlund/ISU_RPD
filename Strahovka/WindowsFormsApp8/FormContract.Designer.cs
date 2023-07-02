namespace WindowsFormsApp8
{
    partial class FormContract
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
            this.buttonAddContract = new System.Windows.Forms.Button();
            this.buttonRemoveContract = new System.Windows.Forms.Button();
            this.labelIdContr = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.labelRate = new System.Windows.Forms.Label();
            this.labelIdFilial = new System.Windows.Forms.Label();
            this.labelIdType = new System.Windows.Forms.Label();
            this.labelIdAgent = new System.Windows.Forms.Label();
            this.labelIdClient = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.textBoxRate = new System.Windows.Forms.TextBox();
            this.textBoxIdFilial = new System.Windows.Forms.TextBox();
            this.textBoxIdType = new System.Windows.Forms.TextBox();
            this.textBoxIdAgent = new System.Windows.Forms.TextBox();
            this.textBoxidClient = new System.Windows.Forms.TextBox();
            this.buttonOkRem = new System.Windows.Forms.Button();
            this.buttonOkAdd = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonVyruch = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.buttonMonth = new System.Windows.Forms.Button();
            this.textBoxMonth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAddContract
            // 
            this.buttonAddContract.Location = new System.Drawing.Point(514, 13);
            this.buttonAddContract.Name = "buttonAddContract";
            this.buttonAddContract.Size = new System.Drawing.Size(87, 30);
            this.buttonAddContract.TabIndex = 1;
            this.buttonAddContract.Text = "Добавить";
            this.buttonAddContract.UseVisualStyleBackColor = true;
            this.buttonAddContract.Click += new System.EventHandler(this.buttonAddContract_Click);
            // 
            // buttonRemoveContract
            // 
            this.buttonRemoveContract.Location = new System.Drawing.Point(514, 49);
            this.buttonRemoveContract.Name = "buttonRemoveContract";
            this.buttonRemoveContract.Size = new System.Drawing.Size(87, 29);
            this.buttonRemoveContract.TabIndex = 2;
            this.buttonRemoveContract.Text = "Удалить";
            this.buttonRemoveContract.UseVisualStyleBackColor = true;
            this.buttonRemoveContract.Click += new System.EventHandler(this.buttonRemoveContract_Click);
            // 
            // labelIdContr
            // 
            this.labelIdContr.AutoSize = true;
            this.labelIdContr.Location = new System.Drawing.Point(514, 85);
            this.labelIdContr.Name = "labelIdContr";
            this.labelIdContr.Size = new System.Drawing.Size(119, 17);
            this.labelIdContr.TabIndex = 3;
            this.labelIdContr.Text = "Номер договора:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(514, 111);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(110, 17);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "Дата договора:";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(514, 139);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(125, 17);
            this.labelSum.TabIndex = 5;
            this.labelSum.Text = "Страховая сумма:";
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(514, 168);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(128, 17);
            this.labelRate.TabIndex = 6;
            this.labelRate.Text = "Тарифная ставка:";
            // 
            // labelIdFilial
            // 
            this.labelIdFilial.AutoSize = true;
            this.labelIdFilial.Location = new System.Drawing.Point(514, 198);
            this.labelIdFilial.Name = "labelIdFilial";
            this.labelIdFilial.Size = new System.Drawing.Size(65, 17);
            this.labelIdFilial.TabIndex = 7;
            this.labelIdFilial.Text = "Филиал:";
            // 
            // labelIdType
            // 
            this.labelIdType.AutoSize = true;
            this.labelIdType.Location = new System.Drawing.Point(514, 225);
            this.labelIdType.Name = "labelIdType";
            this.labelIdType.Size = new System.Drawing.Size(124, 17);
            this.labelIdType.TabIndex = 8;
            this.labelIdType.Text = "Вид страхования:";
            // 
            // labelIdAgent
            // 
            this.labelIdAgent.AutoSize = true;
            this.labelIdAgent.Location = new System.Drawing.Point(514, 254);
            this.labelIdAgent.Name = "labelIdAgent";
            this.labelIdAgent.Size = new System.Drawing.Size(49, 17);
            this.labelIdAgent.TabIndex = 9;
            this.labelIdAgent.Text = "Агент:";
            // 
            // labelIdClient
            // 
            this.labelIdClient.AutoSize = true;
            this.labelIdClient.Location = new System.Drawing.Point(514, 283);
            this.labelIdClient.Name = "labelIdClient";
            this.labelIdClient.Size = new System.Drawing.Size(60, 17);
            this.labelIdClient.TabIndex = 10;
            this.labelIdClient.Text = "Клиент:";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(656, 79);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(100, 22);
            this.textBoxNumber.TabIndex = 11;
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(656, 108);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(100, 22);
            this.textBoxDate.TabIndex = 12;
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(656, 136);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(100, 22);
            this.textBoxSum.TabIndex = 13;
            // 
            // textBoxRate
            // 
            this.textBoxRate.Location = new System.Drawing.Point(656, 165);
            this.textBoxRate.Name = "textBoxRate";
            this.textBoxRate.Size = new System.Drawing.Size(100, 22);
            this.textBoxRate.TabIndex = 14;
            // 
            // textBoxIdFilial
            // 
            this.textBoxIdFilial.Location = new System.Drawing.Point(656, 193);
            this.textBoxIdFilial.Name = "textBoxIdFilial";
            this.textBoxIdFilial.Size = new System.Drawing.Size(100, 22);
            this.textBoxIdFilial.TabIndex = 15;
            // 
            // textBoxIdType
            // 
            this.textBoxIdType.Location = new System.Drawing.Point(656, 225);
            this.textBoxIdType.Name = "textBoxIdType";
            this.textBoxIdType.Size = new System.Drawing.Size(100, 22);
            this.textBoxIdType.TabIndex = 16;
            // 
            // textBoxIdAgent
            // 
            this.textBoxIdAgent.Location = new System.Drawing.Point(656, 254);
            this.textBoxIdAgent.Name = "textBoxIdAgent";
            this.textBoxIdAgent.Size = new System.Drawing.Size(100, 22);
            this.textBoxIdAgent.TabIndex = 17;
            // 
            // textBoxidClient
            // 
            this.textBoxidClient.Location = new System.Drawing.Point(656, 283);
            this.textBoxidClient.Name = "textBoxidClient";
            this.textBoxidClient.Size = new System.Drawing.Size(100, 22);
            this.textBoxidClient.TabIndex = 18;
            // 
            // buttonOkRem
            // 
            this.buttonOkRem.Location = new System.Drawing.Point(778, 77);
            this.buttonOkRem.Name = "buttonOkRem";
            this.buttonOkRem.Size = new System.Drawing.Size(46, 23);
            this.buttonOkRem.TabIndex = 19;
            this.buttonOkRem.Text = "ОК";
            this.buttonOkRem.UseVisualStyleBackColor = true;
            this.buttonOkRem.Click += new System.EventHandler(this.buttonOkRem_Click);
            // 
            // buttonOkAdd
            // 
            this.buttonOkAdd.Location = new System.Drawing.Point(778, 283);
            this.buttonOkAdd.Name = "buttonOkAdd";
            this.buttonOkAdd.Size = new System.Drawing.Size(46, 23);
            this.buttonOkAdd.TabIndex = 20;
            this.buttonOkAdd.Text = "ОК";
            this.buttonOkAdd.UseVisualStyleBackColor = true;
            this.buttonOkAdd.Click += new System.EventHandler(this.buttonOkAdd_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(13, 415);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 21;
            this.buttonExit.Text = "Назад";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonVyruch
            // 
            this.buttonVyruch.Location = new System.Drawing.Point(656, 325);
            this.buttonVyruch.Name = "buttonVyruch";
            this.buttonVyruch.Size = new System.Drawing.Size(148, 30);
            this.buttonVyruch.TabIndex = 22;
            this.buttonVyruch.Text = "Выручка в месяц";
            this.buttonVyruch.UseVisualStyleBackColor = true;
            this.buttonVyruch.Click += new System.EventHandler(this.buttonVyruch_Click);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(13, 20);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(495, 365);
            this.textBoxInfo.TabIndex = 23;
            // 
            // buttonMonth
            // 
            this.buttonMonth.Location = new System.Drawing.Point(445, 411);
            this.buttonMonth.Name = "buttonMonth";
            this.buttonMonth.Size = new System.Drawing.Size(197, 27);
            this.buttonMonth.TabIndex = 24;
            this.buttonMonth.Text = "Показать договора за";
            this.buttonMonth.UseVisualStyleBackColor = true;
            this.buttonMonth.Click += new System.EventHandler(this.buttonMonth_Click);
            // 
            // textBoxMonth
            // 
            this.textBoxMonth.Location = new System.Drawing.Point(648, 413);
            this.textBoxMonth.Name = "textBoxMonth";
            this.textBoxMonth.Size = new System.Drawing.Size(100, 22);
            this.textBoxMonth.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(767, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "месяц.";
            // 
            // FormContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMonth);
            this.Controls.Add(this.buttonMonth);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.buttonVyruch);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonOkAdd);
            this.Controls.Add(this.buttonOkRem);
            this.Controls.Add(this.textBoxidClient);
            this.Controls.Add(this.textBoxIdAgent);
            this.Controls.Add(this.textBoxIdType);
            this.Controls.Add(this.textBoxIdFilial);
            this.Controls.Add(this.textBoxRate);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.labelIdClient);
            this.Controls.Add(this.labelIdAgent);
            this.Controls.Add(this.labelIdType);
            this.Controls.Add(this.labelIdFilial);
            this.Controls.Add(this.labelRate);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelIdContr);
            this.Controls.Add(this.buttonRemoveContract);
            this.Controls.Add(this.buttonAddContract);
            this.Name = "FormContract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Договора";
            this.Load += new System.EventHandler(this.FormContract_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAddContract;
        private System.Windows.Forms.Button buttonRemoveContract;
        private System.Windows.Forms.Label labelIdContr;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.Label labelIdFilial;
        private System.Windows.Forms.Label labelIdType;
        private System.Windows.Forms.Label labelIdAgent;
        private System.Windows.Forms.Label labelIdClient;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.TextBox textBoxRate;
        private System.Windows.Forms.TextBox textBoxIdFilial;
        private System.Windows.Forms.TextBox textBoxIdType;
        private System.Windows.Forms.TextBox textBoxIdAgent;
        private System.Windows.Forms.TextBox textBoxidClient;
        private System.Windows.Forms.Button buttonOkRem;
        private System.Windows.Forms.Button buttonOkAdd;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonVyruch;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button buttonMonth;
        private System.Windows.Forms.TextBox textBoxMonth;
        private System.Windows.Forms.Label label1;
    }
}