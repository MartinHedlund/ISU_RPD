namespace WindowsFormsApp8
{
    partial class FormType
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
            this.buttonAddType = new System.Windows.Forms.Button();
            this.buttonRemType = new System.Windows.Forms.Button();
            this.buttonOkRem = new System.Windows.Forms.Button();
            this.buttonOkAdd = new System.Windows.Forms.Button();
            this.labelIdType = new System.Windows.Forms.Label();
            this.labelNameType = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelPercent = new System.Windows.Forms.Label();
            this.textBoxPercent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(12, 12);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(468, 307);
            this.textBoxInfo.TabIndex = 0;
            // 
            // buttonAddType
            // 
            this.buttonAddType.Location = new System.Drawing.Point(501, 13);
            this.buttonAddType.Name = "buttonAddType";
            this.buttonAddType.Size = new System.Drawing.Size(90, 27);
            this.buttonAddType.TabIndex = 1;
            this.buttonAddType.Text = "Добавить";
            this.buttonAddType.UseVisualStyleBackColor = true;
            this.buttonAddType.Click += new System.EventHandler(this.buttonAddType_Click);
            // 
            // buttonRemType
            // 
            this.buttonRemType.Location = new System.Drawing.Point(501, 46);
            this.buttonRemType.Name = "buttonRemType";
            this.buttonRemType.Size = new System.Drawing.Size(90, 28);
            this.buttonRemType.TabIndex = 2;
            this.buttonRemType.Text = "Удалить";
            this.buttonRemType.UseVisualStyleBackColor = true;
            this.buttonRemType.Click += new System.EventHandler(this.buttonRemType_Click);
            // 
            // buttonOkRem
            // 
            this.buttonOkRem.Location = new System.Drawing.Point(768, 86);
            this.buttonOkRem.Name = "buttonOkRem";
            this.buttonOkRem.Size = new System.Drawing.Size(56, 23);
            this.buttonOkRem.TabIndex = 3;
            this.buttonOkRem.Text = "ОК";
            this.buttonOkRem.UseVisualStyleBackColor = true;
            this.buttonOkRem.Click += new System.EventHandler(this.buttonOkRem_Click);
            // 
            // buttonOkAdd
            // 
            this.buttonOkAdd.Location = new System.Drawing.Point(768, 136);
            this.buttonOkAdd.Name = "buttonOkAdd";
            this.buttonOkAdd.Size = new System.Drawing.Size(56, 23);
            this.buttonOkAdd.TabIndex = 4;
            this.buttonOkAdd.Text = "ОК";
            this.buttonOkAdd.UseVisualStyleBackColor = true;
            this.buttonOkAdd.Click += new System.EventHandler(this.buttonOkAdd_Click);
            // 
            // labelIdType
            // 
            this.labelIdType.AutoSize = true;
            this.labelIdType.Location = new System.Drawing.Point(501, 92);
            this.labelIdType.Name = "labelIdType";
            this.labelIdType.Size = new System.Drawing.Size(90, 17);
            this.labelIdType.TabIndex = 5;
            this.labelIdType.Text = "Номер вида:";
            // 
            // labelNameType
            // 
            this.labelNameType.AutoSize = true;
            this.labelNameType.Location = new System.Drawing.Point(501, 118);
            this.labelNameType.Name = "labelNameType";
            this.labelNameType.Size = new System.Drawing.Size(110, 17);
            this.labelNameType.TabIndex = 6;
            this.labelNameType.Text = "Наименование:";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(644, 87);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 22);
            this.textBoxId.TabIndex = 7;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(644, 113);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 22);
            this.textBoxName.TabIndex = 8;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(13, 415);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "Назад";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(501, 142);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(141, 17);
            this.labelPercent.TabIndex = 10;
            this.labelPercent.Text = "Процент от продаж:";
            // 
            // textBoxPercent
            // 
            this.textBoxPercent.Location = new System.Drawing.Point(644, 139);
            this.textBoxPercent.Name = "textBoxPercent";
            this.textBoxPercent.Size = new System.Drawing.Size(100, 22);
            this.textBoxPercent.TabIndex = 11;
            // 
            // FormType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 450);
            this.Controls.Add(this.textBoxPercent);
            this.Controls.Add(this.labelPercent);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelNameType);
            this.Controls.Add(this.labelIdType);
            this.Controls.Add(this.buttonOkAdd);
            this.Controls.Add(this.buttonOkRem);
            this.Controls.Add(this.buttonRemType);
            this.Controls.Add(this.buttonAddType);
            this.Controls.Add(this.textBoxInfo);
            this.Name = "FormType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вид страхования";
            this.Load += new System.EventHandler(this.FormType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button buttonAddType;
        private System.Windows.Forms.Button buttonRemType;
        private System.Windows.Forms.Button buttonOkRem;
        private System.Windows.Forms.Button buttonOkAdd;
        private System.Windows.Forms.Label labelIdType;
        private System.Windows.Forms.Label labelNameType;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.TextBox textBoxPercent;
    }
}